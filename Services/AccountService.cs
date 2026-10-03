
public class AccountService : IAccountService
{
    public List<string> GetAccounts()
    {
        var acc=new List<string> { "Savings","Current","Cash" };
        return acc;
    }
}