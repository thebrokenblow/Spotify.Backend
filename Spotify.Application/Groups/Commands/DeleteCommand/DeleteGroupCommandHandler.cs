using MediatR;
using Microsoft.EntityFrameworkCore;
using Spotify.Application.Exceptions;
using Spotify.Application.Interfaces;
using System.Text.RegularExpressions;

namespace Spotify.Application.Groups.Commands.DeleteCommand;

public class DeleteGroupCommandHandler(ISpotifyDbContext spotifyDbContext) : IRequestHandler<DeleteGroupCommand>
{
    public async Task Handle(DeleteGroupCommand request, CancellationToken cancellationToken)
    {
        var groups = await spotifyDbContext.Groups.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (groups is null)
        {
            throw new NotFoundException(nameof(Group), request.Id);
        }

        spotifyDbContext.Groups.Remove(groups);
        await spotifyDbContext.SaveChangesAsync(cancellationToken);
    }
}
