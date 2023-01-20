namespace ChoreScoreCSharpAuth0.Services;

public class ChoreService
{
    private readonly ChoreRepository _repo;
    public ChoreService(ChoreRepository repo)
    {
        _repo = repo;
    }

    internal Chore Create(Chore choreData)
    {
        Chore chore = _repo.Create(choreData);
        return chore;
    }

    internal List<Chore> Get(string userId)
    {
        List<Chore> chores = _repo.Get();
        List<Chore> filtered = chores.FindAll(c => c.CreatorId == userId);
        return filtered;
    }



    internal Chore GetChoreById(int id)
    {
        Chore chore = _repo.GetChoreById(id);
        if (chore == null)
        {
            throw new Exception("No chore at that id");
        }
        return chore;
    }

    internal Chore Update(Chore choreUpdate, int id)
    {
        Chore original = GetChoreById(id);
        if (original.CreatorId != userId)
        {
            throw new Exception("Not your chore")
        }
        original.Title = choreUpdate.Title ?? original.Title;
        original.Category = choreUpdate.Category ?? original.Category;
        original.Day = choreUpdate.Day ?? original.Day;
        original.Completed = choreUpdate.Completed ?? original.Completed;


        bool edited = _repo.Update(original);
        if (edited == false)
        {
            throw new Exception("Chore was not edited");
        }
        return original;
    }

    internal Chore UpdateCompleted(int id, string userId)
    {
        Chore original = GetChoreById(id);
        if (original.CreatorId != userId)
        {
            throw new Exception("Not your chore");
        }
        original.Completed = !original.Completed;
        _repo.Update(original);
        return original;
    }


}
