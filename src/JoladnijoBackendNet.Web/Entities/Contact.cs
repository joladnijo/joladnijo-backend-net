namespace JoladnijoBackendNet.Web.Entities;
public class Contact
{
   public Guid Id { get; set; }
   public string Name { get; set; }
   public string Email { get; set; }
   public string Phone { get; set; }
   public string Facebook { get; set; }
   public string Url { get; set; }
   public Organization Organization { get; set; }
   public Guid OrganizationId { get; set; }
   public AidCenter AidCenter { get; set; }
   public Guid AidCenterId { get; set; }
}
