using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JoladnijoBackendNet.Web.Entities;
public class AssetRequest
{
   public Guid Id { get; set; }
   public string Name { get; set; }
   public AssetRequestStatus Status { get; set; }

   public Guid AidCenterId { get; set; }
   public AidCenter AidCenter { get; set; }
   public Guid AssetTypeId { get; set; }
   public AssetType AssetType { get; set; }
   public List<FeedItem> FeedItems { get; set; }
}

public enum AssetRequestStatus
{
   Requested,
   Urgent,
   Fulfilled
}

public class AssetRequestConfiguration : IEntityTypeConfiguration<AssetRequest>
{
   public void Configure(EntityTypeBuilder<AssetRequest> builder)
   {
      builder.Property(x => x.Status)
         .HasConversion<string>()
         .HasDefaultValue(AssetRequestStatus.Requested)
         .IsRequired();
   }
}
