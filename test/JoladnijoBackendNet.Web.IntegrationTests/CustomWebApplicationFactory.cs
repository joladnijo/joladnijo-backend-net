using JoladnijoBackendNet.Web.Entities;
using Microsoft.AspNetCore.Mvc.Testing;

namespace JoladnijoBackendNet.Web.IntegrationTests;

public class CustomWebApplicationFactory : WebApplicationFactory<Program>
{
   protected override void ConfigureWebHost(IWebHostBuilder builder)
   {
      builder.ConfigureServices(services =>
      {
         var sp = services.BuildServiceProvider();

         using var scope = sp.CreateScope();
         var scopedServices = scope.ServiceProvider;
         var db = scopedServices.GetRequiredService<ApplicationDbContext>();

         db.Database.EnsureDeleted();
         db.Database.EnsureCreated();
      });
   }
}
