namespace ChoreScoreCSharpAuth0.Repositories;

public class ChoreRepository
{
    private readonly IDbConnection _db;
    public ChoreRepository(IDbConnection db)
    {
        _db = db;
    }

    internal Chore Create(Chore choreData)
    {
        string sql = @"
        INSERT INTO chores
        (title, category, day, creatorId)
        VALUES
        (@title, @category, @day, @creatorId);
        SELECT LAST_INSERT_ID();
        ";
        int id = _db.ExecuteScalar<int>(sql, choreData);
        choreData.Id = id;
        return choreData;
    }

    internal List<Chore> Get()
    {
        string sql = @"
        SELECT * FROM chores
        JOIN accounts ON accounts.id = chores.creatorId;
        ";
        List<Chore> chores = _db.Query<Chore, Account, Chore>(sql, (chore, account) =>
        {
            chore.Creator = account;
            return chore;
        }).ToList();
        return chores;
    }

    internal Chore GetChoreById(int id)
    {
        string sql = @"
        SELECT *
        FROM chores
        JOIN accounts ON accounts.id = chores.creatorId
        WHERE chores.id = @id;
        ";
        return _db.Query<Chore, Account, Chore>(sql, (chore, account) =>
        {
            chore.Creator = account;
            return chore;
        }, new { id }).FirstOrDefault();
    }

    internal bool Update(Chore update)
    {
        string sql = @"
        UPDATE chores
        SET
        title = @title,
        category = @category,
        day = @day,
        completed = @completed
        WHERE id = @id;
        ";
        int rows = _db.Execute(sql, update);
        return rows > 0;
    }

}
