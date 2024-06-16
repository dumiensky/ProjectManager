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

	public static class Jobs
	{
		public const string Index = "/jobs";
		public const string Add = Index + "/add/{StoryId:guid}";
		public const string Details = Index + "/details/{JobId:guid}";
		public const string Edit = Index + "/edit/{JobId:guid}";

		public static string GetAdd(Guid storyId) => $"{Index}/add/{storyId}";
		public static string GetDetails(Guid jobId) => $"{Index}/details/{jobId}";
		public static string GetEdit(Guid jobId) => $"{Index}/edit/{jobId}";
	}
}