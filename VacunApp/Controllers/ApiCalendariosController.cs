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
    public class ApiCalendariosController : ControllerBase
    {
        private readonly VacunAppContext _context;

        public ApiCalendariosController(VacunAppContext context)
        {
            _context = context;
        }

        // GET: api/ApiCalendarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Calendario>>> GetCalendarios()
        {
            return await _context.Calendarios.ToListAsync();
        }

        // GET: api/ApiCalendarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Calendario>> GetCalendario(int id)
        {
            var calendario = await _context.Calendarios.FindAsync(id);

            if (calendario == null)
            {
                return NotFound();
            }

            return calendario;
        }

        // PUT: api/ApiCalendarios/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCalendario(int id, Calendario calendario)
        {
            if (id != calendario.Id)
            {
                return BadRequest();
            }

            _context.Entry(calendario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CalendarioExists(id))
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

        // POST: api/ApiCalendarios
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Calendario>> PostCalendario(Calendario calendario)
        {
            _context.Calendarios.Add(calendario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCalendario", new { id = calendario.Id }, calendario);
        }

        // DELETE: api/ApiCalendarios/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Calendario>> DeleteCalendario(int id)
        {
            var calendario = await _context.Calendarios.FindAsync(id);
            if (calendario == null)
            {
                return NotFound();
            }

            _context.Calendarios.Remove(calendario);
            await _context.SaveChangesAsync();

            return calendario;
        }

        private bool CalendarioExists(int id)
        {
            return _context.Calendarios.Any(e => e.Id == id);
        }
    }
}
