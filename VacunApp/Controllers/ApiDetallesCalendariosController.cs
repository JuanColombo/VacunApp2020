using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VacunApp.Models;

namespace VacunApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiDetallesCalendariosController : ControllerBase
    {
        private readonly VacunAppContext _context;

        public ApiDetallesCalendariosController(VacunAppContext context)
        {
            _context = context;
        }

        // GET: api/ApiDetallesCalendarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetalleCalendario>>> GetDetalleCalendarios()
        {
            return await _context.DetalleCalendarios.ToListAsync();
        }

        // GET: api/ApiDetallesCalendarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetalleCalendario>> GetDetalleCalendario(int id)
        {
            var detalleCalendario = await _context.DetalleCalendarios.FindAsync(id);

            if (detalleCalendario == null)
            {
                return NotFound();
            }

            return detalleCalendario;
        }

        // PUT: api/ApiDetallesCalendarios/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetalleCalendario(int id, DetalleCalendario detalleCalendario)
        {
            if (id != detalleCalendario.Id)
            {
                return BadRequest();
            }

            _context.Entry(detalleCalendario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetalleCalendarioExists(id))
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

        // POST: api/ApiDetallesCalendarios
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DetalleCalendario>> PostDetalleCalendario(DetalleCalendario detalleCalendario)
        {
            _context.DetalleCalendarios.Add(detalleCalendario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetalleCalendario", new { id = detalleCalendario.Id }, detalleCalendario);
        }

        // DELETE: api/ApiDetallesCalendarios/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DetalleCalendario>> DeleteDetalleCalendario(int id)
        {
            var detalleCalendario = await _context.DetalleCalendarios.FindAsync(id);
            if (detalleCalendario == null)
            {
                return NotFound();
            }

            _context.DetalleCalendarios.Remove(detalleCalendario);
            await _context.SaveChangesAsync();

            return detalleCalendario;
        }

        private bool DetalleCalendarioExists(int id)
        {
            return _context.DetalleCalendarios.Any(e => e.Id == id);
        }
    }
}
