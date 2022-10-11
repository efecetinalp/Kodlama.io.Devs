using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage
{
    public class DeleteProgrammingLanguageCommandValidator : AbstractValidator<DeleteProgrammingLanguageCommand>
    {
        public DeleteProgrammingLanguageCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
        }

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<DeleteProgrammingLanguageCommand> context, CancellationToken cancellation = default)
        {
            return context.InstanceToValidate == null
                ? new ValidationResult(new[] { new ValidationFailure(nameof(DeleteProgrammingLanguageCommand), $"{nameof(DeleteProgrammingLanguageCommand)} cannot be null") })
                : await base.ValidateAsync(context, cancellation);
        }
    }
}
