﻿using System;
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
    public class ApiVacunasController : ControllerBase
    {
        private readonly VacunAppContext _context;

        public ApiVacunasController(VacunAppContext context)
        {
            _context = context;
        }

        // GET: api/ApiVacunas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vacuna>>> GetVacunas()
        {
            return await _context.Vacunas.ToListAsync();
        }

        // GET: api/ApiVacunas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vacuna>> GetVacuna(int id)
        {
            var vacuna = await _context.Vacunas.FindAsync(id);

            if (vacuna == null)
            {
                return NotFound();
            }

            return vacuna;
        }

        // PUT: api/ApiVacunas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVacuna(int id, Vacuna vacuna)
        {
            if (id != vacuna.Id)
            {
                return BadRequest();
            }

            _context.Entry(vacuna).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VacunaExists(id))
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

        // POST: api/ApiVacunas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Vacuna>> PostVacuna(Vacuna vacuna)
        {
            _context.Vacunas.Add(vacuna);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVacuna", new { id = vacuna.Id }, vacuna);
        }

        // DELETE: api/ApiVacunas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Vacuna>> DeleteVacuna(int id)
        {
            var vacuna = await _context.Vacunas.FindAsync(id);
            if (vacuna == null)
            {
                return NotFound();
            }

            _context.Vacunas.Remove(vacuna);
            await _context.SaveChangesAsync();

            return vacuna;
        }

        private bool VacunaExists(int id)
        {
            return _context.Vacunas.Any(e => e.Id == id);
        }
    }
}
