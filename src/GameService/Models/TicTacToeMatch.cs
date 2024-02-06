using MongoDB.Entities;

namespace GameService;

public class TicTacToeMatch : Entity
{
    public List<TicTacToeRow> Match { get; set; }
    public string CrossesPlayer { get; set; }
    public string NaughtsPlayer { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Winner { get; set; }
    public string Loser { get; set; }
}
