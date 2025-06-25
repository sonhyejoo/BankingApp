using BankingApp.Models;

namespace BankingApp.Views;

public class MainMenuView
{
    public void Show()
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


    public void Return()
    {
        Console.WriteLine("Press any button to return to main menu...");
        Console.ReadKey();
    }
    
}