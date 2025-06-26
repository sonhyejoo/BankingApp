// See https://aka.ms/new-console-template for more information

using BankingApp.Controllers;
using BankingApp.Views;

while (true)
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
    Console.WriteLine("Type your selection: ");
    var userSelection = Console.ReadLine();

    switch (userSelection)
    {
        case "1":
            var createView = new CreateView();
            createView.Show();
            break;
        case "2":
            var depositView = new DepositView();
            depositView.Show();
            break;
        case "3":
            var withdrawView = new WithdrawView();
            withdrawView.Show();
            break;
        case "4":
            var checkBalanceView = new CheckBalanceView();
            checkBalanceView.Show();
            break;
        case "5":
            var transferView = new TransferView();
            transferView.Show();
            break;
        case "q":
            Console.WriteLine("Shutting down.");
            return;
        default:
            Console.WriteLine("Please enter a valid selection.");
            break;
    }

    Console.WriteLine("Press any button to return to main menu...");
    Console.ReadKey();
}