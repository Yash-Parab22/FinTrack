public class Account
{
    public int Id {get; set;}
    public string Name { get; set;} = String.Empty;
    public string Type {get; set;} = String.Empty;
    public decimal Balance {get; set;}
    public DateTime CreatedAt {get; set;}
}