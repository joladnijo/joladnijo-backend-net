using System.Net;
using JoladnijoBackendNet.Web.Entities;
using Microsoft.AspNetCore.Mvc.Testing;

namespace JoladnijoBackendNet.Web.IntegrationTests;

public class ContactTests : IClassFixture<CustomWebApplicationFactory>
{
   private readonly CustomWebApplicationFactory _factory;

   public ContactTests(CustomWebApplicationFactory factory) => _factory = factory;

   [Fact]
   public async Task Test1()
   {
      // arrange
      var client = _factory.CreateClient();

      // Get initial
      // act
      var response = await client.GetAsync("/api/contacts");      

      // assert
      Assert.Equal(HttpStatusCode.OK, response.StatusCode);


      // Insert
      await client.PostAsJsonAsync("/api/contacts", new Contact { });
   }
}
