using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AccountsController : ControllerBase
{   
    private readonly IAccountService _accountService;
    private readonly ITransactionService _transactionService;
    public AccountsController(IAccountService x,ITransactionService y)
    {
        _accountService=x;
        _transactionService=y;
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

    [HttpPut("{id}")]

    public IActionResult UpdateAccount(int id, [FromBody] UpdateAccountRequest req)
    {
        Account? updAcc=_accountService.UpdateAccount(id,req);
        if (updAcc != null)
        {
            return Ok(updAcc);
        }
        else
        {
            return NotFound();
        }
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteAccount(int id)
    {
        bool deleteSuccess=_accountService.DeleteAccount(id);
        if (!deleteSuccess)
        {
            return NotFound();
        }
        else
        {
            return NoContent();
        }
    }
    [HttpGet("{id}/transactions")]
    public IActionResult GetTrancationsByAccount(int id)
    {
        List<Transaction>? allT= _transactionService.GetTransactionsByAccount(id);
        if (allT == null)
        {
            return BadRequest();
        }
        else
        {
            return Ok(allT);
        }
    }
}