using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SocialMedias.Commands.CreateSocialMedia
{
    public class CreateSocialMediaCommandValidator : AbstractValidator<CreateSocialMediaCommand>
    {
        public CreateSocialMediaCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
        }

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<CreateSocialMediaCommand> context, CancellationToken cancellation = default)
        {
            return context.InstanceToValidate == null
                ? new ValidationResult(new[] { new ValidationFailure(nameof(CreateSocialMediaCommand), $"{nameof(CreateSocialMediaCommand)} cannot be null") })
                : await base.ValidateAsync(context, cancellation);
        }
    }
}
