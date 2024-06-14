using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Models.Auth;
using ProjectManager.Models.Statics;

namespace ProjectManager.Controllers;

[AllowAnonymous, ApiController, IgnoreAntiforgeryToken]
public class AuthController(SignInManager<User> signInManager, ILogger<AuthController> logger)
	: ControllerBase
{
	[HttpGet(Routes.Auth.Login)]
	public async Task<IActionResult> Login(string login, string token, bool rememberMe)
	{
		var user = await signInManager.UserManager.FindByNameAsync(login);

		if (user is not null && 
			await signInManager.UserManager.VerifyUserTokenAsync(
				user, AuthConsts.Provider, AuthConsts.Name, token))
		{
			logger.LogInformation("User {UserName} logged in", login);
			await signInManager.SignInAsync(user, rememberMe);
			return LocalRedirect("/");
		}

		return BadRequest();
	}

	[HttpPost(Routes.Auth.Logout)]
	public async Task<IActionResult> Logout()
	{
		if (User.Identity?.IsAuthenticated == true)
			await signInManager.SignOutAsync();

		return LocalRedirect("/");
	}
}