using Auspex.TripService.Models;
using Microsoft.EntityFrameworkCore;

public class TripServiceContext : DbContext
{
    public DbSet<Trip> Trips { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<Location> Locations { get; set; }
    

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Filename=./tripService.db");
    }
}