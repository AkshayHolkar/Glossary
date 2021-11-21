using FluentValidation;

namespace Glossaries.Application.Features.Glossaries.Commands.UpdateGlossary
{
    class UpdateGlossaryCommandValidator : AbstractValidator<UpdateGlossaryCommand>
    {
        public UpdateGlossaryCommandValidator()
        {
            RuleFor(p => p.Term)
                .NotEmpty().WithMessage("{Term} is required.")
                .NotNull()
                .MaximumLength(40).WithMessage("{Term} must not exceed 40 characters.");

            RuleFor(p => p.Definition)
                .NotEmpty().WithMessage("{Definition} is required.")
                .NotNull();
        }
    }
}
