// See https://aka.ms/new-console-template for more information

using BankingApp.Controllers;
using BankingApp.Views;

var mainMenuView = new MainMenuView();
while (true)
{
    mainMenuView.Show();
    Console.WriteLine("Type your selection: ");
    var input = Console.ReadLine();

    switch (input)
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

    mainMenuView.Return();
}