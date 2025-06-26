namespace BankingApp.Interfaces;

public interface ITransactionView<in T>: IView<T>
{
    string? GetAmount();
}