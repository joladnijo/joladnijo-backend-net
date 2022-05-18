namespace JoladnijoBackendNet.Web.MapperProfiles;

public class AssetTypeProfile : Profile
{
   public AssetTypeProfile()
   {
      CreateMap<AssetType, AssetTypeDto>();
   }
}
