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
    public class CompraController : ControllerBase
    {
        private readonly HotelContext _context;

        public CompraController(HotelContext context)
        {
            _context = context;
        }

        // GET: api/Compra
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompraModel>>> GetCompraModel()
        {
            return await _context.CompraModel.ToListAsync();
        }

        // GET: api/Compra/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CompraModel>> GetCompraModel(int id)
        {
            var compraModel = await _context.CompraModel.FindAsync(id);

            if (compraModel == null)
            {
                return NotFound();
            }

            return compraModel;
        }

        // PUT: api/Compra/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompraModel(int id, CompraModel compraModel)
        {
            if (id != compraModel.IdCompra)
            {
                return BadRequest();
            }

            _context.Entry(compraModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompraModelExists(id))
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

        // POST: api/Compra
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CompraModel>> PostCompraModel(CompraModel compraModel)
        {
            _context.CompraModel.Add(compraModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompraModel", new { id = compraModel.IdCompra }, compraModel);
        }

        // DELETE: api/Compra/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CompraModel>> DeleteCompraModel(int id)
        {
            var compraModel = await _context.CompraModel.FindAsync(id);
            if (compraModel == null)
            {
                return NotFound();
            }

            _context.CompraModel.Remove(compraModel);
            await _context.SaveChangesAsync();

            return compraModel;
        }

        private bool CompraModelExists(int id)
        {
            return _context.CompraModel.Any(e => e.IdCompra == id);
        }
    }
}
