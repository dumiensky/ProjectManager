using System.Security.Claims;

namespace ProjectManager.Models.Extensions;

public static class ClaimsPrincipalExtensions
{
	public static string? GetId(this ClaimsPrincipal user) =>
		user.FindFirst(ClaimTypes.NameIdentifier)?.Value;

	public static Guid? GetGuid(this ClaimsPrincipal user) =>
		GetId(user) is { } stringId && Guid.TryParse(stringId, out var guid)
			? guid
			: null;
}