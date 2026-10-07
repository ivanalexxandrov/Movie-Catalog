using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Movie> Movies => Set<Movie>();
    public DbSet<Actor> Actors => Set<Actor>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movie>()
            .HasMany(m => m.Actors)
            .WithMany(a => a.Movies);

        modelBuilder.Entity<Actor>().HasData(
            new Actor
            {
                Id = 1,
                Name = "Tom Hanks",
                Bio = "American actor and filmmaker."
            },
            new Actor
            {
                Id = 2,
                Name = "Leonardo DiCaprio",
                Bio = "American actor and film producer."
            },
            new Actor
            {
                Id = 3,
                Name = "Margot Robbie",
                Bio = "Australian actress and producer."
            }
        );
    }
}
