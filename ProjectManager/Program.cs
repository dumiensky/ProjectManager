using AspNetCore.Identity.Mongo;
using MongoDB.Wrapper;
using MongoDB.Wrapper.Abstractions;
using MongoDB.Wrapper.Settings;
using MudBlazor.Services;
using ProjectManager.Components;
using ProjectManager.Models.Auth;

var builder = WebApplication.CreateBuilder(args);

var mongoDbSettings = builder.Configuration.GetSection(nameof(MongoDbSettings)).Get<MongoDbSettings>()!;

builder
	.Services.AddRazorComponents()
	.AddInteractiveServerComponents();

builder.Services.AddMudServices();
builder.Services.AddIdentityMongoDbProvider<User, Role, Guid>(c => 
	c.ConnectionString = $"{mongoDbSettings.ConnectionString}/{mongoDbSettings.DatabaseName}");

builder.Services.AddSingleton<IMongoDb>(new MongoDb(mongoDbSettings));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error", createScopeForErrors: true);
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app
	.MapRazorComponents<App>()
	.AddInteractiveServerRenderMode();

app.Run();