namespace JoladnijoBackendNet.Web.Dtos;

public class ContactDto : ContactBase
{
   public Guid Id { get; set; }
}

public class CreateContactDto : ContactBase
{
}
