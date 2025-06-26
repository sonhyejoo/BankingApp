using BankingApp.Controllers;
using BankingApp.Interfaces;
using BankingApp.Models;

namespace BankingApp.Views;

public class CheckBalanceView: IIdentifiable, IFailable<decimal>
{
    public string? GetId()
    {
        Console.WriteLine("\nChecking balance: \nPlease enter account id:");
        return Console.ReadLine();
    }

    public void Success(decimal balance) => Console.WriteLine($"Current balance is: {balance:C}");

    public void Failure() => Console.WriteLine("Invalid id entered. Account not found.");
}