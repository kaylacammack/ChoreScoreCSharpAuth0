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

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Chore>> Create([FromBody] Chore choreData)
    {
        try
        {
            Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
            choreData.CreatorId = userInfo.Id;
            Chore chore = _choreService.Create(choreData);
            return Ok(chore);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    public async Task<ActionResult<List<Chore>>> Get()
    {
        try
        {
            Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
            List<Chore> chores = _choreService.Get(userInfo?.Id);
            return Ok(chores);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Chore>> GetChoreById(int id)
    {
        try
        {
            Account userInfo = await _auth0provider.GetUserInfoAsync<Account>(HttpContext);
            Chore chore = _choreService.GetChoreById(id);
            return Ok(chore);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("{id}")]
    public ActionResult<Chore> Update([FromBody] Chore choreUpdate, int id)
    {
        try
        {
            Chore chore = _choreService.Update(choreUpdate, id);
            return Ok(chore);

        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }


}
