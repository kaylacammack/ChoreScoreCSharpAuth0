namespace ChoreScoreCSharpAuth0.Repositories;

public class ChoreRepository
{
    private readonly IDbConnection _db;
    public ChoreRepository(IDbConnection db)
    {
        _db = db;
    }

}
