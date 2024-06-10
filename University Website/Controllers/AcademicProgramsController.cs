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
    public class AcademicProgramsController : ControllerBase
    {
        private readonly UniversityDBContext _context;

        public AcademicProgramsController(UniversityDBContext context)
        {
            _context = context;
        }

        // GET: api/AcademicPrograms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AcademicProgram>>> GetAcademicPrograms()
        {
            return await _context.AcademicPrograms.ToListAsync();
        }

        // GET: api/AcademicPrograms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AcademicProgram>> GetAcademicProgram(int id)
        {
            var academicProgram = await _context.AcademicPrograms.FindAsync(id);

            if (academicProgram == null)
            {
                return NotFound();
            }

            return academicProgram;
        }

        // PUT: api/AcademicPrograms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAcademicProgram(int id, AcademicProgram academicProgram)
        {
            if (id != academicProgram.ProgramId)
            {
                return BadRequest();
            }

            _context.Entry(academicProgram).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AcademicProgramExists(id))
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

        // POST: api/AcademicPrograms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AcademicProgram>> PostAcademicProgram(AcademicProgram academicProgram)
        {
            _context.AcademicPrograms.Add(academicProgram);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAcademicProgram", new { id = academicProgram.ProgramId }, academicProgram);
        }

        // DELETE: api/AcademicPrograms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAcademicProgram(int id)
        {
            var academicProgram = await _context.AcademicPrograms.FindAsync(id);
            if (academicProgram == null)
            {
                return NotFound();
            }

            _context.AcademicPrograms.Remove(academicProgram);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AcademicProgramExists(int id)
        {
            return _context.AcademicPrograms.Any(e => e.ProgramId == id);
        }
    }
}
