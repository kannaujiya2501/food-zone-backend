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
    public class checksController : ControllerBase
    {
        private readonly FoodDbContext _context;

        public checksController(FoodDbContext context)
        {
            _context = context;
        }

        // GET: api/checks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<check>>> Getcheck()
        {
            return await _context.check.ToListAsync();
        }

        // GET: api/checks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<check>> Getcheck(int id)
        {
            var check = await _context.check.FindAsync(id);

            if (check == null)
            {
                return NotFound();
            }

            return check;
        }

        // PUT: api/checks/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putcheck(int id, check check)
        {
            if (id != check.checkid)
            {
                return BadRequest();
            }

            _context.Entry(check).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!checkExists(id))
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

        // POST: api/checks
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<check>> Postcheck(check check)
        {
            _context.check.Add(check);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getcheck", new { id = check.checkid }, check);
        }

        // DELETE: api/checks/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<check>> Deletecheck(int id)
        {
            var check = await _context.check.FindAsync(id);
            if (check == null)
            {
                return NotFound();
            }

            _context.check.Remove(check);
            await _context.SaveChangesAsync();

            return check;
        }

        private bool checkExists(int id)
        {
            return _context.check.Any(e => e.checkid == id);
        }
    }
}
