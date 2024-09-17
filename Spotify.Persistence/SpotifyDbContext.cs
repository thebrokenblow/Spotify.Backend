using Microsoft.EntityFrameworkCore;
using Spotify.Domain;
using Spotify.Application.Interfaces;
using Spotify.Persistence.EntityTypeConfigurations;

namespace Spotify.Persistence;

public class SpotifyDbContext(DbContextOptions<SpotifyDbContext> options) : DbContext(options), ISpotifyDbContext
{
    public DbSet<Group> Groups { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new GroupConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}