using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JoladnijoBackendNet.Web.Entities;

public class Organization
{
   public Guid Id { get; set; }
   public string Name { get; set; }
   public string Slug { get; set; }
}

public class OrganizationConfiguration : IEntityTypeConfiguration<Organization>
{
   public void Configure(EntityTypeBuilder<Organization> builder)
   {
      builder.HasIndex(x => x.Slug);
   }
}
