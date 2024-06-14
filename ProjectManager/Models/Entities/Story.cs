using MongoDB.Wrapper;
using ProjectManager.Models.Enums;

namespace ProjectManager.Models.Entities;

public class Story : Entity
{
	public string? Name { get; set; }
	
	public string? Description { get; set; }
	
	public Priority Priority { get; set; }
	
	public Guid ProjectId { get; set; }
	
	public State State { get; set; }
	
	public Guid? OwnerId { get; set; }
}