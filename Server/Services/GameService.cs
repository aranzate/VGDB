using Server.Models;
using Server.Data;
namespace Server.Services;

public class GameService 
{
    readonly private AppDbContext _dbContext;
    public GameService() 
    {
        _dbContext = new AppDbContext();
    }

    public List<Game> GetAll(AppDbContext _dbContext)
    {
        return _dbContext.Game.ToList();
    }

    public Game? Get(AppDbContext _dbContext, int id) 
    { 
        return _dbContext.Game.FirstOrDefault(game => game.Id == id);
    } 

    public void Add(AppDbContext _dbContext, Game game) 
    {
        _dbContext.Game.Add(game);
    }
    public void Update(AppDbContext _dbContext, Game updatedGame) 
    {
        var currentGame = _dbContext.Game.FirstOrDefault(game => updatedGame.Id == game.Id);

        if (currentGame is null) 
        {
            return;
        }

        currentGame.Name = updatedGame.Name;
        currentGame.Image = updatedGame.Image;
        currentGame.Description = updatedGame.Description;
        currentGame.Release = updatedGame.Release;
        currentGame.Series = updatedGame.Series;
        currentGame.Genres = updatedGame.Genres;
        currentGame.Description = updatedGame.Description;
        currentGame.Developer = updatedGame.Developer;
        currentGame.Publisher = updatedGame.Publisher;

    }

    public  void Delete(AppDbContext _dbContext, int id) 
    {
        var game = Get(_dbContext, id);

        if(game is null) 
        {
            return;
        }

        _dbContext.Game.Remove(game);
        _dbContext.SaveChanges();
    }
}