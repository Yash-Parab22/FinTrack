using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AccountsController : ControllerBase
{   
    private readonly IAccountService _accountService;
    public AccountsController(IAccountService x)
    {
        _accountService=x;
    }
    [HttpGet]
    
    public IActionResult GetAccounts()
    {
        return Ok(_accountService.GetAccounts());
    }

    [HttpGet("{id}")]

    public IActionResult GetAccountById(int id)
    {
        var id_res=_accountService.GetAccountById(id);
        if (id_res == null)
        {
            return NotFound();
        }
        else
        {
            return Ok(id_res);
        }
    }

    [HttpPost]
    public IActionResult CreateAccount([FromBody] CreateAccountRequest AccReq)
    {
        var result=_accountService.CreateAccount(AccReq);
        return Created($"/api/accounts/{result.Id}",result);
    }
    
}