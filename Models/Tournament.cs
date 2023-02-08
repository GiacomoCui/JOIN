
namespace JOIN.Models;

public class Tournament
{
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public string Game { get; set; }
    public string Location { get; set; }

    public Tournament(string name, DateTime date, string game, string location)
    {
        Name = name;
        Date = date;
        Game = game;
        Location = location;
    }
}
