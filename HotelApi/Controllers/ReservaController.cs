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
    public class ReservaController : ControllerBase
    {
        private readonly HotelContext _context;

        public ReservaController(HotelContext context)
        {
            _context = context;
        }

        // GET: api/Reserva
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReservaModel>>> GetReservas()
        {
            return await _context.Reservas.ToListAsync();
        }

        // GET: api/Reserva/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReservaModel>> GetReservaModel(int id)
        {
            var reservaModel = await _context.Reservas.FindAsync(id);

            if (reservaModel == null)
            {
                return NotFound();
            }

            return reservaModel;
        }

        // PUT: api/Reserva/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReservaModel(int id, ReservaModel reservaModel)
        {
            if (id != reservaModel.IdReserva)
            {
                return BadRequest();
            }

            _context.Entry(reservaModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservaModelExists(id))
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

        // POST: api/Reserva
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ReservaModel>> PostReservaModel(ReservaModel reservaModel)
        {
            _context.Reservas.Add(reservaModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReservaModel", new { id = reservaModel.IdReserva }, reservaModel);
        }

        // DELETE: api/Reserva/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ReservaModel>> DeleteReservaModel(int id)
        {
            var reservaModel = await _context.Reservas.FindAsync(id);
            if (reservaModel == null)
            {
                return NotFound();
            }

            _context.Reservas.Remove(reservaModel);
            await _context.SaveChangesAsync();

            return reservaModel;
        }

        private bool ReservaModelExists(int id)
        {
            return _context.Reservas.Any(e => e.IdReserva == id);
        }
    }
}
