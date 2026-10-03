
public class AccountService : IAccountService
{
    public List<Account> acc=new List<Account> {};
    public AccountService()
    {
        for (int i=0; i < 5; i++)
        {
            Account g=new Account();
            g.Id=i;
            g.Name="BLUE";
            g.Balance=i*100;
            g.CreatedAt= DateTime.Now;
            g.Type="idk bro";
            acc.Add(g);
        }
    }
    public List<Account> GetAccounts()
    {   
        return acc;
    }
    public Account? GetAccountById(int Id)
    {
        return acc.FirstOrDefault(a => a.Id == Id);
    }
}