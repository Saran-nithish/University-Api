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
    public class StudentOrganizationsController : ControllerBase
    {
        private readonly UniversityDBContext _context;

        public StudentOrganizationsController(UniversityDBContext context)
        {
            _context = context;
        }

        // GET: api/StudentOrganizations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentOrganization>>> GetStudentOrganizations()
        {
            return await _context.StudentOrganizations.ToListAsync();
        }

        // GET: api/StudentOrganizations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentOrganization>> GetStudentOrganization(int id)
        {
            var studentOrganization = await _context.StudentOrganizations.FindAsync(id);

            if (studentOrganization == null)
            {
                return NotFound();
            }

            return studentOrganization;
        }

        // PUT: api/StudentOrganizations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentOrganization(int id, StudentOrganization studentOrganization)
        {
            if (id != studentOrganization.OrganizationId)
            {
                return BadRequest();
            }

            _context.Entry(studentOrganization).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentOrganizationExists(id))
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

        // POST: api/StudentOrganizations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StudentOrganization>> PostStudentOrganization(StudentOrganization studentOrganization)
        {
            _context.StudentOrganizations.Add(studentOrganization);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudentOrganization", new { id = studentOrganization.OrganizationId }, studentOrganization);
        }

        // DELETE: api/StudentOrganizations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentOrganization(int id)
        {
            var studentOrganization = await _context.StudentOrganizations.FindAsync(id);
            if (studentOrganization == null)
            {
                return NotFound();
            }

            _context.StudentOrganizations.Remove(studentOrganization);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentOrganizationExists(int id)
        {
            return _context.StudentOrganizations.Any(e => e.OrganizationId == id);
        }
    }
}
