using BankingApp.Models;

namespace BankingApp.Views;

public class MainMenuView
{
    public void Show()
    {
        Console.WriteLine("""
                          
                          Select an option: 
                          1. Create account
                          2. Deposit
                          3. Withdraw
                          4. Check balance
                          5. Transfer funds
                          Press q to quit
                          """);
    }


    public void Return()
    {
        Console.WriteLine("Press any button to return to main menu...");
        Console.ReadKey();
    }
    
}