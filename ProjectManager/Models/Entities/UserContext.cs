using MongoDB.Wrapper;

namespace ProjectManager.Models.Entities;

public class UserContext : Entity
{
	public Guid? ProjectId { get; set; }
	
	public bool DarkMode { get; set; }
}