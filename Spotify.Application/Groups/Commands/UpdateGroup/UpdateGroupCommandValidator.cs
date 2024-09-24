using FluentValidation;

namespace Spotify.Application.Groups.Commands.UpdateGroup;

public class UpdateGroupCommandValidator : AbstractValidator<UpdateGroupCommand>
{
    public UpdateGroupCommandValidator()
    {
        RuleFor(updateGroupCommand => updateGroupCommand.Id).NotEqual(0);
        RuleFor(updateGroupCommand => updateGroupCommand.Title)
            .NotEmpty().MaximumLength(250);
    }
}