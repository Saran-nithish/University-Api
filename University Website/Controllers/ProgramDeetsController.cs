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
    public class ProgramDeetsController : ControllerBase
    {
        private readonly UniversityDBContext _context;

        public ProgramDeetsController(UniversityDBContext context)
        {
            _context = context;
        }

        // GET: api/ProgramDeets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProgramDeets>>> GetProgramDetails()
        {
            return await _context.ProgramDetails.ToListAsync();
        }

        // GET: api/ProgramDeets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProgramDeets>> GetProgramDeets(int id)
        {
            var programDeets = await _context.ProgramDetails.FindAsync(id);

            if (programDeets == null)
            {
                return NotFound();
            }

            return programDeets;
        }

        // PUT: api/ProgramDeets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProgramDeets(int id, ProgramDeets programDeets)
        {
            if (id != programDeets.ProgramId)
            {
                return BadRequest();
            }

            _context.Entry(programDeets).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProgramDeetsExists(id))
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

        // POST: api/ProgramDeets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProgramDeets>> PostProgramDeets(ProgramDeets programDeets)
        {
            _context.ProgramDetails.Add(programDeets);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProgramDeets", new { id = programDeets.ProgramId }, programDeets);
        }

        // DELETE: api/ProgramDeets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProgramDeets(int id)
        {
            var programDeets = await _context.ProgramDetails.FindAsync(id);
            if (programDeets == null)
            {
                return NotFound();
            }

            _context.ProgramDetails.Remove(programDeets);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProgramDeetsExists(int id)
        {
            return _context.ProgramDetails.Any(e => e.ProgramId == id);
        }
    }
}
