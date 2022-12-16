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
    public class vegController : ControllerBase
    {
        private readonly FoodDbContext _context;

        public vegController(FoodDbContext context)
        {
            _context = context;
        }

        // GET: api/veg
        [HttpGet]
        public async Task<ActionResult<IEnumerable<veg>>> Getveg()
        {
            return await _context.veg.ToListAsync();
        }

        // GET: api/veg/5
        [HttpGet("{id}")]
        public async Task<ActionResult<veg>> Getveg(int id)
        {
            var veg = await _context.veg.FindAsync(id);

            if (veg == null)
            {
                return NotFound();
            }

            return veg;
        }

        // PUT: api/veg/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putveg(int id, veg veg)
        {
            if (id != veg.food_id)
            {
                return BadRequest();
            }

            _context.Entry(veg).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!vegExists(id))
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

        // POST: api/veg
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<veg>> Postveg(veg veg)
        {
            _context.veg.Add(veg);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getveg", new { id = veg.food_id }, veg);
        }

        // DELETE: api/veg/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<veg>> Deleteveg(int id)
        {
            var veg = await _context.veg.FindAsync(id);
            if (veg == null)
            {
                return NotFound();
            }

            _context.veg.Remove(veg);
            await _context.SaveChangesAsync();

            return veg;
        }

        private bool vegExists(int id)
        {
            return _context.veg.Any(e => e.food_id == id);
        }
    }
}
