using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AccountsController : ControllerBase
{   
    private IAccountService _accountService;
    public AccountsController(IAccountService x)
    {
        _accountService=x;
    }
    [HttpGet]
    
    public IActionResult GetAccounts()
    {
        return Ok(_accountService.GetAccounts());
    }
    
}