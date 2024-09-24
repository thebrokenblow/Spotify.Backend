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
        Group? group = null;
        foreach (var item in spotifyDbContext.Groups)
        {
            if (item.Id == request.Id)
            {
                group = item;
                break;
            }
        }


        return mapper.Map<GroupDetailsVM>(group);
    }
}