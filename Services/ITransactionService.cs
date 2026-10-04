public interface ITransactionService
{
    List<Transaction> GetTransactions();
    Transaction? GetTransactionById(int Id);
    List<Transaction>? GetTransactionsByAccount(int AccountId);
    Transaction? CreateTransaction(CreateTransactionRequest tReq);
    bool DeleteTransaction(int Id);
}