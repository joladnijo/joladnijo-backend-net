using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JoladnijoBackendNet.Web.Entities;

public class AssetCategory
{
   public Guid Id { get; set; }
   public string Name { get; set; }
   public string Icon { get; set; }
   public List<AssetType> AssetTypes { get; set; }
}

public class AssetCategoryConfiguration : IEntityTypeConfiguration<AssetCategory>
{
   public void Configure(EntityTypeBuilder<AssetCategory> builder)
   {
      builder.HasIndex(x => x.Name).IsUnique();
      builder.Property(x => x.Icon).HasMaxLength(50).IsRequired(false);

      builder.Property(x => x.Name).IsRequired();
   }
}
