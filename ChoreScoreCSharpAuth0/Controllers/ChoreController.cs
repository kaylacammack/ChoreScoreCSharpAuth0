namespace ChoreScoreCSharpAuth0.Controllers;

[ApiController]
[Route("api/chores")]
public class ChoreController : ControllerBase
{
    private readonly ChoreService _choreService;
    private readonly Auth0Provider _auth0provider;
    public ChoreController(ChoreService choreService, Auth0Provider auth0provider)
    {
        _choreService = choreService;
        _auth0provider = auth0provider;
    }
}
