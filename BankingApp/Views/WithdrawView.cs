using BankingApp.Controllers;
using BankingApp.Interfaces;

namespace BankingApp.Views;

public class WithdrawView: ITransactionView<(decimal, decimal)>
{
    public string? GetNameOrId()
    {
        Console.WriteLine("\nWithdraw Menu: \nPlease enter account id: ");
        return Console.ReadLine();
    }
    
    public string? GetAmount()
    {
        Console.WriteLine("Please enter withdrawal amount: ");
        return Console.ReadLine();
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
