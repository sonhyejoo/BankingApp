namespace BankingApp.Interfaces;

public interface IFailable<in T>
{
    void Success(T? value);
    void Failure();
}