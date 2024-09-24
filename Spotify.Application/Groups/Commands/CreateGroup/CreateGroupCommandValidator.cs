using FluentValidation;

namespace Spotify.Application.Groups.Commands.CreateGroup;

public class CreateGroupCommandValidator : AbstractValidator<CreateGroupCommand>
{
    public CreateGroupCommandValidator()
    {
        RuleFor(createNoteCommand =>
            createNoteCommand.Title).NotEmpty();
    }
}