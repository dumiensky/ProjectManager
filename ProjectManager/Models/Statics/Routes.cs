// ReSharper disable MemberHidesStaticFromOuterClass
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

	public static class Stories
	{
		public const string Index = "/stories";
		public const string Add = Index + "/add";
		public const string Details = Index + "/details/{StoryId:guid}";
		public const string Edit = Index + "/edit/{StoryId:guid}";

		public static string GetDetails(Guid storyId) => $"{Index}/details/{storyId}";
		public static string GetEdit(Guid storyId) => $"{Index}/edit/{storyId}";
	}
}