using Microsoft.AspNetCore.Mvc;

namespace JoladnijoBackendNet.Web.Controllers;

[Route("api/asset-requests")]
[ApiController]
public class AssetRequestsController : ControllerBase
{
   private readonly ApplicationDbContext _context;
   private readonly IMapper _mapper;

   public AssetRequestsController(ApplicationDbContext context, IMapper mapper)
   {
      _context = context;
      _mapper = mapper;
   }   

   // GET: api/AssetRequests/5
   [HttpGet("{id}")]
   public async Task<ActionResult<AssetRequestDto>> GetByIdAsync(Guid id)
   {
      var assetRequest = await _context.AssetRequests.FindAsync(id);

      if (assetRequest == null)
      {
         return NotFound();
      }

      return _mapper.Map<AssetRequestDto>(assetRequest);
   }

   [HttpPost]
   public async Task<ActionResult<AssetRequestDto>> AddAsync(CreateAssetRequestDto assetRequestDto)
   {
      var assetTypeEntity = await _context.AssetTypes.Include(x => x.AssetCategory).FirstOrDefaultAsync(x => x.Id == assetRequestDto.AssetTypeId);
      if (assetTypeEntity is null) return BadRequest("Invalid AssetTypeId");

      var assetRequestEntity = _mapper.Map<AssetRequest>(assetRequestDto);

      var feedItemEntity = new FeedItem 
      { 
         Name = assetRequestEntity.Name, 
         Icon = assetTypeEntity.AssetCategory.Icon, 
         StatusNew = assetRequestDto.Status, 
         StatusOld = assetRequestDto.Status 
      };
      assetRequestEntity.FeedItems = new List<FeedItem> { feedItemEntity };
      await _context.SaveChangesAsync();

      return _mapper.Map<AssetRequestDto>(assetRequestEntity);
   }
}
