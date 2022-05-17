namespace JoladnijoBackendNet.Web.Services;

public class OrganizationsService
{
   private readonly ApplicationDbContext _dbContext;

   public OrganizationsService(ApplicationDbContext dbContext)
   {
      _dbContext = dbContext;
   }

   public async Task<IEnumerable<Organization>> GetAllAsync() => await _dbContext.Organizations.ToListAsync();
   public async Task<Organization> GetBySlugAsync(string slug) => await _dbContext.Organizations.FirstOrDefaultAsync(x => x.Slug == slug);

   public async Task<Organization> AddAsync(Organization organization)
   {
      _dbContext.Add(organization);
      await _dbContext.SaveChangesAsync();
      return organization;
   }
   
   public async Task<Organization> UpdateAsync(string slug, Organization organization)
   {
      var modelBySlug = await _dbContext.Organizations.AsNoTracking().Select(x => new { x.Id, x.Slug }).FirstOrDefaultAsync(x => x.Slug == slug);
      if (modelBySlug is null) return null;

      organization.Id = modelBySlug.Id;

      _dbContext.Update(organization);
      await _dbContext.SaveChangesAsync();
      return organization;
   }

   public async Task<Organization> DeleteAsync(string slug)
   {
      var modelToDelete = await _dbContext.Organizations.FirstOrDefaultAsync(x => x.Slug == slug);
      if (modelToDelete == null) return null;

      _dbContext.Remove(modelToDelete);
      await _dbContext.SaveChangesAsync();
      return modelToDelete;
   }
}
