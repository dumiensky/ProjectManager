using ProjectManager.Services.Interfaces;

namespace ProjectManager.Services;

public class ProjectContextHooks : IProjectContextHooks
{
	public event EventHandler? OnProjectListRefresh; 
	public event EventHandler<Guid>? OnCurrentProjectSet;

	public async Task RefreshProjectList()
	{
		OnProjectListRefresh?.Invoke(this, EventArgs.Empty);

		await Task.Delay(TimeSpan.FromMilliseconds(200));
	}

	public void SetCurrentProject(Guid projectId)
	{
		OnCurrentProjectSet?.Invoke(this, projectId);
	}
}