namespace ProjectManager.Models.Statics;

public static class Routes
{
	public const string Index = "/";
	
	public static class Auth
	{
		public const string Index = "/auth";
		public const string Login = Index + "/login";
		public const string Logout = Index + "/logout";
	}

	public static class Projects
	{
		public const string Index = "/projects";
		public const string Add = Index + "/add";
		public const string Edit = Index + "/edit";
	}
}