using MongoDB.Wrapper;
using ProjectManager.Models.Enums;

namespace ProjectManager.Models.Entities;

public class Job : Entity
{
	public string? Name { get; set; }
	
	public string? Description { get; set; }
	
	public Priority Priority { get; set; }
	
	public Guid StoryId { get; set; }
	
	public State State { get; set; }
	
	public Guid? UserId { get; set; }
	
	public TimeSpan EstimatedLength { get; set; }
	
	public DateTimeOffset StartTimestamp { get; set; }
	
	public DateTimeOffset EndTimestamp { get; set; }
}