using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage
{
    public class UpdateProgrammingLanguageCommandValidator : AbstractValidator<UpdateProgrammingLanguageCommand>
    {
        public UpdateProgrammingLanguageCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
        }

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<UpdateProgrammingLanguageCommand> context, CancellationToken cancellation = default)
        {
            return context.InstanceToValidate == null
                ? new ValidationResult(new[] { new ValidationFailure(nameof(UpdateProgrammingLanguageCommand), $"{nameof(UpdateProgrammingLanguageCommand)} cannot be null") })
                : await base.ValidateAsync(context, cancellation);
        }
    }
}
