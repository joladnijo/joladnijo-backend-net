using System.Collections;
using System.Net;
using JoladnijoBackendNet.Web.Dtos;

namespace JoladnijoBackendNet.Web.IntegrationTests;

public class OrganizationTests : IClassFixture<CustomWebApplicationFactory>
{
   private const string ApiRoute = "/api/organizations";
   private readonly CustomWebApplicationFactory _factory;

   public OrganizationTests(CustomWebApplicationFactory factory) => _factory = factory;

   [Fact]
   public async Task AddUpdateDelete()
   {
      // Arrange
      var client = _factory.CreateClient();

      // Act
      // Get initial list
      var initialList = await client.GetFromJsonAsync<IEnumerable<OrganizationDto>>(ApiRoute);         

      Assert.Empty(initialList);

      // Add Organization
      var addInputOrganization = new OrganizationDto { Name = "Organization name 1", Slug = "org-name-1" };
      var addResponse = await client.PostAsJsonAsync(ApiRoute, addInputOrganization);

      Assert.Equal(HttpStatusCode.Created, addResponse.StatusCode);
      Assert.Equal("http://localhost/api/organizations/org-name-1", addResponse.Headers.Location.ToString().ToLower());

      var addOutputOrganization = await addResponse.Content.ReadFromJsonAsync<OrganizationDto>();
      
      Assert.Equal(addOutputOrganization.Name, addInputOrganization.Name);
      Assert.Equal(addOutputOrganization.Slug, addInputOrganization.Slug);

      // Update Organization
      var updateInputOrganization = new OrganizationDto { Name = "Organization name 2", Slug = "org-name-2" };
      var updateResponse = await client.PutAsJsonAsync($"{ApiRoute}/{addInputOrganization.Slug}", updateInputOrganization);

      Assert.Equal(HttpStatusCode.OK, updateResponse.StatusCode);

      var updateOutputOrganization = await updateResponse.Content.ReadFromJsonAsync<OrganizationDto>();

      Assert.Equal(updateOutputOrganization.Name, updateInputOrganization.Name);
      Assert.Equal(updateInputOrganization.Slug, updateOutputOrganization.Slug);

      // Delete Organization
      var deleteResponse = await client.DeleteAsync($"{ApiRoute}/{updateInputOrganization.Slug}");

      Assert.Equal(HttpStatusCode.OK, deleteResponse.StatusCode);

      var deleteOutputOrganization = await deleteResponse.Content.ReadFromJsonAsync<OrganizationDto>();

      Assert.Equal(updateInputOrganization.Name, deleteOutputOrganization.Name);
      Assert.Equal(updateInputOrganization.Slug, deleteOutputOrganization.Slug);

      // Check that resource is deleted
      var checkResource = await client.GetAsync($"{ApiRoute}/{updateOutputOrganization.Slug}");
      Assert.Equal(HttpStatusCode.NotFound, checkResource.StatusCode);
   }

   [Fact]
   public async Task When_update_nonexistent_Then_return_NotFound()
   {
      // arrange
      var updateInputOrganization = new OrganizationDto { Name = "Organization name 2", Slug = "org-name-2" };
      var client = _factory.CreateClient();
      
      // act
      var updateResponse = await client.PutAsJsonAsync($"{ApiRoute}/non-existent-org", updateInputOrganization);

      // assert
      Assert.Equal(HttpStatusCode.NotFound, updateResponse.StatusCode);
   }

   [Fact]
   public async Task When_delete_nonexistent_Then_return_NotFound()
   {
      // arrange         
      var client = _factory.CreateClient();

      // act
      var updateResponse = await client.DeleteAsync($"{ApiRoute}/non-existent-org");

      // assert
      Assert.Equal(HttpStatusCode.NotFound, updateResponse.StatusCode);
   }

   [Theory]
   [ClassData(typeof(InvalidOrganizationDtosTestData))]
   public async Task When_invalid_input_Then_return_BadRequest(OrganizationDto invalidModel)
   {
      // arrange
      var client = _factory.CreateClient();

      // act
      var response = await client.PostAsJsonAsync(ApiRoute, invalidModel);

      // assert
      Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
   }
}

public class InvalidOrganizationDtosTestData : IEnumerable<object[]>
{
   public IEnumerator<object[]> GetEnumerator()
   {
      yield return new object[] { new OrganizationDto { Slug = "slug-1" } }; // Name is missing
      yield return new object[] { new OrganizationDto { Name = "name 1" } }; // Slug is missing
      yield return new object[] { new OrganizationDto { Name = "", Slug = "slug-1" } }; // Empty Name
      yield return new object[] { new OrganizationDto { Name = "name 1", Slug = "" } }; // Empty Slug
      yield return new object[] { new OrganizationDto { Name = "name 1", Slug = "slug-1-#" } }; // No special characters in Slug
   }

   IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
