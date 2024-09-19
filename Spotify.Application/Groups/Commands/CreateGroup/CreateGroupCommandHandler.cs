using MediatR;
using Spotify.Domain;
using Spotify.Application.Interfaces;

namespace Spotify.Application.Groups.Commands.CreateGroup;

public class CreateGroupCommandHandler(ISpotifyDbContext spotifyDbContext) : IRequestHandler<CreateGroupCommand, int>
{
    public async Task<int> Handle(CreateGroupCommand request, CancellationToken cancellationToken)
    {
        var group = new Group
        {
            Title = request.Title,
            Description = request.Description,
        };

        await spotifyDbContext.Groups.AddAsync(group, cancellationToken);
        await spotifyDbContext.SaveChangesAsync(cancellationToken);

        return group.Id;
    }
}
