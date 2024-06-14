using Microsoft.AspNetCore.Identity;
using ProjectManager.Models.Auth;
using ProjectManager.Models.Settings;
using ProjectManager.Models.Statics;

namespace ProjectManager.Models.Extensions;

public static class WebApplicationExtensions
{
	public static async Task InitializeIdentity(this WebApplication app)
	{
		using var scope = app.Services.CreateScope();
		var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<Role>>();
		
		foreach (var role in Roles.All)
		{
			if (!await roleManager.RoleExistsAsync(role))
				await roleManager.CreateAsync(new() { Name = role });
		}
	}
	
	public static async Task SeedUsers(this WebApplication app)
	{
		var defaults = app.Configuration.GetSection(nameof(DefaultUsers)).Get<DefaultUsers>();
		
		using var scope = app.Services.CreateScope();
		var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();

		foreach (var user in defaults!)
		{
			if (await userManager.FindByNameAsync(user.UserName) is not null) 
				continue;
			
			if (!Roles.All.Contains(user.Role))
				throw new($"Role {user.Role} does not exist!");

			var newUser = new User
			{
				UserName = user.UserName
			};
			await userManager.CreateAsync(newUser, user.Password);
			await userManager.AddToRoleAsync(newUser, user.Role);
		}
	}
}