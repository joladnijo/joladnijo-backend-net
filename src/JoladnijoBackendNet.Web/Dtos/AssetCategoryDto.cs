namespace JoladnijoBackendNet.Web.Dtos;

public abstract class AssetCategoryDtoBase
{
   public string Name { get; set; }
   public string Icon { get; set; }
}

public class AssetCategoryDto : AssetCategoryDtoBase
{
   public Guid Id { get; set; }
}

public class AssetCategoryWithTypesDto
{
   public Guid Id { get; set; }
   public List<AssetType> AssetTypes { get; set; }
}

public class CreateAssetCategoryDto : AssetCategoryDtoBase
{
}
