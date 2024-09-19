using MediatR;

namespace Spotify.Application.Groups.Queries.GetGroupList;

public class GetGroupListQuery : IRequest<GroupListVM>
{
    public int CountSkipGroups { get; set; }
    public int CountTakeGroups { get; set; }
}