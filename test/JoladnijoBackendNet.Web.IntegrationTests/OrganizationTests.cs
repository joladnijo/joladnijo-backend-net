using System.Net;
using JoladnijoBackendNet.Web.Entities;

namespace JoladnijoBackendNet.Web.IntegrationTests
{
   public class OrganizationTests : IClassFixture<CustomWebApplicationFactory>
   {
      private readonly CustomWebApplicationFactory _factory;

      public OrganizationTests(CustomWebApplicationFactory factory) => _factory = factory;


      [Fact]
      public async Task AddUpdateDelete()
      {
         // Arrange
         var client = _factory.CreateClient();

         // Act
         // Get initial list
         var initialList = await client.GetFromJsonAsync<IEnumerable<Organization>>("/api/organizations");         

         Assert.Empty(initialList);

         // Add Organization
         var addInputOrganization = new Organization { Name = "Organization name 1", Slug = "org-name-1" };
         var addResponse = await client.PostAsJsonAsync("/api/organizations", addInputOrganization);

         Assert.Equal(HttpStatusCode.Created, addResponse.StatusCode);
         Assert.Equal("http://localhost/api/organizations/org-name-1", addResponse.Headers.Location.ToString().ToLower());

         var addOutputOrganization = await addResponse.Content.ReadFromJsonAsync<Organization>();
         
         Assert.Equal(addOutputOrganization.Name, addInputOrganization.Name);
         Assert.Equal(addOutputOrganization.Slug, addInputOrganization.Slug);

         // Update Organization
         var updateInputOrganization = new Organization { Name = "Organization name 2", Slug = "org-name-2" };
         var updateResponse = await client.PutAsJsonAsync($"/api/organizations/{addInputOrganization.Slug}", updateInputOrganization);

         Assert.Equal(HttpStatusCode.OK, updateResponse.StatusCode);

         var updateOutputOrganization = await updateResponse.Content.ReadFromJsonAsync<Organization>();

         Assert.Equal(addOutputOrganization.Id, updateOutputOrganization.Id);
         Assert.Equal(updateOutputOrganization.Name, updateInputOrganization.Name);
         Assert.Equal(updateInputOrganization.Slug, updateOutputOrganization.Slug);

         // Delete Organization
         var deleteResponse = await client.DeleteAsync($"/api/organizations/{updateInputOrganization.Slug}");

         Assert.Equal(HttpStatusCode.OK, deleteResponse.StatusCode);

         var deleteOutputOrganization = await deleteResponse.Content.ReadFromJsonAsync<Organization>();

         Assert.Equal(addOutputOrganization.Id, deleteOutputOrganization.Id);
         Assert.Equal(updateInputOrganization.Name, deleteOutputOrganization.Name);
         Assert.Equal(updateInputOrganization.Slug, deleteOutputOrganization.Slug);

         // Check that resource is deleted
         var checkResource = await client.GetAsync($"/api/organizations/{updateOutputOrganization.Slug}");
         Assert.Equal(HttpStatusCode.NotFound, checkResource.StatusCode);
      }

      [Fact]
      public async Task When_update_nonexistent_Then_return_NotFound()
      {
         // arrange
         var updateInputOrganization = new Organization { Name = "Organization name 2", Slug = "org-name-2" };
         var client = _factory.CreateClient();
         
         // act
         var updateResponse = await client.PutAsJsonAsync($"/api/organizations/non-existent-org", updateInputOrganization);

         // assert
         Assert.Equal(HttpStatusCode.NotFound, updateResponse.StatusCode);
      }

      [Fact]
      public async Task When_delete_nonexistent_Then_return_NotFound()
      {
         // arrange         
         var client = _factory.CreateClient();

         // act
         var updateResponse = await client.DeleteAsync($"/api/organizations/non-existent-org");

         // assert
         Assert.Equal(HttpStatusCode.NotFound, updateResponse.StatusCode);
      }
   }
}
