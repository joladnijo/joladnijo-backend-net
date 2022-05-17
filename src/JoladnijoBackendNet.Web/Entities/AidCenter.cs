using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetTopologySuite.Geometries;

namespace JoladnijoBackendNet.Web.Entities;

public class AidCenter
{
   public Guid Id { get; set; }
   public string Name { get; set; }
   public string Slug { get; set; }
   //public byte[] Photo { get; set; }
   public Guid OrganizationId { get; set; }
   public Organization Organization { get; set; }
   public string CountryCode { get; set; }
   public string PostalCode { get; set; }
   public string City { get; set; }
   public string Address { get; set; }
   public Point GeoLocation { get; set; }
   public AidCenterCallRequired? CallRequired { get; set; }
   public DateOnly? CampaignEndingOn { get; set; }
   public Guid ContactId { get; set; }
   public Contact Contact { get; set; }
   public List<AssetRequest> AssetRequests { get; set; }
}

public enum AidCenterCallRequired
{
   Required = 1,
   Suggested = 2,
   Denied = 3
}

public class AidCenterConfiguration : IEntityTypeConfiguration<AidCenter>
{
   public void Configure(EntityTypeBuilder<AidCenter> builder)
   {
      builder.HasIndex(x => x.Slug).IsUnique();

      builder.Property(x => x.CountryCode).HasMaxLength(5).IsRequired();
      builder.Property(x => x.PostalCode).HasMaxLength(10).IsRequired();
      builder.Property(x => x.City).HasMaxLength(50).IsRequired();
      builder.Property(x => x.Address).IsRequired();
      builder.Property(x => x.CallRequired)
         .HasConversion<string>()
         .HasDefaultValue(AidCenterCallRequired.Suggested);
   }
}
