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
        var senderId = Console.ReadLine();
        if (!BankController.Instance.TryGetAccount(senderId))
        {
            Failure();

            return;
        }

        Console.WriteLine("Please enter receiver id: ");
        var receiverId = Console.ReadLine();
        if (!BankController.Instance.TryGetAccount(receiverId))
        {
            Failure();

            return;
        }

        Console.WriteLine("Please enter transfer amount: ");
        var amount = Console.ReadLine();
        if (!(BankController.Instance.TryParseAmount(amount, out var transferAmount) && 
                AccountController.Instance.TryTransfer(transferAmount, out var transferAmountAndBalances)))
        {
            Failure();

            return;
        }
        
        Success(transferAmountAndBalances);
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

    public void Failure()
    {
        Console.WriteLine("Transfer unsuccessful.");
    }
}