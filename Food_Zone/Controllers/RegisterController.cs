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
    public class RegisterController : ControllerBase
    {
        private readonly FoodDbContext _context;

        public RegisterController(FoodDbContext context)
        {
            _context = context;
        }

        // GET: api/Register
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Register>>> GetRegister()
        {
            return await _context.Register.ToListAsync();
        }

        // GET: api/Register/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Register>> GetRegister(int id)
        {
            var register = await _context.Register.FindAsync(id);

            if (register == null)
            {
                return NotFound();
            }

            return register;
        }

        // PUT: api/Register/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegister(int id, Register register)
        {
            if (id != register.UserID)
            {
                return BadRequest();
            }

            _context.Entry(register).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegisterExists(id))
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

        // POST: api/Register
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("RegisterUser")]
        public async Task<ActionResult<Register>> PostRegister(Register register)
        {
            if(_context.Register.Where(u => u.Email == register.Email).FirstOrDefault() != null)
            {
                return Ok("Already Exist");
            }
            register.MemberSince = DateTime.Now;
            _context.Register.Add(register);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRegister", new { id = register.UserID }, register);
        }

        [HttpPost("LoginUser")]
        public async Task<ActionResult<Login>> PostRegister(Login login)
        {
            var userAvailable = _context.Register.Where(u => u.Email == login.Email && u.pwd == login.pwd).FirstOrDefault();
            if (userAvailable != null)
            {
                return Ok("Success");
            }
            
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetLogin", new { email = login.Email, pwd = login.pwd}, login);
            
        }

        // DELETE: api/Register/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Register>> DeleteRegister(int id)
        {
            var register = await _context.Register.FindAsync(id);
            if (register == null)
            {
                return NotFound();
            }

            _context.Register.Remove(register);
            await _context.SaveChangesAsync();

            return register;
        }

        private bool RegisterExists(int id)
        {
            return _context.Register.Any(e => e.UserID == id);
        }
    }
}
