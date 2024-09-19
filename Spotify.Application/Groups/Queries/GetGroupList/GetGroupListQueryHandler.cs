using MediatR;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Spotify.Application.Interfaces;

namespace Spotify.Application.Groups.Queries.GetGroupList;

public class GetGroupListQueryHandler(IMapper mapper, ISpotifyDbContext spotifyDbContext) : IRequestHandler<GetGroupListQuery, GroupListVM>
{
    public async Task<GroupListVM> Handle(GetGroupListQuery request, CancellationToken cancellationToken)
    {
        var groups = await spotifyDbContext.Groups
            .ProjectTo<GroupLookupDto>(mapper.ConfigurationProvider)
            .Skip(request.CountSkipGroups)
            .Take(request.CountTakeGroups)
            .ToListAsync(cancellationToken);

        return new GroupListVM
        {
            Groups = groups
        };
    }
}