using EventManager.API.Models;
using Microsoft.EntityFrameworkCore;

namespace EventManager.API.Data;

public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
	{
	}

	public DbSet<Event> Events { get; set; }
	public DbSet<Attendee> Attendees { get; set; }
	public DbSet<Registration> Registrations { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Attendee>()
			.HasIndex(a => a.Email)
			.IsUnique();

		base.OnModelCreating(modelBuilder);
	}
	

}