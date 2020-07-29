using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CodeTrack.Models;

namespace CodeTrack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackersController : ControllerBase
    {
        private readonly TrackerContext _context;

        public TrackersController(TrackerContext context)
        {
            _context = context;
        }

        // GET: api/Trackers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tracker>>> GetTracker()
        {
            return await _context.Tracker.ToListAsync();
        }

        // GET: api/Trackers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tracker>> GetTracker(int id)
        {
            var tracker = await _context.Tracker.FindAsync(id);

            if (tracker == null)
            {
                return NotFound();
            }

            return tracker;
        }

        // PUT: api/Trackers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTracker(int id, Tracker tracker)
        {
            if (id != tracker.entryId)
            {
                return BadRequest();
            }

            _context.Entry(tracker).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrackerExists(id))
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

        // POST: api/Trackers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Tracker>> PostTracker(Tracker tracker)
        {

            try
            {
                _context.Tracker.Add(tracker);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetTracker", new { id = tracker.entryId }, tracker);

            } catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return BadRequest(exception.Message);
               
            }
           
        }

        // DELETE: api/Trackers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tracker>> DeleteTracker(int id)
        {
            var tracker = await _context.Tracker.FindAsync(id);
            if (tracker == null)
            {
                return NotFound();
            }

            _context.Tracker.Remove(tracker);
            await _context.SaveChangesAsync();

            return tracker;
        }

        private bool TrackerExists(int id)
        {
            return _context.Tracker.Any(e => e.entryId == id);
        }
    }
}
