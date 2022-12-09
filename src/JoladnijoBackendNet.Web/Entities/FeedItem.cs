namespace JoladnijoBackendNet.Web.Entities;

public class FeedItem
{
   public Guid Id { get; set; }
   public string Name { get; set; }
   public string Icon { get; set; }
   public DateTime Timestamp { get; set; }
   public AssetRequestStatus StatusOld { get; set; }
   public AssetRequestStatus StatusNew { get; set; }
   public string User { get; set; }
   public Guid? AssetRequestId { get; set; }
   public AssetRequest AssetRequest { get; set; }
   public Guid AidCenterId { get; set; }
   public AidCenter AidCenter { get; set; }
}
