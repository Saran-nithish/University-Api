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
    public class FinancialAidsController : ControllerBase
    {
        private readonly UniversityDBContext _context;

        public FinancialAidsController(UniversityDBContext context)
        {
            _context = context;
        }

        // GET: api/FinancialAids
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FinancialAid>>> GetFinancialAid()
        {
            return await _context.FinancialAid.ToListAsync();
        }

        // GET: api/FinancialAids/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FinancialAid>> GetFinancialAid(int id)
        {
            var financialAid = await _context.FinancialAid.FindAsync(id);

            if (financialAid == null)
            {
                return NotFound();
            }

            return financialAid;
        }

        // PUT: api/FinancialAids/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFinancialAid(int id, FinancialAid financialAid)
        {
            if (id != financialAid.AidId)
            {
                return BadRequest();
            }

            _context.Entry(financialAid).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FinancialAidExists(id))
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

        // POST: api/FinancialAids
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FinancialAid>> PostFinancialAid(FinancialAid financialAid)
        {
            _context.FinancialAid.Add(financialAid);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFinancialAid", new { id = financialAid.AidId }, financialAid);
        }

        // DELETE: api/FinancialAids/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFinancialAid(int id)
        {
            var financialAid = await _context.FinancialAid.FindAsync(id);
            if (financialAid == null)
            {
                return NotFound();
            }

            _context.FinancialAid.Remove(financialAid);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FinancialAidExists(int id)
        {
            return _context.FinancialAid.Any(e => e.AidId == id);
        }
    }
}
