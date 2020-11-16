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
    public class FacturaController : ControllerBase
    {
        private readonly HotelContext _context;

        public FacturaController(HotelContext context)
        {
            _context = context;
        }

        // GET: api/Factura
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FacturaModel>>> GetFacturas()
        {
            return await _context.Facturas.ToListAsync();
        }

        // GET: api/Factura/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FacturaModel>> GetFacturaModel(int id)
        {
            var facturaModel = await _context.Facturas.FindAsync(id);

            if (facturaModel == null)
            {
                return NotFound();
            }

            return facturaModel;
        }

        // PUT: api/Factura/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFacturaModel(int id, FacturaModel facturaModel)
        {
            if (id != facturaModel.IdFactura)
            {
                return BadRequest();
            }

            _context.Entry(facturaModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FacturaModelExists(id))
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

        // POST: api/Factura
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<FacturaModel>> PostFacturaModel(FacturaModel facturaModel)
        {
            _context.Facturas.Add(facturaModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFacturaModel", new { id = facturaModel.IdFactura }, facturaModel);
        }

        // DELETE: api/Factura/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FacturaModel>> DeleteFacturaModel(int id)
        {
            var facturaModel = await _context.Facturas.FindAsync(id);
            if (facturaModel == null)
            {
                return NotFound();
            }

            _context.Facturas.Remove(facturaModel);
            await _context.SaveChangesAsync();

            return facturaModel;
        }

        private bool FacturaModelExists(int id)
        {
            return _context.Facturas.Any(e => e.IdFactura == id);
        }
    }
}
