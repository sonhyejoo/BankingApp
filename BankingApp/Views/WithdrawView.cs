using BankingApp.Controllers;
using BankingApp.Interfaces;

namespace BankingApp.Views;

public class WithdrawView: IView<(decimal, decimal)>
{
    public void Show()
    {
        Console.WriteLine("\nWithdraw Menu: \n");
        Console.WriteLine("Please enter account id: ");
        var userInput = Console.ReadLine();
        if (BankController.Instance.TryGetAccount(userInput))
        {
            Console.WriteLine("Please enter withdrawal amount: ");
            userInput = Console.ReadLine();
            if (BankController.Instance.TryParseAmount(userInput, out var amount))
            {
                if (AccountController.Instance.TryWithdraw(amount, out var amountAndBalance))
                {
                    Success(amountAndBalance);
                    
                    return;
                }
            }
        }
        
        Failure();
    }

    public void Success((decimal, decimal) amountAndBalance)
    {
        (decimal amount, decimal balance) = amountAndBalance;
        Console.WriteLine($"{amount:C} successfully withdrawn.");
        Console.WriteLine($"Current balance: ${balance:C}");
    }

    public void Failure()
    {
        Console.WriteLine("Withdrawal unsuccessful.");
    }

}
