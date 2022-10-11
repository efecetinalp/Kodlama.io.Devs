using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SocialMedias.Commands.DeleteSocialMedia
{
    public class DeleteSocialMediaCommandValidator : AbstractValidator<DeleteSocialMediaCommand>
    {
        public DeleteSocialMediaCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
        }

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<DeleteSocialMediaCommand> context, CancellationToken cancellation = default)
        {
            return context.InstanceToValidate == null
                ? new ValidationResult(new[] { new ValidationFailure(nameof(DeleteSocialMediaCommand), $"{nameof(DeleteSocialMediaCommand)} cannot be null") })
                : await base.ValidateAsync(context, cancellation);
        }
    }
}
