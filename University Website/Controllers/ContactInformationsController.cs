using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using University_Website.Models;

namespace University_Website.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    public class ContactInformationsController : ControllerBase
    {
        private readonly UniversityDBContext _context;

        public ContactInformationsController(UniversityDBContext context)
        {
            _context = context;
        }

        // GET: api/ContactInformations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactInformation>>> GetContactInformation()
        {
            return await _context.ContactInformation.ToListAsync();
        }

        // GET: api/ContactInformations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContactInformation>> GetContactInformation(int id)
        {
            var contactInformation = await _context.ContactInformation.FindAsync(id);

            if (contactInformation == null)
            {
                return NotFound();
            }

            return contactInformation;
        }

        // PUT: api/ContactInformations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContactInformation(int id, ContactInformation contactInformation)
        {
            if (id != contactInformation.ContactId)
            {
                return BadRequest();
            }

            _context.Entry(contactInformation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactInformationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ContactInformations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ContactInformation>> PostContactInformation(ContactInformation contactInformation)
        {
            _context.ContactInformation.Add(contactInformation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContactInformation", new { id = contactInformation.ContactId }, contactInformation);
        }

        // DELETE: api/ContactInformations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContactInformation(int id)
        {
            var contactInformation = await _context.ContactInformation.FindAsync(id);
            if (contactInformation == null)
            {
                return NotFound();
            }

            _context.ContactInformation.Remove(contactInformation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContactInformationExists(int id)
        {
            return _context.ContactInformation.Any(e => e.ContactId == id);
        }
    }
}
