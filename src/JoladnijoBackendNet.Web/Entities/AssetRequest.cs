namespace JoladnijoBackendNet.Web.Entities;
public class AssetRequest
{
   public Guid Id { get; set; }
   public string Name { get; set; }
   public AssetType AssetType { get; set; }
   public Guid AssetTypeId { get; set; }
   public AssetRequestStatus Status { get; set; }
}

public enum AssetRequestStatus
{
   Requested,
   Urgent,
   Fulfilled
}