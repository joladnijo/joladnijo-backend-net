using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JoladnijoBackendNet.Web.Entities;

public abstract class ContactBase
{
   public string Name { get; set; }
   public string Email { get; set; }
   public string Phone { get; set; }
   public string Facebook { get; set; }
   public string Url { get; set; }
}

public class Contact : ContactBase
{
   public Guid Id { get; set; }   
   public Organization Organization { get; set; }
   public AidCenter AidCenter { get; set; }
}

public class ContactConfiguration : IEntityTypeConfiguration<Contact>
{
   public void Configure(EntityTypeBuilder<Contact> builder)
   {
      builder.Property(x => x.Phone).HasMaxLength(20).IsRequired();      
   }
}
