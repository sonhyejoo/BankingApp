using BankingApp.Controllers;
using BankingApp.Interfaces;

namespace BankingApp.Views;

public class CreateView: IView<(Guid, string, decimal)>
{
    public string? GetNameOrId()
    {
        Console.WriteLine("\nAccount creation: \nPlease enter account holder's name: ");
        return Console.ReadLine();
    }

    public void Success((Guid, string, decimal) details)
    {
        var (id,
            name,
            balance) = details;
        Console.WriteLine($"""
                           New bank account created with the following details:
                           Name of account holder: {name}
                           Account's initial balance: {balance:C}
                           Account number used for access: {id}
                           """);
    }

    public void Failure() => Console.WriteLine("Name cannot be empty or whitespace.");
}