using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologies.Commands.CreateTechnology
{
    public class CreateTechnologyCommandValidator : AbstractValidator<CreateTechnologyCommand>
    {
        public CreateTechnologyCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
        }

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<CreateTechnologyCommand> context, CancellationToken cancellation = default)
        {
            return context.InstanceToValidate == null
                ? new ValidationResult(new[] { new ValidationFailure(nameof(CreateTechnologyCommand), $"{nameof(CreateTechnologyCommand)} cannot be null") })
                : await base.ValidateAsync(context, cancellation);
        }
    }
}
