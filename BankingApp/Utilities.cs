using System;
using System.ComponentModel;

namespace BankingApp;

public class Utilities
{
    private static List<Account> s_accounts = new();
    public static void ShowMainMenu()
    {
        Console.Clear();
        Console.WriteLine("Select an option: ");
        Console.WriteLine("1. Create account");
        Console.WriteLine("2. Deposit");
        Console.WriteLine("3. Withdraw");
        Console.WriteLine("4. Check balance");
        Console.WriteLine("5. Transfer funds");
        Console.WriteLine("Press q to quit");

        Console.WriteLine("Type your selection: ");
        string? input = Console.ReadLine();

        switch (input)
        {
            case "1":
                ShowAccountCreationMenu();
                break;
            case "2":
                ShowDepositMenu();
                break;
            case "3":
                ShowWithdrawMenu();
                break;
            case "4":
                ShowBalanceMenu();
                break;
            case "5":
                ShowTransferMenu();
                break;
            case "q":
                Console.WriteLine("Shutting down.");
                break;
            default:
                Console.WriteLine("Please enter a valid selection. Please try again.");
                break;
        }
    }




    private static void ShowAccountCreationMenu()
    {
        Console.WriteLine("Account creation: \n");
        Console.WriteLine("Please enter your name: ");
        string? userName = Console.ReadLine();
        Console.WriteLine("Please enter initial deposit amount: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal userBalance))
        {
            Console.WriteLine("Invalid initial deposit amount. Please enter a valid decimal for initial deposit.");

        }

        Account newAccount = new(userName, userInitialBalance);

    }

    private static void ShowDepositMenu()
    {
        Console.WriteLine("Deposit Funds: ");
        Console.WriteLine("Please enter account id: ");
        string? userId = Console.ReadLine();
        
    }

    private static void ShowWithdrawMenu()
    {
        throw new NotImplementedException();
    }

    private static void ShowBalanceMenu()
    {
        throw new NotImplementedException();
    }

    private static void ShowTransferMenu()
    {
        throw new NotImplementedException();
    }
}
