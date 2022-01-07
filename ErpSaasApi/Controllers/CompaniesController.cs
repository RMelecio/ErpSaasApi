﻿#nullable disable
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
    public class CompaniesController : ControllerBase
    {
        private readonly ErpContext _context;

        public CompaniesController(ErpContext context)
        {
            _context = context;
        }

        // GET: api/Companies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Companies>>> GetCompanies()
        {
            return await _context.Companies.ToListAsync();
        }

        // GET: api/Companies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Companies>> GetCompanies(long id)
        {
            var companies = await _context.Companies.FindAsync(id);

            if (companies == null)
            {
                return NotFound();
            }

            return companies;
        }

        // PUT: api/Companies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompanies(long id, Companies companies)
        {
            if (id != companies.Id)
            {
                return BadRequest();
            }

            _context.Entry(companies).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompaniesExists(id))
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

        // POST: api/Companies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Companies>> PostCompanies(Companies companies)
        {
            _context.Companies.Add(companies);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompanies", new { id = companies.Id }, companies);
        }

        // DELETE: api/Companies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompanies(long id)
        {
            var companies = await _context.Companies.FindAsync(id);
            if (companies == null)
            {
                return NotFound();
            }

            _context.Companies.Remove(companies);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CompaniesExists(long id)
        {
            return _context.Companies.Any(e => e.Id == id);
        }
    }
}
