using Server.Models;
using Server.Data;
namespace Server.Services;

public class DeveloperService
{
    private readonly AppDbContext _dbContext;
    public DeveloperService()
    {
        _dbContext = new AppDbContext();
    }
    public List<Developer> GetAll(AppDbContext _dbContext)
    {
        return _dbContext.Developer.ToList();
    }

    public Developer? Get(AppDbContext _dbContext, int id)
    {
        return _dbContext.Developer.FirstOrDefault(developer => developer.Id == id);
    }

    public void Add(AppDbContext _dbContext,Developer developer) 
    {
        _dbContext.Developer.Add(developer);
    }

    public void Update(AppDbContext _dbContext, Developer updatedDeveloper)
    {
        var currentDeveloper = _dbContext.Developer.Find(updatedDeveloper.Id);

        if(currentDeveloper is null)
        {
            return;
        }

        currentDeveloper.Name = updatedDeveloper.Name;
        _dbContext.SaveChanges();
    }

    public void Delete(AppDbContext _dbContext, int id) 
    {
        var developer = Get(_dbContext, id);

        if(developer is null)
        {
            return;
        }

        _dbContext.Remove(developer);
        _dbContext.SaveChanges();
    }
}