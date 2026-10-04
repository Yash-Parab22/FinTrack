public class Transaction
{
    public int Id{get;set;}
    public int AccountId{get;set;}
    public decimal Amount{get;set;}
    public DateTime Date{get;set;}
    public string Description{get;set;}=string.Empty;
    public string Category{get;set;}=string.Empty;
    public TransactionType Type{get;set;}
    public DateTime CreatedAt {get;set;}

}