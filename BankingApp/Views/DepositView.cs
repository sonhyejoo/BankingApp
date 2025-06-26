using BankingApp.Controllers;
using BankingApp.Interfaces;

namespace BankingApp.Views;

public class DepositView: ITransactionView<(decimal, decimal)>
{
    public string? GetNameOrId()
    {
        Console.WriteLine("\nDeposit Funds: \nPlease enter account id: ");
        return Console.ReadLine();

    }

    public string? GetAmount()
    {
        Console.WriteLine("Please enter deposit amount: ");
        return Console.ReadLine();
    }

    public void Success((decimal, decimal) values)
    {
        var (depositAmount, 
            balance) = values;
        Console.WriteLine($"""
                           {depositAmount:C} successfully deposited.
                           Current balance: {balance:C} 
                           """);
    }
    
    public void Failure() => Console.WriteLine("Deposit unsuccessful.");
}