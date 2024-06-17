using ProjectManager.Services.Interfaces;

namespace ProjectManager.Services;

public class ProjectContextHooks : IProjectContextHooks
{
	public event EventHandler<Guid>? OnCurrentProjectSet;

	public void SetCurrentProject(Guid projectId)
	{
		OnCurrentProjectSet?.Invoke(this, projectId);
	}
}