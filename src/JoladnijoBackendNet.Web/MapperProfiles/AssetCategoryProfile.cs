namespace JoladnijoBackendNet.Web.MapperProfiles;

public class AssetCategoryProfile : Profile
{
   public AssetCategoryProfile()
   {
      CreateMap<AssetCategory, AssetCategoryDto>();
      CreateMap<AssetCategory, AssetCategoryWithTypesDto>();

      CreateMap<CreateAssetCategoryDto, AssetCategory>();
   }
}
