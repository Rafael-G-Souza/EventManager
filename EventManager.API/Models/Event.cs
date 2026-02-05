namespace EventManager.API.Models;

public class Event
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string Title { get; set; }
    public string? Description { get; set; }
    public DateTime Date { get; set; }
    public required string Location { get; set; }

    public ICollection<Registration> Registrations { get; set; } = [];
}