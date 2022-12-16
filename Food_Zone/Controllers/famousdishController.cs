using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Food_Zone.Models;

namespace Food_Zone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class famousdishController : ControllerBase
    {
        private readonly FoodDbContext _context;

        public famousdishController(FoodDbContext context)
        {
            _context = context;
        }

        // GET: api/famousdish
        [HttpGet]
        public async Task<ActionResult<IEnumerable<famousdish>>> Getfamousdish()
        {
            return await _context.famousdish.ToListAsync();
        }

        // GET: api/famousdish/5
        [HttpGet("{id}")]
        public async Task<ActionResult<famousdish>> Getfamousdish(int id)
        {
            var famousdish = await _context.famousdish.FindAsync(id);

            if (famousdish == null)
            {
                return NotFound();
            }

            return famousdish;
        }

        // PUT: api/famousdish/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putfamousdish(int id, famousdish famousdish)
        {
            if (id != famousdish.food_id)
            {
                return BadRequest();
            }

            _context.Entry(famousdish).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!famousdishExists(id))
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

        // POST: api/famousdish
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<famousdish>> Postfamousdish(famousdish famousdish)
        {
            _context.famousdish.Add(famousdish);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getfamousdish", new { id = famousdish.food_id }, famousdish);
        }

        // DELETE: api/famousdish/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<famousdish>> Deletefamousdish(int id)
        {
            var famousdish = await _context.famousdish.FindAsync(id);
            if (famousdish == null)
            {
                return NotFound();
            }

            _context.famousdish.Remove(famousdish);
            await _context.SaveChangesAsync();

            return famousdish;
        }

        private bool famousdishExists(int id)
        {
            return _context.famousdish.Any(e => e.food_id == id);
        }
    }
}
