﻿using System;
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
    public class VisitantesController : ControllerBase
    {
        private readonly EventosDbContext _context;

        public VisitantesController(EventosDbContext context)
        {
            _context = context;
        }

        // GET: api/Visitantes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Visitante>>> GetVisitantes()
        {
          if (_context.Visitantes == null)
          {
              return NotFound();
          }
            return await _context.Visitantes.ToListAsync();
        }

        // GET: api/Visitantes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Visitante>> GetVisitante(int id)
        {
          if (_context.Visitantes == null)
          {
              return NotFound();
          }
            var visitante = await _context.Visitantes.FindAsync(id);

            if (visitante == null)
            {
                return NotFound();
            }

            return visitante;
        }

        // PUT: api/Visitantes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVisitante(int id, Visitante visitante)
        {
            if (id != visitante.IdVisitante)
            {
                return BadRequest();
            }

            _context.Entry(visitante).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VisitanteExists(id))
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

        // POST: api/Visitantes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Visitante>> PostVisitante(Visitante visitante)
        {
          if (_context.Visitantes == null)
          {
              return Problem("Entity set 'EventosDbContext.Visitantes'  is null.");
          }
            _context.Visitantes.Add(visitante);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVisitante", new { id = visitante.IdVisitante }, visitante);
        }

        // DELETE: api/Visitantes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVisitante(int id)
        {
            if (_context.Visitantes == null)
            {
                return NotFound();
            }
            var visitante = await _context.Visitantes.FindAsync(id);
            if (visitante == null)
            {
                return NotFound();
            }

            _context.Visitantes.Remove(visitante);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VisitanteExists(int id)
        {
            return (_context.Visitantes?.Any(e => e.IdVisitante == id)).GetValueOrDefault();
        }
    }
}
