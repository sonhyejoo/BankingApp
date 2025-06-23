namespace BankingApp.Views;

public static class DepositView
{
    internal static void DepositBanner()
    {
        Console.Clear();
        Console.WriteLine("Deposit Funds: \n");
    }

    internal static string? DepositAmount()
    {
        Console.WriteLine("Please enter deposit amount: ");
        return Console.ReadLine();
    }

    internal static void DepositFailInvalidInput()
    {
        Console.WriteLine("Unsuccessful. Deposit amount must be a valid decimal value.");
    }

    internal static void DepositFailInvalidAmount()
    {
        Console.WriteLine("Unsuccessful. Deposit amount must be greater than 0.");
    }

    internal static void DepositSuccess(decimal depositAmount)
    {
        Console.WriteLine($"${depositAmount} successfully deposited.");
    }
}