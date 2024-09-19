using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Spotify.Application.Exceptions;
using Spotify.Application.Interfaces;
using Spotify.Domain;

namespace Spotify.Application.Groups.Queries.GetGroupDetails;

public class GetGroupDetailsQueryHandler(ISpotifyDbContext spotifyDbContext, IMapper mapper) : IRequestHandler<GetGroupDetailsQuery, GroupDetailsVM>
{
    public async Task<GroupDetailsVM> Handle(GetGroupDetailsQuery request, CancellationToken cancellationToken)
    {
        var group = await spotifyDbContext.Groups
            .FirstOrDefaultAsync(group => group.Id == request.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(Group), request.Id);

        return mapper.Map<GroupDetailsVM>(group);
    }
}