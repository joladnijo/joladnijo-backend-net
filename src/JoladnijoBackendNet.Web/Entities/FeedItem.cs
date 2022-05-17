namespace JoladnijoBackendNet.Web.Entities;

public class FeedItem
{
   public Guid Id { get; set; }
   public string Name { get; set; }
   public string Icon { get; set; }
   public DateTime Timestamp { get; set; }
   public AssetRequest AssetRequest { get; set; }
   public AidCenter AidCenter { get; set; }
   public string StatusOld { get; set; }
   public string StatusNew { get; set; }
   public string User { get; set; }
}
