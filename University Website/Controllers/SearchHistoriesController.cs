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
    public class SearchHistoriesController : ControllerBase
    {
        private readonly UniversityDBContext _context;

        public SearchHistoriesController(UniversityDBContext context)
        {
            _context = context;
        }

        // GET: api/SearchHistories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SearchHistory>>> GetSearchHistory()
        {
            return await _context.SearchHistory.ToListAsync();
        }

        // GET: api/SearchHistories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SearchHistory>> GetSearchHistory(int id)
        {
            var searchHistory = await _context.SearchHistory.FindAsync(id);

            if (searchHistory == null)
            {
                return NotFound();
            }

            return searchHistory;
        }

        // PUT: api/SearchHistories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSearchHistory(int id, SearchHistory searchHistory)
        {
            if (id != searchHistory.SearchId)
            {
                return BadRequest();
            }

            _context.Entry(searchHistory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SearchHistoryExists(id))
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

        // POST: api/SearchHistories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SearchHistory>> PostSearchHistory(SearchHistory searchHistory)
        {
            _context.SearchHistory.Add(searchHistory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSearchHistory", new { id = searchHistory.SearchId }, searchHistory);
        }

        // DELETE: api/SearchHistories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSearchHistory(int id)
        {
            var searchHistory = await _context.SearchHistory.FindAsync(id);
            if (searchHistory == null)
            {
                return NotFound();
            }

            _context.SearchHistory.Remove(searchHistory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SearchHistoryExists(int id)
        {
            return _context.SearchHistory.Any(e => e.SearchId == id);
        }
    }
}
