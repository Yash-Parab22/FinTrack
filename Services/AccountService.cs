
public class AccountService : IAccountService
{
    public List<Account> acc=new List<Account> {};
    private int _nextId=1;
    public AccountService()
    {
        for (int i=0; i < 5; i++)
        {
            Account g=new Account();
            g.Id=_nextId;
            g.Name="BLUE";
            g.Balance=i*100;
            g.CreatedAt= DateTime.Now;
            g.Type="idk bro";
            acc.Add(g);
            _nextId++;
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
    public Account CreateAccount(CreateAccountRequest AccReq)
    {
        Account newAc=new Account();
        newAc.Name=AccReq.Name;
        newAc.Balance=AccReq.Balance;
        newAc.Type=AccReq.Type;
        newAc.CreatedAt=DateTime.Now;
        newAc.Id=_nextId;
        acc.Add(newAc);
        _nextId++;
        return newAc;
    }
    public Account? UpdateAccount(int Id,UpdateAccountRequest uar)
    {
        Account? act= acc.FirstOrDefault(a => a.Id == Id);
        if(act==null) return act;
        act.Name=uar.Name;
        act.Type=uar.Type;
        return act;
    }
    public bool DeleteAccount(int Id)
    {   
        Account? act=acc.FirstOrDefault(a=> a.Id==Id);
        if(act==null) return false;
        acc.Remove(act);
        return true;
    }
}