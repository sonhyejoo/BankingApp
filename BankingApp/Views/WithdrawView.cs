using BankingApp.Controllers;
using BankingApp.Interfaces;

namespace BankingApp.Views;

public class WithdrawView: IView<(decimal, decimal)>
{
    public void Show()
    {
        Console.WriteLine("\nWithdraw Menu: \nPlease enter account id: ");
        var id = Console.ReadLine();
        if (!BankController.Instance.TryGetAccount(id))
        {
            Failure();

            return;
        }
        
        Console.WriteLine("Please enter withdrawal amount: ");
        var amount = Console.ReadLine();
        if (!(BankController.Instance.TryParseAmount(amount, out var withdrawAmount) &&
            AccountController.Instance.TryWithdraw(withdrawAmount, out var withdrawAmountAndBalance)))
        {
            Failure();

            return;
        }
        
        Success(withdrawAmountAndBalance);
    }

    public void Success((decimal, decimal) amountAndBalance)
    {
        var (withdrawAmount, 
            balance) = amountAndBalance;
        Console.WriteLine($"""
                           {withdrawAmount:C} successfully withdrawn.
                           Current balance: {balance:C}
                           """);
    }

    public void Failure() => Console.WriteLine("Withdrawal unsuccessful.");
}
