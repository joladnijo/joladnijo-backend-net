using Microsoft.AspNetCore.Mvc;

namespace JoladnijoBackendNet.Web.Controllers;

[Route("api/contacts")]
[ApiController]
public class ContactsController : ControllerBase
{
   private readonly ApplicationDbContext _dbContext;
   private readonly IMapper _mapper;

   public ContactsController(ApplicationDbContext dbContext, IMapper mapper)
   {
      _dbContext = dbContext;
      _mapper = mapper;
   }

   [HttpGet]
   public async Task<IEnumerable<ContactDto>> GetAllAsync() 
      => await _dbContext.Contacts
      .ProjectTo<ContactDto>(_mapper.ConfigurationProvider)
      .ToListAsync();

   [HttpGet("{id}")]
   public async Task<ActionResult<ContactDto>> GetByIdAsync(Guid id)
   {
      var entity = await _dbContext.Contacts.FirstOrDefaultAsync(x => x.Id == id);
      if (entity is null) return NotFound();

      return _mapper.Map<ContactDto>(entity);
   }

   [HttpPost]
   public async Task<ActionResult<ContactDto>> AddAsync(CreateContactDto dto)
   {
      var entity = _mapper.Map<Contact>(dto);

      _dbContext.Add(entity);
      var result = await _dbContext.SaveChangesAsync();

      var ret = _mapper.Map<ContactDto>(entity);
      return CreatedAtAction(nameof(GetByIdAsync), new { id = ret.Id }, ret);
   }

   [HttpPut("{id}")]
   public async Task<ActionResult<ContactDto>> UpdateAsync(Guid id, CreateContactDto dto)
   {
      var entity = await _dbContext.Contacts.FirstOrDefaultAsync(x => x.Id == id);
      if (entity is null) return NotFound();

      entity = _mapper.Map(dto, entity);
      await _dbContext.SaveChangesAsync();

      return _mapper.Map<ContactDto>(entity);
   }

   [HttpDelete("{id}")]
   public async Task<ActionResult<ContactDto>> DeleteAsync(Guid id)
   {
      var entityToDelete = await _dbContext.Contacts.FirstOrDefaultAsync(x => x.Id == id);
      if (entityToDelete is null) return NotFound();

      _dbContext.Remove(entityToDelete);
      await _dbContext.SaveChangesAsync();

      return _mapper.Map<ContactDto>(entityToDelete);
   }
}
