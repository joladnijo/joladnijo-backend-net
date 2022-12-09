namespace JoladnijoBackendNet.Web.Dtos;

public abstract class AssetRequestDtoBase
{
   public string Name { get; set; }
   public AssetRequestStatus Status { get; set; }
}

public class CreateAssetRequestDto : AssetRequestDtoBase
{
   public Guid AidCenterId { get; set; }
   public Guid AssetTypeId { get; set; }
}

public class AssetRequestDto : AssetRequestDtoBase
{
   public Guid Id { get; set; }
}
