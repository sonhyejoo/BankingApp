using BankingApp.Controllers;
using BankingApp.Interfaces;

namespace BankingApp.Views;

public class DepositView: IView<(decimal, decimal)>
{
    public void Show()
    {
        Console.WriteLine("\nDeposit Funds: \nPlease enter account id: ");
        var id = Console.ReadLine();
        if (!BankController.Instance.TryGetAccount(id))
        {
            Failure();

            return;
        }

        Console.WriteLine("Please enter deposit amount: ");
        var amount = Console.ReadLine();
        if (!(BankController.Instance.TryParseAmount(amount, out var depositAmount) &&
            AccountController.Instance.TryDeposit(depositAmount, out var depositAmountAndBalance)))
        {
            Failure();

            return;
        }
        
        Success(depositAmountAndBalance);
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