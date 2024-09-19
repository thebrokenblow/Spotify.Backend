using MediatR;
using Microsoft.EntityFrameworkCore;
using Spotify.Domain;
using Spotify.Application.Exceptions;
using Spotify.Application.Interfaces;

namespace Spotify.Application.Groups.Commands.UpdateGroup;

public class UpdateGroupCommandHandler(ISpotifyDbContext spotifyDbContext) : IRequestHandler<UpdateGroupCommand>
{
    public async Task Handle(UpdateGroupCommand request, CancellationToken cancellationToken)
    {
        var entity = await spotifyDbContext.Groups
            .FirstOrDefaultAsync(group => group.Id == request.Id, cancellationToken) ?? 
            throw new NotFoundException(nameof(Group), request.Id);

        entity.Title = request.Title;
        entity.Description = request.Description;

        await spotifyDbContext.SaveChangesAsync(cancellationToken);
    }
}