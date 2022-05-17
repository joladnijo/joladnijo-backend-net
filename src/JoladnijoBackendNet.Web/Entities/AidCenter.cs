using NetTopologySuite.Geometries;

namespace JoladnijoBackendNet.Web.Entities;

public class AidCenter
{
   public Guid Id { get; set; }
   public string Name { get; set; }
   public string Slug { get; set; }
   //public byte[] Photo { get; set; }
   public Organization Organization { get; set; }
   public Guid OrganizationId { get; set; }
   public string CountryCode { get; set; }
   public string PostalCode { get; set; }
   public string City { get; set; }
   public string Address { get; set; }
   public Point GeoLocation { get; set; }
   public AidCenterCallRequired CallRequired { get; set; }
   public DateOnly CampaignEndingOn { get; set; }
}

public enum AidCenterCallRequired
{
   Required,
   Suggested,
   Denied
}
