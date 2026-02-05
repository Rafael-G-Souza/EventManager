namespace EventManager.API.Models;

public class Registration
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime ResgiteredAt { get; set; } = DateTime.UtcNow;

    public Guid EventId { get; set; }
    public Event? Event { get; set; }

    public Guid AttendeeId { get; set; }
    public Attendee? Attendee { get; set; }
}