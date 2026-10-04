

public class TransactionService : ITransactionService
{
    private readonly IAccountService _acc_serv;
    public TransactionService(IAccountService ax)
    {
        _acc_serv=ax;
    }
    public List<Transaction> All_Transactions=new List<Transaction>();
    private int next_transId=1;
    public List<Transaction> GetTransactions()
    {
        return All_Transactions;
    }
    public Transaction? GetTransactionById(int Id)
    {
        Transaction? a=All_Transactions.FirstOrDefault(b=> b.Id==Id);
        return a; 
    }
    public List<Transaction>? GetTransactionsByAccount(int AccountId)
    {   
        if(_acc_serv.GetAccountById(AccountId)==null) return null;
        List<Transaction>? AccountTransactions= All_Transactions.Where(b=>b.AccountId==AccountId).ToList();
        return AccountTransactions;
    }
    public Transaction? CreateTransaction(CreateTransactionRequest req)
    {
        Transaction newT=new Transaction();
        newT.AccountId=req.AccountId;
        newT.Amount=req.Amount;
        Account? ac= _acc_serv.GetAccountById(newT.AccountId);
        if(ac==null) return null;
        newT.Category=req.Category;
        newT.Date=req.Date;
        newT.Description=req.Description;
        newT.Type=req.Type;
        if (newT.Type != TransactionType.Income && ac.Balance < newT.Amount)
        {
            return null;
        }
        if (newT.Type == TransactionType.Income)
        {
            ac.Balance+= newT.Amount;
        }else if (newT.Type == TransactionType.Expense || newT.Type==TransactionType.Transfer)
        {
            ac.Balance-=newT.Amount;
        }
        newT.Id=next_transId;
        All_Transactions.Add(newT);
        next_transId++;
        newT.CreatedAt=DateTime.Now;
        return newT;
    }
    public bool DeleteTransaction(int Id)
    {
        Transaction? t= All_Transactions.FirstOrDefault(a=>a.Id==Id);
        if(t==null) return false;
        Account? ac= _acc_serv.GetAccountById(t.AccountId);
        if(ac==null) return false;
        if (t.Type == TransactionType.Income)
        {
            ac.Balance-= t.Amount;
        }else if (t.Type == TransactionType.Expense ||t.Type==TransactionType.Transfer)
        {
            ac.Balance+=t.Amount;
        }
        All_Transactions.Remove(t);
        return true;
    }
    
}