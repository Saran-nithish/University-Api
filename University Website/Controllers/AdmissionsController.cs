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
    public class AdmissionsController : ControllerBase
    {
        private readonly UniversityDBContext _context;

        public AdmissionsController(UniversityDBContext context)
        {
            _context = context;
        }

        // GET: api/Admissions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Admission>>> GetAdmissions()
        {
            return await _context.Admissions.ToListAsync();
        }

        // GET: api/Admissions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Admission>> GetAdmission(int id)
        {
            var admission = await _context.Admissions.FindAsync(id);

            if (admission == null)
            {
                return NotFound();
            }

            return admission;
        }

        // PUT: api/Admissions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAdmissionStatus(int id, Admission updatedAdmission)
        {
            var admission = await _context.Admissions.FindAsync(id);
            if (admission == null)
            {
                return NotFound();
            }

            admission.Status = updatedAdmission.Status;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/Admissions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Admission>> PostAdmission(Admission admission)
        {
            _context.Admissions.Add(admission);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdmission", new { id = admission.AdmissionId }, admission);
        }

        // DELETE: api/Admissions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdmission(int id)
        {
            var admission = await _context.Admissions.FindAsync(id);
            if (admission == null)
            {
                return NotFound();
            }

            _context.Admissions.Remove(admission);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdmissionExists(int id)
        {
            return _context.Admissions.Any(e => e.AdmissionId == id);
        }
    }
}
