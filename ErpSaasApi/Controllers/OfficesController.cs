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
    public class OfficesController : ControllerBase
    {
        private readonly ErpContext _context;

        public OfficesController(ErpContext context)
        {
            _context = context;
        }

        // GET: api/Offices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Offices>>> GetOffices()
        {
            return await _context.Offices.ToListAsync();
        }

        // GET: api/Offices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Offices>> GetOffices(long id)
        {
            var offices = await _context.Offices.FindAsync(id);

            if (offices == null)
            {
                return NotFound();
            }

            return offices;
        }

        // PUT: api/Offices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOffices(long id, Offices offices)
        {
            if (id != offices.Id)
            {
                return BadRequest();
            }

            _context.Entry(offices).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OfficesExists(id))
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

        // POST: api/Offices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Offices>> PostOffices(Offices offices)
        {
            _context.Offices.Add(offices);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOffices", new { id = offices.Id }, offices);
        }

        // DELETE: api/Offices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOffices(long id)
        {
            var offices = await _context.Offices.FindAsync(id);
            if (offices == null)
            {
                return NotFound();
            }

            _context.Offices.Remove(offices);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OfficesExists(long id)
        {
            return _context.Offices.Any(e => e.Id == id);
        }
    }
}
