using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using movieapplication.Data;
using movieapplication.Model;

namespace movieapplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public MovieController(ApplicationDbContext context) => _context = context;


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = _context.Movies.Include(x => x.MoviesActorIds).ThenInclude(x => x.Actor)
                .Select(x => new
                {
                    id = x.MovieId,
                    actorName = x.MovieName,
                    producerName = x.ProducerName,
                    movies = x.MoviesActorIds.Select(k => k.Actor.ActorName).ToList()
                });
            return data == null ? NotFound() : Ok(data);
        }

        [HttpGet("id")]
        [ProducesResponseType(typeof(Movie), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByMovieId(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            return movie == null ? NotFound() : Ok(movie);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(Movie movie)
        {
            await _context.Movies.AddAsync(movie);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetByMovieId), new { id = movie.MovieId }, movie);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, Movie movie)
        {
            if (id != movie.MovieId) return BadRequest();

            _context.Entry(movie).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var movieToDelete = await _context.Movies.FindAsync(id);
            if (movieToDelete == null) return NotFound();

            _context.Movies.Remove(movieToDelete);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
