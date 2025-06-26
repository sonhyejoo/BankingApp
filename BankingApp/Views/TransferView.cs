using BankingApp.Controllers;
using BankingApp.Interfaces;

namespace BankingApp.Views;

public class TransferView: IView<(decimal, decimal, decimal)>
{
    public void Show()
    {
        Console.WriteLine("""
                          Transfer Funds Menu:
                          Sender's account information: 
                          Please enter sender id:
                          """);
        var userInput = Console.ReadLine();
        if (!BankController.Instance.TryGetAccount(userInput))
        {
            Failure();

            return;
        }

        Console.WriteLine("Please enter receiver id: ");
        userInput = Console.ReadLine();
        if (!BankController.Instance.TryGetAccount(userInput))
        {
            Failure();

            return;
        }

        Console.WriteLine("Please enter transfer amount: ");
        userInput = Console.ReadLine();
        if (!(BankController.Instance.TryParseAmount(userInput, out var amount) && 
                AccountController.Instance.TryTransfer(amount, out var amountAndBalances)))
        {
            Failure();

            return;
        }
        
        Success(amountAndBalances);
    }
    
    public void Success((decimal, decimal, decimal) amountAndBalances)
    {
        var (amount, 
            senderBalance, 
            receiverBalance) = amountAndBalances;
        Console.WriteLine($"""
                           {amount:C} successfully transferred.
                           Current sender balance: {senderBalance:C}
                           Current receiver balance: {receiverBalance:C} 
                           """);
    }

    public void Failure()
    {
        Console.WriteLine("Transfer unsuccessful.");
    }
}