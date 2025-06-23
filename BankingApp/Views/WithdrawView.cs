namespace BankingApp.Views;

public static class WithdrawView
{
    internal static void WithdrawBanner()
    {
        Console.Clear();
        Console.WriteLine("Withdraw Menu: \n");
    }

    internal static string? WithdrawAmount()
    {
        Console.WriteLine("Please enter withdraw amount: ");
        return Console.ReadLine();
    }

    internal static void WithdrawFailInvalidInput()
    {
        Console.WriteLine("Unsuccessful. Withdrawal amount must be a valid decimal value.");
    }

    internal static void WithdrawFailInvalidAmount()
    {
        Console.WriteLine("Unsuccessful. Withdrawal amount must be greater than 0 and less than current balance. ");
    }

    internal static void WithdrawSuccess(decimal withdrawAmount)
    {
        Console.WriteLine($"${withdrawAmount} successfully withdrawn.");
    }
}