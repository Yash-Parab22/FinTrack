using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AccountsController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAccounts()
    {
        var acco = new List<string> { "Savings","Current","Cash" };
        return Ok(acco);
    }
}