namespace BankingApp.Interfaces;

public interface ITransactionView<in T>:  IView
{
    void Success(T? value);
    void Failure();
}