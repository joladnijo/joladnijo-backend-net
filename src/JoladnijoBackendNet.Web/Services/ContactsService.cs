namespace JoladnijoBackendNet.Web.Services;

public class ContactsService
{
   private readonly ApplicationDbContext _dbContext;

   public ContactsService(ApplicationDbContext dbContext)
   {
      _dbContext = dbContext;
   }

   public async Task<IEnumerable<Contact>> GetAllAsync() => await _dbContext.Contacts.ToListAsync();

   public async Task<Contact> GetByIdAsync(Guid id) => await _dbContext.Contacts.FirstOrDefaultAsync(x => x.Id == id);

   public async Task<Contact> AddAsync(Contact contact)
   {
      _dbContext.Add(contact);
      await _dbContext.SaveChangesAsync();
      return contact;
   }

   public async Task<Contact> UpdateAsync(Contact contact)
   {
      _dbContext.Update(contact);
      await _dbContext.SaveChangesAsync();
      return contact;
   }

   public async Task<Contact> DeleteAsync(Guid id)
   {
      var modelToDelete = await _dbContext.Contacts.FirstOrDefaultAsync(x => x.Id == id);
      if (modelToDelete == null) return null;

      _dbContext.Remove(modelToDelete);
      await _dbContext.SaveChangesAsync();
      return modelToDelete;
   }

}
