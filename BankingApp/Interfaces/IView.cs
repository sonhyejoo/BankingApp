namespace BankingApp.Interfaces;

public interface IView<in T>
{
    void Show();
    void Success(T? value);
    void Failure();
}