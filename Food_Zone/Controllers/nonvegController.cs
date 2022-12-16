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
    public class nonvegController : ControllerBase
    {
        private readonly FoodDbContext _context;

        public nonvegController(FoodDbContext context)
        {
            _context = context;
        }

        // GET: api/nonveg
        [HttpGet]
        public async Task<ActionResult<IEnumerable<nonveg>>> Getnonveg()
        {
            return await _context.nonveg.ToListAsync();
        }

        // GET: api/nonveg/5
        [HttpGet("{id}")]
        public async Task<ActionResult<nonveg>> Getnonveg(int id)
        {
            var nonveg = await _context.nonveg.FindAsync(id);

            if (nonveg == null)
            {
                return NotFound();
            }

            return nonveg;
        }

        // PUT: api/nonveg/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putnonveg(int id, nonveg nonveg)
        {
            if (id != nonveg.food_id)
            {
                return BadRequest();
            }

            _context.Entry(nonveg).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!nonvegExists(id))
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

        // POST: api/nonveg
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<nonveg>> Postnonveg(nonveg nonveg)
        {
            _context.nonveg.Add(nonveg);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getnonveg", new { id = nonveg.food_id }, nonveg);
        }

        // DELETE: api/nonveg/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<nonveg>> Deletenonveg(int id)
        {
            var nonveg = await _context.nonveg.FindAsync(id);
            if (nonveg == null)
            {
                return NotFound();
            }

            _context.nonveg.Remove(nonveg);
            await _context.SaveChangesAsync();

            return nonveg;
        }

        private bool nonvegExists(int id)
        {
            return _context.nonveg.Any(e => e.food_id == id);
        }
    }
}
