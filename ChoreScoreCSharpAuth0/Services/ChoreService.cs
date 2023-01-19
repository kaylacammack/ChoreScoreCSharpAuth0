namespace ChoreScoreCSharpAuth0.Services;

public class ChoreService
{
    private readonly ChoreRepository _repo;
    public ChoreService(ChoreRepository repo)
    {
        _repo = repo;
    }
}
