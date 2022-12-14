using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage
{
    public class CreateProgrammingLanguageCommandValidator : AbstractValidator<CreateProgrammingLanguageCommand>
    {
        public CreateProgrammingLanguageCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
        }
        
        public override async Task<ValidationResult> ValidateAsync(ValidationContext<CreateProgrammingLanguageCommand> context, CancellationToken cancellation = default)
        {
            return context.InstanceToValidate == null
                ? new ValidationResult(new[] { new ValidationFailure(nameof(CreateProgrammingLanguageCommand), $"{nameof(CreateProgrammingLanguageCommand)} cannot be null") })
                : await base.ValidateAsync(context, cancellation);
        }
    }
}
