namespace JoladnijoBackendNet.Web.Dtos;

public abstract class AssetTypeDtoBase
{
   public string Name { get; set; }
}

public class AssetTypeDto : AssetTypeDtoBase
{
   public Guid Id { get; set; }
}

public class CreateAssetTypeDto : AssetTypeDtoBase
{
}
