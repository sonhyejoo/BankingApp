using BankingApp.Models;

namespace BankingApp.Views;

public static class View
{
    public static void MainMenu()
    {
        Console.Clear();
        Console.WriteLine("Select an option: ");
        Console.WriteLine("1. Create account");
        Console.WriteLine("2. Deposit");
        Console.WriteLine("3. Withdraw");
        Console.WriteLine("4. Check balance");
        Console.WriteLine("5. Transfer funds");
        Console.WriteLine("Press q to quit");
    }

    internal static void BalanceBanner()
    {
        Console.Clear();
        Console.WriteLine("Balance Menu: \n");
    }

    internal static void BalanceSuccess(Account account)
    {
        Console.WriteLine("Current balance is: $" +  account.Balance);
    }

    internal static void ReturnToMainMenu()
    {
        Console.WriteLine("Press any button to return to main menu...");
        Console.ReadKey();
    }
    
    internal static string? FindAccountNumberPrompt()
    {
        Console.WriteLine("Please enter account number: ");
        return Console.ReadLine();
    }

    internal static void FindAccountNotFound()
    {
        Console.WriteLine("No account found with that account number.");
    }

    internal static void FindAccountSuccess()
    {
        Console.WriteLine("Account found.");
    }
}