using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SocialMedias.Commands.UpdateSocialMedia
{
    public class UpdateSocialMediaCommandValidator : AbstractValidator<UpdateSocialMediaCommand>
    {
        public UpdateSocialMediaCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
        }

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<UpdateSocialMediaCommand> context, CancellationToken cancellation = default)
        {
            return context.InstanceToValidate == null
                ? new ValidationResult(new[] { new ValidationFailure(nameof(UpdateSocialMediaCommand), $"{nameof(UpdateSocialMediaCommand)} cannot be null") })
                : await base.ValidateAsync(context, cancellation);
        }
    }
}
