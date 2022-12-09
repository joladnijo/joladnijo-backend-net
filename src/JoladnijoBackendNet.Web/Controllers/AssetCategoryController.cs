using Microsoft.AspNetCore.Mvc;

namespace JoladnijoBackendNet.Web.Controllers;

[Route("api/asset-categories")]
[ApiController]
public class AssetCategoryController : ControllerBase
{
   private readonly ApplicationDbContext _dbContext;
   private readonly IMapper _mapper;

   public AssetCategoryController(ApplicationDbContext dbContext, IMapper mapper)
   {
      _dbContext = dbContext;
      _mapper = mapper;
   }

   [HttpGet]
   public async Task<ActionResult<IEnumerable<AssetCategoryDto>>> GetAllAsync() 
      => await _dbContext.AssetCategories.ProjectTo<AssetCategoryDto>(_mapper.ConfigurationProvider).ToListAsync();

   [HttpGet("{id}")]
   [ActionName(nameof(GetByIdAsync))]
   public async Task<ActionResult<AssetCategoryWithTypesDto>> GetByIdAsync(Guid id)
   {
      var result = await _dbContext.AssetCategories
         .Include(x => x.AssetTypes)
         .ProjectTo<AssetCategoryWithTypesDto>(_mapper.ConfigurationProvider)
         .FirstOrDefaultAsync(x => x.Id == id);

      if (result is null) return NotFound();
      return result;
   }

   [HttpPost]
   public async Task<ActionResult<AssetCategoryDto>> AddAsync(CreateAssetCategoryDto dto)
   {
      var entity = _mapper.Map<AssetCategory>(dto);
      _dbContext.Add(entity);
      await _dbContext.SaveChangesAsync();

      var ret = _mapper.Map<AssetCategoryDto>(entity);
      return CreatedAtAction(nameof(GetByIdAsync), new { id = ret.Id }, ret);
   }

   [HttpPut("{id}")]
   public async Task<ActionResult<AssetCategoryDto>> UpdateAsync(Guid id, CreateAssetCategoryDto dto)
   {
      var entity = await _dbContext.AssetCategories.FirstOrDefaultAsync(x => x.Id == id);
      if (entity is null) return NotFound();

      entity = _mapper.Map(dto, entity);
      await _dbContext.SaveChangesAsync();

      var ret = _mapper.Map<AssetCategoryDto>(entity);
      return Ok(ret);
   }

   [HttpDelete("{id}")]
   public async Task<ActionResult<AssetCategoryDto>> DeleteAsync(Guid id)
   {
      var entityToDelete = await _dbContext.AssetCategories.FirstOrDefaultAsync(x => x.Id == id);
      if (entityToDelete is null) return NotFound();

      _dbContext.Remove(entityToDelete);
      await _dbContext.SaveChangesAsync();

      var ret = _mapper.Map<AssetCategoryDto>(entityToDelete);
      return Ok(ret);
   }
}
