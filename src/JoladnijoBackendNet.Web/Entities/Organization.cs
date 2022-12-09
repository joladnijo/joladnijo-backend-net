using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JoladnijoBackendNet.Web.Entities;

public abstract class OrganizationBase
{
   public string Name { get; set; }
   public string Slug { get; set; }   
}

public class Organization : OrganizationBase
{
   public Guid Id { get; set; }
   public Guid? ContactId { get; set; }
   public Contact Contact { get; set; }
}

public class OrganizationConfiguration : IEntityTypeConfiguration<Organization>
{
   public void Configure(EntityTypeBuilder<Organization> builder)
   {
      builder.HasIndex(x => x.Name).IsUnique();
      builder.HasIndex(x => x.Slug).IsUnique();

      builder.Property(x => x.Name).IsRequired();
      builder.Property(x => x.Slug).IsRequired();
   }
}
