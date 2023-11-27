using Server.Models;
using Server.Services;
using Microsoft.AspNetCore.Mvc;


namespace Server.Controllers;

[ApiController]
[Route("[controller]")]
public class GameController : ControllerBase
{
    public GameController()
    {

    }
    [HttpGet]
    public ActionResult<List<Game>> GetAll() => 
        GameService.GetAll();
    
    [HttpGet("{id}")]
    public ActionResult<Game> Get(int id)
    {
        var game = GameService.Get(id);
        if(game is null) 
            return NotFound();

        return game;
    }

    [HttpPost]
    public IActionResult Post(Game game)
    {
        GameService.Add(game);

        return CreatedAtAction(nameof(Get), new { id = game.Id }, game);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Game game)
    {
        if(id != game.Id) 
            return BadRequest();

        var existingGame = GameService.Get(id);
        if(existingGame is null)
            return NotFound();
        
        GameService.Update(game);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var game = GameService.Get(id);

        if(game is null)
            return NotFound();
        
        GameService.Delete(id);

        return NoContent();
    }
}