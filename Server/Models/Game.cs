namespace Server.Models;
public class Game
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Image { get; set; }
    public DateOnly Release { get; set; }
    public Developer Developer { get; set; }
    public Publisher Publisher { get; set; }
    public List<Genre> Genres { get; set; }
    public Series Series { get; set; }


}