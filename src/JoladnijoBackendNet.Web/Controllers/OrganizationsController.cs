using Microsoft.AspNetCore.Mvc;

namespace JoladnijoBackendNet.Web.Controllers
{
   [Route("api/organizations")]
   [ApiController]
   public class OrganizationsController : ControllerBase
   {
      private readonly ApplicationDbContext _dbContext;
      private readonly IMapper _mapper;

      public OrganizationsController(ApplicationDbContext dbContext, IMapper mapper)
      {
         _dbContext = dbContext;
         _mapper = mapper;
      }

      [HttpGet]
      public async Task<IEnumerable<OrganizationDto>> GetAllAsync() => 
         await _dbContext.Organizations
         .ProjectTo<OrganizationDto>(_mapper.ConfigurationProvider)
         .ToListAsync();

      [HttpGet("{slug}")]
      [ActionName(nameof(GetBySlugAsync))]
      public async Task<ActionResult<OrganizationDto>> GetBySlugAsync(string slug)
      {
         var result = await _dbContext.Organizations.ProjectTo<OrganizationDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(x => x.Slug == slug);
         if (result is null) return NotFound();
         return Ok(result);
      }

      [HttpPost]
      public async Task<ActionResult<OrganizationDto>> AddAsync(OrganizationDto dto)
      {
         var entity = _mapper.Map<OrganizationDto, Organization>(dto);
         _dbContext.Add(entity);
         await _dbContext.SaveChangesAsync();

         var ret = _mapper.Map<OrganizationDto>(entity);
         return CreatedAtAction(nameof(GetBySlugAsync), new { slug = ret.Slug }, ret);
      }

      [HttpPut("{slug}")]
      public async Task<ActionResult<OrganizationDto>> UpdateAsync(string slug, OrganizationDto dto) {
         var entity = await _dbContext.Organizations.FirstOrDefaultAsync(x => x.Slug == slug);
         if (entity is null) return NotFound();

         entity = _mapper.Map(dto, entity);
         await _dbContext.SaveChangesAsync();

         var ret = _mapper.Map<OrganizationDto>(entity);         
         return Ok(ret);
      }

      [HttpDelete("{slug}")]
      public async Task<ActionResult<Organization>> DeleteAsync(string slug)
      {
         var entityToDelete = await _dbContext.Organizations.FirstOrDefaultAsync(x => x.Slug == slug);
         if (entityToDelete == null) return NotFound();

         _dbContext.Remove(entityToDelete);
         await _dbContext.SaveChangesAsync();

         var ret = _mapper.Map<OrganizationDto>(entityToDelete);
         return Ok(ret);
      }
   }
}
