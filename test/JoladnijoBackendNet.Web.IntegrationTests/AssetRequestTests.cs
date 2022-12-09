using JoladnijoBackendNet.Web.Dtos;

namespace JoladnijoBackendNet.Web.IntegrationTests;

public class AssetRequestTests : IClassFixture<CustomWebApplicationFactory>
{
   private readonly CustomWebApplicationFactory _factory;

   public AssetRequestTests(CustomWebApplicationFactory factory) => _factory = factory;

   [Fact]
   public async Task CreateAssetRequest()
   {
      // arrange
      var client = _factory.CreateClient();
      var assetRequestDto = new CreateAssetRequestDto 
      { 
         Name = "Asset request 1", 
         Status = Entities.AssetRequestStatus.Urgent,
         
      };

      // create asset request
      var createAssetRequestResult = await client.PostAsJsonAsync("/api/asset-requests", assetRequestDto);
      var createAssetRequestResultBody = await createAssetRequestResult.Content.ReadFromJsonAsync<AssetRequestDto>();
      Assert.Equal(assetRequestDto.Name, createAssetRequestResultBody.Name);

      // check that asset request was created

      // check that feed item was created
   }
}
