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
    public class contactController : ControllerBase
    {
        private readonly FoodDbContext _context;

        public contactController(FoodDbContext context)
        {
            _context = context;
        }

        // GET: api/contact
        [HttpGet]
        public async Task<ActionResult<IEnumerable<contact>>> Getcontact()
        {
            return await _context.contact.ToListAsync();
        }

        // GET: api/contact/5
        [HttpGet("{id}")]
        public async Task<ActionResult<contact>> Getcontact(int id)
        {
            var contact = await _context.contact.FindAsync(id);

            if (contact == null)
            {
                return NotFound();
            }

            return contact;
        }

        // PUT: api/contact/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putcontact(int id, contact contact)
        {
            if (id != contact.contactid)
            {
                return BadRequest();
            }

            _context.Entry(contact).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!contactExists(id))
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

        // POST: api/contact
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<contact>> Postcontact(contact contact)
        {
            _context.contact.Add(contact);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getcontact", new { id = contact.contactid }, contact);
        }

        // DELETE: api/contact/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<contact>> Deletecontact(int id)
        {
            var contact = await _context.contact.FindAsync(id);
            if (contact == null)
            {
                return NotFound();
            }

            _context.contact.Remove(contact);
            await _context.SaveChangesAsync();

            return contact;
        }

        private bool contactExists(int id)
        {
            return _context.contact.Any(e => e.contactid == id);
        }
    }
}
