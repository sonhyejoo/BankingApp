using BankingApp.Controllers;
using BankingApp.Interfaces;

namespace BankingApp.Views;

public class WithdrawView: IView<(decimal, decimal)>
{
    public void Show()
    {
        Console.WriteLine("\nWithdraw Menu: \nPlease enter account id: ");
        var userInput = Console.ReadLine();
        if (!BankController.Instance.TryGetAccount(userInput))
        {
            Failure();

            return;
        }
        
        Console.WriteLine("Please enter withdrawal amount: ");
        userInput = Console.ReadLine();
        if (!(BankController.Instance.TryParseAmount(userInput, out var amount) &&
            AccountController.Instance.TryWithdraw(amount, out var amountAndBalance)))
        {
            Failure();

            return;
        }
        
        Success(amountAndBalance);
    }

    public void Success((decimal, decimal) amountAndBalance)
    {
        var (amount, 
            balance) = amountAndBalance;
        Console.WriteLine($"""
                           {amount:C} successfully withdrawn.
                           Current balance: {balance:C}" 
                           """);
    }

    public void Failure()
    {
        Console.WriteLine("Withdrawal unsuccessful.");
    }

}
