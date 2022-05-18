namespace JoladnijoBackendNet.Web.Dtos;

public class ContactDtoBase
{
   public string Name { get; set; }
   public string Email { get; set; }
   public string Phone { get; set; }
   public string Facebook { get; set; }
   public string Url { get; set; }
}

public class ContactDto : ContactDtoBase
{
   public Guid Id { get; set; }
}

public class CreateContactDto : ContactDtoBase
{
}
