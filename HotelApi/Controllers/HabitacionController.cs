using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelApi.Context;
using HotelApi.Models;

namespace HotelApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HabitacionController : ControllerBase
    {
        private readonly HotelContext _context;

        public HabitacionController(HotelContext context)
        {
            _context = context;
        }

        // GET: api/Habitacion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HabitacionModel>>> GetHabitaciones()
        {
            return await _context.Habitaciones.ToListAsync();
        }

        // GET: api/Habitacion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HabitacionModel>> GetHabitacionModel(string id)
        {
            var habitacionModel = await _context.Habitaciones.FindAsync(id);

            if (habitacionModel == null)
            {
                return NotFound();
            }

            return habitacionModel;
        }

        // PUT: api/Habitacion/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHabitacionModel(string id, HabitacionModel habitacionModel)
        {
            if (id != habitacionModel.IdHabitacion)
            {
                return BadRequest();
            }

            _context.Entry(habitacionModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HabitacionModelExists(id))
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

        // POST: api/Habitacion
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HabitacionModel>> PostHabitacionModel(HabitacionModel habitacionModel)
        {
            _context.Habitaciones.Add(habitacionModel);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HabitacionModelExists(habitacionModel.IdHabitacion))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetHabitacionModel", new { id = habitacionModel.IdHabitacion }, habitacionModel);
        }

        // DELETE: api/Habitacion/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HabitacionModel>> DeleteHabitacionModel(string id)
        {
            var habitacionModel = await _context.Habitaciones.FindAsync(id);
            if (habitacionModel == null)
            {
                return NotFound();
            }

            _context.Habitaciones.Remove(habitacionModel);
            await _context.SaveChangesAsync();

            return habitacionModel;
        }

        private bool HabitacionModelExists(string id)
        {
            return _context.Habitaciones.Any(e => e.IdHabitacion == id);
        }
    }
}
