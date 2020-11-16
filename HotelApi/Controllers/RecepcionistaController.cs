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
    public class RecepcionistaController : ControllerBase
    {
        private readonly HotelContext _context;

        public RecepcionistaController(HotelContext context)
        {
            _context = context;
        }

        // GET: api/Recepcionista
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecepcionistaModel>>> GetRecepcionistas()
        {
            return await _context.Recepcionistas.ToListAsync();
        }

        // GET: api/Recepcionista/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RecepcionistaModel>> GetRecepcionistaModel(string id)
        {
            var recepcionistaModel = await _context.Recepcionistas.FindAsync(id);

            if (recepcionistaModel == null)
            {
                return NotFound();
            }

            return recepcionistaModel;
        }

        // PUT: api/Recepcionista/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecepcionistaModel(string id, RecepcionistaModel recepcionistaModel)
        {
            if (id != recepcionistaModel.Identificacion)
            {
                return BadRequest();
            }

            _context.Entry(recepcionistaModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecepcionistaModelExists(id))
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

        // POST: api/Recepcionista
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<RecepcionistaModel>> PostRecepcionistaModel(RecepcionistaModel recepcionistaModel)
        {
            _context.Recepcionistas.Add(recepcionistaModel);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RecepcionistaModelExists(recepcionistaModel.Identificacion))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRecepcionistaModel", new { id = recepcionistaModel.Identificacion }, recepcionistaModel);
        }

        // DELETE: api/Recepcionista/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RecepcionistaModel>> DeleteRecepcionistaModel(string id)
        {
            var recepcionistaModel = await _context.Recepcionistas.FindAsync(id);
            if (recepcionistaModel == null)
            {
                return NotFound();
            }

            _context.Recepcionistas.Remove(recepcionistaModel);
            await _context.SaveChangesAsync();

            return recepcionistaModel;
        }

        private bool RecepcionistaModelExists(string id)
        {
            return _context.Recepcionistas.Any(e => e.Identificacion == id);
        }
    }
}
