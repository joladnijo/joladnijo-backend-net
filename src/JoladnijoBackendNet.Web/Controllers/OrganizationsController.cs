using Microsoft.AspNetCore.Mvc;

namespace JoladnijoBackendNet.Web.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class OrganizationsController : ControllerBase
   {
      private readonly OrganizationsService _service;

      public OrganizationsController(OrganizationsService service)
      {
         _service = service;
      }

      [HttpGet]
      public async Task<IEnumerable<Organization>> GetAllAsync() => await _service.GetAllAsync();

      [HttpGet("{slug}")]
      [ActionName(nameof(GetBySlugAsync))]
      public async Task<ActionResult<Organization>> GetBySlugAsync(string slug)
      {
         var result = await _service.GetBySlugAsync(slug);
         if (result is null) return NotFound();
         return Ok(result);
      }

      [HttpPost]
      public async Task<ActionResult<Organization>> AddAsync(Organization organization)
      {
         var result = await _service.AddAsync(organization);
         return CreatedAtAction(nameof(GetBySlugAsync), new { slug = result.Slug }, result);
      }

      [HttpPut("{slug}")]
      public async Task<ActionResult<Organization>> UpdateAsync(string slug, Organization organization) { 
         var result = await _service.UpdateAsync(slug, organization);
         if (result is null) return NotFound();
         return Ok(result);
      }

      [HttpDelete("{slug}")]
      public async Task<ActionResult<Organization>> DeleteAsync(string slug)
      { 
         var result = await _service.DeleteAsync(slug);
         if (result is null) return NotFound();
         return Ok(result);
      }
   }
}
