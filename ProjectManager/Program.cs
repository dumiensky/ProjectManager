using AspNetCore.Identity.Mongo;
using MongoDB.Wrapper;
using MongoDB.Wrapper.Abstractions;
using MongoDB.Wrapper.Settings;
using MudBlazor.Services;
using ProjectManager.Components;
using ProjectManager.Models.Auth;
using ProjectManager.Models.Extensions;
using ProjectManager.Models.Statics;
using ProjectManager.Services.Provider;

var builder = WebApplication.CreateBuilder(args);

var mongoDbSettings = builder.Configuration.GetSection(nameof(MongoDbSettings)).Get<MongoDbSettings>()!;

builder.Services.AddControllers();
builder.Services.AddRazorComponents()
	.AddInteractiveServerComponents();

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

builder.Services.AddMudServices();
builder.Services.AddIdentityMongoDbProvider<User, Role, Guid>(c => 
	c.ConnectionString = $"{mongoDbSettings.ConnectionString}/{mongoDbSettings.DatabaseName}")
	.AddTokenProvider<AuthTokenProvider>(AuthConsts.Provider);

builder.Services.AddSingleton<IMongoDb>(new MongoDb(mongoDbSettings));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error", createScopeForErrors: true);
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapControllers();
app.MapRazorComponents<App>()
	.AddInteractiveServerRenderMode();

await app.InitializeIdentity();
await app.SeedUsers();

app.Run();