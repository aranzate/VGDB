namespace Server.Models;
public class Series 
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Game> Games { get; set; }
}