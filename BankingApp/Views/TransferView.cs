using BankingApp.Controllers;
using BankingApp.Interfaces;

namespace BankingApp.Views;

public class TransferView: IView<(decimal, decimal, decimal)>
{
    internal static void Success(decimal transferAmount, decimal senderBalance, decimal receiveBalance)
    {
        Console.WriteLine($"\n${transferAmount} successfully transferred.");
        Console.WriteLine("Updated sender and receiving accounts shown below, respectively.");
        Console.WriteLine("Current balance of sender is: $" +  senderBalance);
        Console.WriteLine("Current balance of recipient is: $" +  receiveBalance);

    }

    public void Show()
    {
        Console.WriteLine("\nTransfer Funds Menu: \n");
        Console.WriteLine("Sender's account information: ");
        Console.WriteLine("Please enter sender id: ");
        var userInput = Console.ReadLine();
        if (BankController.Instance.TryGetAccount(userInput))
        {
            Console.WriteLine("Please enter receiver id: ");
            userInput = Console.ReadLine();
            if (BankController.Instance.TryGetAccount(userInput))
            {
                Console.WriteLine("Please enter transfer amount: ");
                userInput = Console.ReadLine();
                if (BankController.Instance.TryParseAmount(userInput, out var amount))
                {
                    if (AccountController.Instance.TryTransfer(amount, out var amountAndBalances))
                    {
                        Success(amountAndBalances);

                        return;
                    }
                }
            }
        }
        
        Failure();

    }
    
    public void Success((decimal, decimal, decimal) amountAndBalances)
    {
        (decimal amount, decimal senderBalance, decimal receiverBalance) = amountAndBalances;
        Console.WriteLine($"{amount:C} successfully transferred.");
        Console.WriteLine($"Current sender balance: {senderBalance:C}");
        Console.WriteLine($"Current receiver balance: {receiverBalance:C}");
    }

    public void Failure()
    {
        Console.WriteLine("Transfer unsuccessful.");
    }
}