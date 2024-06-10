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
    public class StudentResourcesController : ControllerBase
    {
        private readonly UniversityDBContext _context;

        public StudentResourcesController(UniversityDBContext context)
        {
            _context = context;
        }

        // GET: api/StudentResources
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentResource>>> GetStudentResources()
        {
            return await _context.StudentResources.ToListAsync();
        }

        // GET: api/StudentResources/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentResource>> GetStudentResource(int id)
        {
            var studentResource = await _context.StudentResources.FindAsync(id);

            if (studentResource == null)
            {
                return NotFound();
            }

            return studentResource;
        }

        // PUT: api/StudentResources/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentResource(int id, StudentResource studentResource)
        {
            if (id != studentResource.ResourceId)
            {
                return BadRequest();
            }

            _context.Entry(studentResource).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentResourceExists(id))
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

        // POST: api/StudentResources
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StudentResource>> PostStudentResource(StudentResource studentResource)
        {
            _context.StudentResources.Add(studentResource);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudentResource", new { id = studentResource.ResourceId }, studentResource);
        }

        // DELETE: api/StudentResources/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentResource(int id)
        {
            var studentResource = await _context.StudentResources.FindAsync(id);
            if (studentResource == null)
            {
                return NotFound();
            }

            _context.StudentResources.Remove(studentResource);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentResourceExists(int id)
        {
            return _context.StudentResources.Any(e => e.ResourceId == id);
        }
    }
}
