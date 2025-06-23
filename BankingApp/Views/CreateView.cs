using BankingApp.Models;

namespace BankingApp.Views;

public static class CreateView
{
    internal static string? CreateAccountMenu()
    {
        Console.Clear();
        Console.WriteLine("Account creation: \n");
        Console.WriteLine("Please enter account holder's name: ");
        return Console.ReadLine();
    }

    internal static void CreateAccountInvalidName()
    {
        Console.WriteLine("Name cannot be empty.");
    }

    internal static void CreateAccountSuccess(Account newAccount)
    {
        Console.WriteLine("New bank account created with the following details: ");
        Console.WriteLine($"Name of account holder: {newAccount.Name}");
        Console.WriteLine($"Account's initial balance: ${newAccount.Balance}");
        Console.WriteLine($"Account number used for access: {newAccount.AccountNumber}");
    }
}