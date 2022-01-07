#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ErpSaasApi.Models;

namespace ErpSaasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WareHousesController : ControllerBase
    {
        private readonly ErpContext _context;

        public WareHousesController(ErpContext context)
        {
            _context = context;
        }

        // GET: api/WareHouses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WareHouses>>> GetWareHouses()
        {
            return await _context.WareHouses.ToListAsync();
        }

        // GET: api/WareHouses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WareHouses>> GetWareHouses(long id)
        {
            var wareHouses = await _context.WareHouses.FindAsync(id);

            if (wareHouses == null)
            {
                return NotFound();
            }

            return wareHouses;
        }

        // PUT: api/WareHouses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWareHouses(long id, WareHouses wareHouses)
        {
            if (id != wareHouses.Id)
            {
                return BadRequest();
            }

            _context.Entry(wareHouses).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WareHousesExists(id))
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

        // POST: api/WareHouses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WareHouses>> PostWareHouses(WareHouses wareHouses)
        {
            _context.WareHouses.Add(wareHouses);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWareHouses", new { id = wareHouses.Id }, wareHouses);
        }

        // DELETE: api/WareHouses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWareHouses(long id)
        {
            var wareHouses = await _context.WareHouses.FindAsync(id);
            if (wareHouses == null)
            {
                return NotFound();
            }

            _context.WareHouses.Remove(wareHouses);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WareHousesExists(long id)
        {
            return _context.WareHouses.Any(e => e.Id == id);
        }
    }
}
