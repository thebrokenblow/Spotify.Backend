using System.Reflection;
using Spotify.Application;
using Spotify.Application.Common.Mappings;
using Spotify.Application.Interfaces;
using Spotify.Persistence;

namespace Spotify.WebApi;

public class Startup(IConfiguration configuration)
{

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddAutoMapper(config =>
        {
            config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
            config.AddProfile(new AssemblyMappingProfile(typeof(ISpotifyDbContext).Assembly));
        });

        services.AddApplication();
        services.AddPersistence(configuration);
        services.AddControllers();

        services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", policy =>
            {
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();
                policy.AllowAnyOrigin();
            });
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseRouting();
        app.UseHttpsRedirection();
        app.UseCors("AllowAll");

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}