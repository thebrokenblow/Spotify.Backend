using MediatR;

namespace Spotify.Application.Groups.Queries.GetGroupDetails;

public class GetGroupDetailsQuery : IRequest<GroupDetailsVM>
{
    public int Id { get; set; }
}