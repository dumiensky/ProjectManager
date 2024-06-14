using MongoDB.Wrapper;

namespace ProjectManager.Models.Entities;

public class Project : Entity
{
	public string? Name { get; set; }
	
	public string? Description { get; set; }
}