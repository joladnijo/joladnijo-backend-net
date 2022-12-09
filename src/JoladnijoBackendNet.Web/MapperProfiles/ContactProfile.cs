namespace JoladnijoBackendNet.Web.MapperProfiles;

public class ContactProfile : Profile
{
   public ContactProfile()
   {
      CreateMap<Contact, ContactDto>();
   }
}
