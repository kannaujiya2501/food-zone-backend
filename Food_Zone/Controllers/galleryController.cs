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
    public class galleryController : ControllerBase
    {
        private readonly FoodDbContext _context;

        public galleryController(FoodDbContext context)
        {
            _context = context;
        }

        // GET: api/gallery
        [HttpGet]
        public async Task<ActionResult<IEnumerable<gallery>>> Getgallery()
        {
            return await _context.gallery.ToListAsync();
        }

        // GET: api/gallery/5
        [HttpGet("{id}")]
        public async Task<ActionResult<gallery>> Getgallery(int id)
        {
            var gallery = await _context.gallery.FindAsync(id);

            if (gallery == null)
            {
                return NotFound();
            }

            return gallery;
        }

        // PUT: api/gallery/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putgallery(int id, gallery gallery)
        {
            if (id != gallery.food_id)
            {
                return BadRequest();
            }

            _context.Entry(gallery).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!galleryExists(id))
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

        // POST: api/gallery
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<gallery>> Postgallery(gallery gallery)
        {
            _context.gallery.Add(gallery);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getgallery", new { id = gallery.food_id }, gallery);
        }

        // DELETE: api/gallery/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<gallery>> Deletegallery(int id)
        {
            var gallery = await _context.gallery.FindAsync(id);
            if (gallery == null)
            {
                return NotFound();
            }

            _context.gallery.Remove(gallery);
            await _context.SaveChangesAsync();

            return gallery;
        }

        private bool galleryExists(int id)
        {
            return _context.gallery.Any(e => e.food_id == id);
        }
    }
}
