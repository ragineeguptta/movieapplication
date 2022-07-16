using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using movieapplication.Data;
using movieapplication.Model;

namespace movieapplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieActorIdController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MovieActorIdController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/MovieActorId
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieActorId>>> GetMoviesActorIds()
        {
          if (_context.MoviesActorIds == null)
          {
              return NotFound();
          }
            return await _context.MoviesActorIds.ToListAsync();
        }

        // GET: api/MovieActorId/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieActorId>> GetMovieActorId(int id)
        {
          if (_context.MoviesActorIds == null)
          {
              return NotFound();
          }
            var movieActorId = await _context.MoviesActorIds.FindAsync(id);

            if (movieActorId == null)
            {
                return NotFound();
            }

            return movieActorId;
        }

        // PUT: api/MovieActorId/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovieActorId(int id, MovieActorId movieActorId)
        {
            if (id != movieActorId.Id)
            {
                return BadRequest();
            }

            _context.Entry(movieActorId).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieActorIdExists(id))
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

        // POST: api/MovieActorId
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MovieActorId>> PostMovieActorId(MovieActorId movieActorId)
        {
          if (_context.MoviesActorIds == null)
          {
              return Problem("Entity set 'ApplicationDbContext.MoviesActorIds'  is null.");
          }
            _context.MoviesActorIds.Add(movieActorId);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMovieActorId", new { id = movieActorId.Id }, movieActorId);
        }

        // DELETE: api/MovieActorId/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovieActorId(int id)
        {
            if (_context.MoviesActorIds == null)
            {
                return NotFound();
            }
            var movieActorId = await _context.MoviesActorIds.FindAsync(id);
            if (movieActorId == null)
            {
                return NotFound();
            }

            _context.MoviesActorIds.Remove(movieActorId);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MovieActorIdExists(int id)
        {
            return (_context.MoviesActorIds?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
