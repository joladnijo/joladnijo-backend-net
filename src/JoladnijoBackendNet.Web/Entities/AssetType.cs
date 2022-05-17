namespace JoladnijoBackendNet.Web.Entities;

public class AssetType
{
   public Guid Id { get; set; }
   public string Name { get; set; }
   public AssetCategory AssetCategory { get; set; }
   public Guid AssetCategoryId { get; set; }
}