using System.Collections.Generic;

public interface IAccountService
{
    List<Account> GetAccounts();
    Account? GetAccountById(int id);
    Account CreateAccount(CreateAccountRequest AccReq);
}