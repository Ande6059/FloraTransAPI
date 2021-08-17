using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FloraTransAPI.Data;
using FloraTransAPI.Models;

namespace FloraTransAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContainersController : ControllerBase
    {
        private readonly FloraTransAPIContext _context;

        public ContainersController(FloraTransAPIContext context)
        {
            _context = context;
        }

        // GET: api/Containers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Container>>> GetContainer()
        {
            return await _context.Container.ToListAsync();
        }

        [HttpGet("available")]
        public async Task<ActionResult<IEnumerable<Container>>> GetAvailableContainer()
        {
            return await _context.Container.Where(c => c.Available == true).ToListAsync();
        }

        [HttpGet("lost")]
        public async Task<ActionResult<IEnumerable<Container>>> GetLostContainer()
        {
            return await _context.Container.Where(c => c.Lost == true).ToListAsync();
        }

        [HttpGet("rented")]
        public async Task<ActionResult<IEnumerable<Container>>> GetRentedContainer()
        {
            return await _context.Container.Where(c => c.Available == false).ToListAsync();
        }

        // GET: api/Containers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Container>> GetContainer(int id)
        {
            var container = await _context.Container.FindAsync(id);

            if (container == null)
            {
                return NotFound();
            }

            return container;
        }

        // PUT: api/Containers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContainer(int id, Container container)
        {
            if (id != container.CCTag)
            {
                return BadRequest();
            }

            _context.Entry(container).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContainerExists(id))
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

        // POST: api/Containers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Container>> PostContainer(Container container)
        {
            _context.Container.Add(container);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContainer", new { id = container.CCTag }, container);
        }

        // DELETE: api/Containers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContainer(int id)
        {
            var container = await _context.Container.FindAsync(id);
            if (container == null)
            {
                return NotFound();
            }

            _context.Container.Remove(container);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContainerExists(int id)
        {
            return _context.Container.Any(e => e.CCTag == id);
        }
    }
}
