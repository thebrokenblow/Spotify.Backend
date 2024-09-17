using Spotify.Domain;
using Microsoft.EntityFrameworkCore;

namespace Spotify.Application.Interfaces;

public interface ISpotifyDbContext
{
    DbSet<Group> Groups { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}