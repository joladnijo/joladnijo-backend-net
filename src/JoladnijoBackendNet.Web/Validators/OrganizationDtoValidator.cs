using System.Text.RegularExpressions;

namespace JoladnijoBackendNet.Web.Validators;

public class OrganizationDtoValidator : AbstractValidator<OrganizationDto>
{
   public OrganizationDtoValidator()
   {
      RuleFor(x => x.Name).NotEmpty().MaximumLength(255);
      RuleFor(x => x.Slug).NotEmpty().MaximumLength(255).Matches(new Regex("^[a-z0-9\\-]+$"));
   }
}
