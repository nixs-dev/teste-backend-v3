using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheatricalPlayersRefactoringKata.DTOs;
using TheatricalPlayersRefactoringKata.Models;

namespace TheatricalPlayersRefactoringKata.Controllers.Controllers;


[Route("api/[controller]")]
[ApiController]
public class PlayController : ControllerBase
{
    private readonly TheatreContext _context;

    public PlayController(TheatreContext context)
    {
        _context = context;
    }

    // GET: api/play
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Play>>> All()
    {
        return await _context.plays.ToListAsync();
    }

    // GET: api/play/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Play>> Get(int id)
    {
        var play = await _context.plays.FindAsync(id);

        if (play == null)
        {
            return NotFound("Peça não encontrada!");
        }

        return play;
    }

    // POST: api/play
    [HttpPost]
    public async Task<ActionResult<Play>> Create([FromBody] PlayDTO request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        Play play = new Play();
        play.Name = request.Name;
        play.Lines = request.Lines;
        play.Type = request.Type;

        _context.plays.Add(play);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Get), new { id = play.Id }, play);
    }

    // PUT: api/play/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Play play)
    {
        if (id != play.Id)
        {
            return BadRequest("ID inválido!");
        }

        _context.Entry(play).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!Exists(id))
            {
                return NotFound("Peça não encontrada!");
            }
            else
            {
                throw;
            }
        }

        return Ok();
    }

    // DELETE: api/play/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var play = await _context.plays.FindAsync(id);
        if (play == null)
        {
            return NotFound("Peça não encontrada!");
        }

        _context.plays.Remove(play);
        await _context.SaveChangesAsync();

        return Ok();
    }

    private bool Exists(int id)
    {
        return _context.plays.Any(e => e.Id == id);
    }
}