using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using movieapplication.Data;
using movieapplication.Model;

namespace movieapplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ActorController(ApplicationDbContext context) => _context = context;


        [HttpGet]
        public async Task<IEnumerable<Actor>> Get()
            => await _context.Actors.ToListAsync();

        [HttpGet("id")]
        [ProducesResponseType(typeof(Actor), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByActorId(int id)
        {
            var actor = await _context.Actors.FindAsync(id);
            return actor == null ? NotFound() : Ok(actor);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(Actor actor)
        {
            await _context.Actors.AddAsync(actor);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetByActorId), new {id = actor.ActorId}, actor);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, Actor actor)
        {
            if (id != actor.ActorId) return BadRequest();

            _context.Entry(actor).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var actorToDelete = await _context.Actors.FindAsync(id);
            if (actorToDelete == null) return NotFound();

            _context.Actors.Remove(actorToDelete);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
