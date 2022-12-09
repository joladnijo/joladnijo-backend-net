using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JoladnijoBackendNet.Web.Entities;

public class AssetType
{
   public Guid Id { get; set; }
   public string Name { get; set; }
   public Guid AssetCategoryId { get; set; }
   public AssetCategory AssetCategory { get; set; }
   public List<AssetRequest> AssetRequests { get; set; }
}

public class AssetTypeConfiguration : IEntityTypeConfiguration<AssetType>
{
   public void Configure(EntityTypeBuilder<AssetType> builder)
   {
      builder.HasIndex(x => x.Name).IsUnique();
   }
}
