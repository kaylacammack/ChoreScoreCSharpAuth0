namespace ChoreScoreCSharpAuth0.Models;

public class Chore
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Category { get; set; }
    public string Day { get; set; }
    public bool Completed { get; set; }
    public string CreatorId { get; set; }
}
