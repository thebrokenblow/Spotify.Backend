using FluentValidation;

namespace Spotify.Application.Groups.Commands.DeleteCommand;

public class DeleteGroupCommandValidator : AbstractValidator<DeleteGroupCommand>
{
    public DeleteGroupCommandValidator()
    {
        RuleFor(deleteGroupCommand => deleteGroupCommand.Id)
            .NotEqual(0);
    }
}
