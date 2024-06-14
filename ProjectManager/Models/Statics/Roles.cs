namespace ProjectManager.Models.Statics;

public static class Roles
{
	public const string Admin = nameof(Admin);
	public const string DevOps = nameof(DevOps);
	public const string Developer = nameof(Developer);

	public static readonly string[] All = [Admin, DevOps, Developer];
}