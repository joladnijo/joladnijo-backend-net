using AutoMapper;

namespace JoladnijoBackendNet.Web.MapperProfiles
{
   public class OrganizationProfile : Profile
   {
      public OrganizationProfile()
      {
         CreateMap<Organization, OrganizationDto>();
         CreateMap<OrganizationDto, Organization>();
      }
   }
}
