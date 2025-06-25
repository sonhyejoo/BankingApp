using BankingApp.Controllers;
using BankingApp.Interfaces;

namespace BankingApp.Views;

public class DepositView: IView<(decimal, decimal)>
{
    public void Show()
    {
        Console.WriteLine("\nDeposit Funds: \n");
        Console.WriteLine("Please enter account id: ");
        var userInput = Console.ReadLine();
        if (BankController.Instance.TryGetAccount(userInput))
        {
            Console.WriteLine("Please enter deposit amount: ");
            userInput = Console.ReadLine();
            if (BankController.Instance.TryParseAmount(userInput, out var amount) &&
                AccountController.Instance.TryDeposit(amount, out var amountAndBalance))
            {
                Success(amountAndBalance);

                return;
            }
        }
        
        Failure();
    }

    public void Success((decimal, decimal) values)
    {
        var (depositAmount, balance) = values;
        Console.WriteLine($"""
            ${depositAmount:C} successfully deposited.");
            Current balance: {balance:C} 
            """);
    }
    
    public void Failure()
    {
        Console.WriteLine("Deposit unsuccessful.");
    }
}