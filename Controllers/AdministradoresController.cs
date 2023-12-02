using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppDeEventos.Data;
using AppDeEventos.Models;

namespace AppDeEventos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministradoresController : ControllerBase
    {
        private readonly EventosDbContext _context;

        public AdministradoresController(EventosDbContext context)
        {
            _context = context;
        }

        // GET: api/Administradores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Administrador>>> GetAdministradores()
        {
          if (_context.Administradores == null)
          {
              return NotFound();
          }
            return await _context.Administradores.ToListAsync();
        }

        // GET: api/Administradores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Administrador>> GetAdministrador(int id)
        {
          if (_context.Administradores == null)
          {
              return NotFound();
          }
            var administrador = await _context.Administradores.FindAsync(id);

            if (administrador == null)
            {
                return NotFound();
            }

            return administrador;
        }

        [HttpGet("GetAdministradorSenhaEmail")]
        public async Task<ActionResult<Administrador>> GetAdministradorByEmailAndPassword(string email, string senha)
        {
            var administrador = await _context.Administradores
                .FirstOrDefaultAsync(a => a.Email == email && a.Senha == senha);

            if (administrador == null)
            {
                return NotFound();
            }

            return administrador;
        }

        // PUT: api/Administradores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdministrador(int id, Administrador administrador)
        {
            if (id != administrador.IdAdministrador)
            {
                return BadRequest();
            }

            _context.Entry(administrador).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdministradorExists(id))
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

        // POST: api/Administradores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Administrador>> PostAdministrador(Administrador administrador)
        {
          if (_context.Administradores == null)
          {
              return Problem("Entity set 'EventosDbContext.Administradores'  is null.");
          }
            _context.Administradores.Add(administrador);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdministrador", new { id = administrador.IdAdministrador}, administrador);
        }

        [HttpPost("addAdministrador")]
        public async Task<ActionResult<Administrador>> PostProduto(AdministradorInputModel model)
        {
            var administrador = new Administrador
            {
                Nome = model.Nome,
                Email = model.Email,
                Senha = model.Senha,
                Organizador = model.Organizador
            };

            _context.Administradores.Add(administrador);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdministrador", new { id = administrador.IdAdministrador}, administrador);
        }

        // DELETE: api/Administradores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdministrador(int id)
        {
            if (_context.Administradores == null)
            {
                return NotFound();
            }
            var administrador = await _context.Administradores.FindAsync(id);
            if (administrador == null)
            {
                return NotFound();
            }

            _context.Administradores.Remove(administrador);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdministradorExists(int id)
        {
            return (_context.Administradores?.Any(e => e.IdAdministrador == id)).GetValueOrDefault();
        }
    }
}
