namespace JoladnijoBackendNet.Web.Services;

public class OrganizationsService
{
   private readonly ApplicationDbContext _dbContext;
   private readonly IMapper _mapper;

   public OrganizationsService(ApplicationDbContext dbContext, IMapper mapper)
   {
      _dbContext = dbContext;
      _mapper = mapper;
   }

   public async Task<IEnumerable<OrganizationDto>> GetAllAsync() => await _dbContext.Organizations.ProjectTo<OrganizationDto>(_mapper.ConfigurationProvider).ToListAsync();
   public async Task<OrganizationDto> GetBySlugAsync(string slug) => await _dbContext.Organizations.ProjectTo<OrganizationDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(x => x.Slug == slug);

   public async Task<OrganizationDto> AddAsync(OrganizationDto dto)
   {
      var entity = _mapper.Map<OrganizationDto, Organization>(dto);
      _dbContext.Add(entity);
      await _dbContext.SaveChangesAsync();
      return dto;
   }
   
   public async Task<OrganizationDto> UpdateAsync(string slug, OrganizationDto dto)
   {
      var entity = await _dbContext.Organizations.FirstOrDefaultAsync(x => x.Slug == slug);
      if (entity is null) return null;

      entity = _mapper.Map(dto, entity);
      await _dbContext.SaveChangesAsync();

      return dto;
   }

   public async Task<OrganizationDto> DeleteAsync(string slug)
   {
      var modelToDelete = await _dbContext.Organizations.FirstOrDefaultAsync(x => x.Slug == slug);
      if (modelToDelete == null) return null;

      _dbContext.Remove(modelToDelete);
      await _dbContext.SaveChangesAsync();
      return _mapper.Map<OrganizationDto>(modelToDelete);
   }
}
