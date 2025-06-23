namespace BankingApp.Views;

public static class TransferView
{
    internal static void TransferBanner()
    {
        Console.Clear();
        Console.WriteLine("Transfer Funds Menu: \n");
        Console.WriteLine("Sender's account information: ");
    }

    internal static void TransferReceiveAccountPrompt()
    {
        Console.WriteLine("Receiving account information: ");
    }

    internal static string? TransferAmount()
    {
        Console.WriteLine("Please enter transfer amount: ");
        return Console.ReadLine();
    }

    internal static void TransferFailInvalidInput()
    {
        Console.WriteLine("Unsuccessful. Transfer amount must be a valid decimal value.");
    }

    internal static void TransferFailInvalidAmount()
    {
        Console.WriteLine("Unsuccessful. Transfer amount must be greater than 0 and less than current balance of sender's account. ");
    }

    internal static void TransferSuccess(decimal transferAmount, decimal senderBalance, decimal receiveBalance)
    {
        Console.WriteLine($"\n${transferAmount} successfully transferred.");
        Console.WriteLine("Updated sender and receiving accounts shown below, respectively.");
        Console.WriteLine("Current balance of sender is: $" +  senderBalance);
        Console.WriteLine("Current balance of recipient is: $" +  receiveBalance);

    }
}