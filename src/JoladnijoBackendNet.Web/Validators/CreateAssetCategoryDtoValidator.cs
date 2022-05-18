namespace JoladnijoBackendNet.Web.Validators;

public class CreateAssetCategoryDtoValidator : AbstractValidator<CreateAssetCategoryDto>
{
   public CreateAssetCategoryDtoValidator()
   {
      RuleFor(x => x.Name).NotEmpty().MaximumLength(255);
      RuleFor(x => x.Icon).NotEmpty().MaximumLength(255);
   }
}
