using BankingApp.Controllers;
using BankingApp.Interfaces;

namespace BankingApp.Views;

public class CreateView: IView<(Guid, string, decimal)>
{
    public void Show()
    {
        Console.WriteLine("\nAccount creation: \n");
        Console.WriteLine("Please enter account holder's name: ");
        var name = Console.ReadLine();
        if (BankController.Instance.TryCreateAccount(name, out var account))
        {
            Success(account);
        }
        else
        {
            Failure();
        }
    }

    public void Success((Guid, string, decimal) details)
    {
        var (id,
            name,
            balance) = details;
        Console.WriteLine($"""
                          New bank account created with the following details:
                          Name of account holder: {name}
                          Account's initial balance: {balance.ToString("C")}
                          Account number used for access: {id}
                          """);
    }

    public void Failure()
    {
        Console.WriteLine("Name cannot be empty or whitespace.");
    }
}