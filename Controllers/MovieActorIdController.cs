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
        public MovieActorIdController(ApplicationDbContext context) => _context = context;


        [HttpGet]
        public async Task<IEnumerable<MovieActorId>> Get()
            => await _context.MoviesActorIds.ToListAsync();

        [HttpGet("id")]
        [ProducesResponseType(typeof(MovieActorId), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByMovieActorIdId(int id)
        {
            var movieactorid = await _context.MoviesActorIds.FindAsync(id);
            return movieactorid == null ? NotFound() : Ok(movieactorid);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(MovieActorId movieactorid)
        {
            await _context.MoviesActorIds.AddAsync(movieactorid);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetByMovieActorIdId), new { id = movieactorid.Id }, movieactorid);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, MovieActorId movieactorid)
        {
            if (id != movieactorid.Id) return BadRequest();

            _context.Entry(movieactorid).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var MovieActorIdToDelete = await _context.MoviesActorIds.FindAsync(id);
            if (MovieActorIdToDelete == null) return NotFound();

            _context.MoviesActorIds.Remove(MovieActorIdToDelete);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
