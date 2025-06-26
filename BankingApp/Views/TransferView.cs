using BankingApp.Controllers;
using BankingApp.Interfaces;

namespace BankingApp.Views;

public class TransferView: IAmountable, IIdentifiable, IFailable<(decimal, decimal, decimal)>
{
    public string? GetId()
    {
        Console.WriteLine("\nTransfer Funds Menu: \nSender's account information: \nPlease enter sender id:");
        return Console.ReadLine();
    }
    
    public string? GetAmount()
    {
        Console.WriteLine("Please enter transfer amount: ");
        return Console.ReadLine();
    }
    
    public void Success((decimal, decimal, decimal) amountAndBalances)
    {
        var (transferAmount, 
            senderBalance, 
            receiverBalance) = amountAndBalances;
        Console.WriteLine($"""
                           {transferAmount:C} successfully transferred.
                           Current sender balance: {senderBalance:C}
                           Current receiver balance: {receiverBalance:C} 
                           """);
    }

    public void Failure() => Console.WriteLine("Transfer unsuccessful.");
}