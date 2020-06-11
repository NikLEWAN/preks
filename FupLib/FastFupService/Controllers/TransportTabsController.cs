using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FastFupService.Models;

namespace FastFupService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransportTabsController : ControllerBase
    {
        private readonly TransportTabContext _context;

        public TransportTabsController(TransportTabContext context)
        {
            _context = context;
        }

        // GET: api/TransportTabs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransportTab>>> GetTransportTabs()
        {
            return await _context.TransportTabs.ToListAsync();
        }

        // GET: api/TransportTabs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TransportTab>> GetTransportTab(long id)
        {
            var transportTab = await _context.TransportTabs.FindAsync(id);

            if (transportTab == null)
            {
                return NotFound();
            }

            return transportTab;
        }


        // GET: api/TransportTabs/Lastbil/A
        [HttpGet("Lastbil/{lastbil}")]
        public async Task<ActionResult<IEnumerable<TransportTab>>> GetTransportTabsLastbil(string lastbil)
        {
            var transportTab = await _context.TransportTabs.Where(e => e.Lastbil == lastbil).ToListAsync();
            if (transportTab == null)
            {
                return NotFound();
            }
            return transportTab;
        }


        // PUT: api/TransportTabs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransportTab(long id, TransportTab transportTab)
        {
            if (id != transportTab.Id)
            {
                return BadRequest();
            }

            _context.Entry(transportTab).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransportTabExists(id))
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

        // POST: api/TransportTabs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TransportTab>> PostTransportTab(TransportTab transportTab)
        {
            _context.TransportTabs.Add(transportTab);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTransportTab), new { id = transportTab.Id }, transportTab);
            //cheap return method: return CreatedAtAction("GetTransportTab", new { id = transportTab.Id }, transportTab);
        }

        // DELETE: api/TransportTabs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TransportTab>> DeleteTransportTab(long id)
        {
            var transportTab = await _context.TransportTabs.FindAsync(id);
            if (transportTab == null)
            {
                return NotFound();
            }

            _context.TransportTabs.Remove(transportTab);
            await _context.SaveChangesAsync();

            return transportTab;
        }

        private bool TransportTabExists(long id)
        {
            return _context.TransportTabs.Any(e => e.Id == id);
        }
    }
}
