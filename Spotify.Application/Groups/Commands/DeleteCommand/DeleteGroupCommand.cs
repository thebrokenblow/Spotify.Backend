using MediatR;

namespace Spotify.Application.Groups.Commands.DeleteCommand;

public class DeleteGroupCommand : IRequest
{
    public int Id { get; set; }
}