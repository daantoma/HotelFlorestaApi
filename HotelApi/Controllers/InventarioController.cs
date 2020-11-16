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
    public class InventarioController : ControllerBase
    {
        private readonly HotelContext _context;

        public InventarioController(HotelContext context)
        {
            _context = context;
        }

        // GET: api/Inventario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InventarioModel>>> GetInventarios()
        {
            return await _context.Inventarios.ToListAsync();
        }

        // GET: api/Inventario/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InventarioModel>> GetInventarioModel(int id)
        {
            var inventarioModel = await _context.Inventarios.FindAsync(id);

            if (inventarioModel == null)
            {
                return NotFound();
            }

            return inventarioModel;
        }

        // PUT: api/Inventario/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInventarioModel(int id, InventarioModel inventarioModel)
        {
            if (id != inventarioModel.IdInventario)
            {
                return BadRequest();
            }

            _context.Entry(inventarioModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InventarioModelExists(id))
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

        // POST: api/Inventario
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<InventarioModel>> PostInventarioModel(InventarioModel inventarioModel)
        {
            _context.Inventarios.Add(inventarioModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInventarioModel", new { id = inventarioModel.IdInventario }, inventarioModel);
        }

        // DELETE: api/Inventario/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<InventarioModel>> DeleteInventarioModel(int id)
        {
            var inventarioModel = await _context.Inventarios.FindAsync(id);
            if (inventarioModel == null)
            {
                return NotFound();
            }

            _context.Inventarios.Remove(inventarioModel);
            await _context.SaveChangesAsync();

            return inventarioModel;
        }

        private bool InventarioModelExists(int id)
        {
            return _context.Inventarios.Any(e => e.IdInventario == id);
        }
    }
}
