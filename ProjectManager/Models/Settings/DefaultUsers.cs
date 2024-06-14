namespace ProjectManager.Models.Settings;

public class DefaultUsers : List<DefaultUser>
{
}

public record DefaultUser(string UserName, string Password, string Role);