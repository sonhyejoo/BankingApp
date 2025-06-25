using BankingApp.Controllers;
using BankingApp.Interfaces;
using BankingApp.Models;

namespace BankingApp.Views;

public class CheckBalanceView: IView<decimal>
{
    public void Show()
    {
        Console.WriteLine("\nChecking balance: \nPlease enter account id:");
        var userInput = Console.ReadLine();
        if (BankController.Instance.TryGetAccount(userInput))
        {
            Success(AccountController.Instance.GetBalance());
        }
        else
        {
            Failure();
        }
    }

    public void Success(decimal balance)
    {
        Console.WriteLine($"Current balance is: {balance:C}");
    }

    public void Failure()
    {
        Console.WriteLine("Invalid id entered. Account not found.");
    }

}