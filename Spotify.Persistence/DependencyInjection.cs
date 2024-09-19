using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Spotify.Application.Interfaces;

namespace Spotify.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection
           services, IConfiguration configuration)
    {
        var connectionString = configuration["DbConnection"];
        services.AddDbContext<SpotifyDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });
        services.AddScoped<ISpotifyDbContext>(provider =>
            provider.GetService<SpotifyDbContext>());

        return services;
    }

}
