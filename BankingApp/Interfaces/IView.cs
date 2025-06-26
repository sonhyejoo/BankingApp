namespace BankingApp.Interfaces;

public interface IView<in T>
{
    string? GetNameOrId();
    void Success(T? value);
    void Failure();
}