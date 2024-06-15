namespace ProjectManager.Services.Interfaces;

public interface IProjectContextHooks
{
	event EventHandler<Guid>? OnCurrentProjectSet;
	void SetCurrentProject(Guid projectId);
}