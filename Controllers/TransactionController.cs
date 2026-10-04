using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class TransactionController : ControllerBase
{   
    private readonly IAccountService _accountService;
    private readonly ITransactionService _transactionService;
    public TransactionController(IAccountService x, ITransactionService y)
    {
        _accountService=x;
        _transactionService=y;
    }
    [HttpGet]
    public IActionResult GetTransactions()
    {
        return Ok(_transactionService.GetTransactions());
    }
    [HttpGet("{id}")]
    public IActionResult GetTransactionById(int id)
    {
        Transaction? T=_transactionService.GetTransactionById(id);
        if (T == null)
        {
            return NotFound();
        }
        else
        {
            return Ok(T);
        }
    }
    [HttpPost]
    public IActionResult CreateTransaction([FromBody] CreateTransactionRequest ctr)
    {
        Account? c=_accountService.GetAccountById(ctr.AccountId);
        if(c==null) return NotFound();
        Transaction? T=_transactionService.CreateTransaction(ctr);
        if (T == null)
        {
            return BadRequest();
        }
        else
        {
            return  Created($"/api/transactions/{T.Id}",T);
        }
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteTransaction(int id)
    {
        bool deleteSuccess= _transactionService.DeleteTransaction(id);
        if (deleteSuccess)
        {
            return NoContent();
        }
        else
        {
            return NotFound();
        }
    }
}