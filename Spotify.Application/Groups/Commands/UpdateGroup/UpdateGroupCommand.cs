using MediatR;

namespace Spotify.Application.Groups.Commands.UpdateGroup;

public class UpdateGroupCommand : IRequest
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
}