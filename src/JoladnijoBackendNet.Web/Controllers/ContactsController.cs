using JoladnijoBackendNet.Web.Entities;
using JoladnijoBackendNet.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace JoladnijoBackendNet.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContactsController : ControllerBase
{
   private readonly ContactsService _service;

   public ContactsController(ContactsService service)
   {
      _service = service;
   }

   [HttpGet]
   public async Task<ActionResult<IEnumerable<Contact>>> GetAllAsync()
   {
      var result = await _service.GetAllAsync();
      return Ok(result);
   }

   [HttpGet("{id}")]
   public async Task<ActionResult<Contact>> GetByIdAsync(Guid id)
   {
      var result = await _service.GetByIdAsync(id);
      if (result is null) return NotFound(id);
      return Ok(result);
   }

   [HttpPost]
   public async Task<ActionResult<Contact>> AddAsync(Contact contact)
   {
      var result = await _service.AddAsync(contact);
      return CreatedAtAction(nameof(GetByIdAsync), new { id = contact.Id }, contact);
   }

   [HttpPut("{id}")]
   public async Task<ActionResult<Contact>> UpdateAsync(Guid id, Contact contact)
   {
      contact.Id = id;
      var result = await _service.UpdateAsync(contact);
      if (result is null) return NotFound(contact);
      return Ok(result);
   }
}
