// See https://aka.ms/new-console-template for more information

using BankingApp.Controllers;
using BankingApp.Views;

bool closeApp = false;
while (!closeApp)
{
    View.MainMenu();
    Console.WriteLine("Type your selection: ");
    string? input = Console.ReadLine();

    switch (input)
    {
        case "1":
            Controllers.CreateAccountController();
            break;
        case "2":
            Controllers.DepositController();
            break;
        case "3":
            Controllers.WithdrawController();
            break;
        case "4":
            Controllers.BalanceController();
            break;
        case "5":
            Controllers.TransferController();
            break;
        case "q":
            Console.WriteLine("Shutting down.");
            closeApp = true;
            break;
        default:
            Console.WriteLine("Please enter a valid selection. Press any key to try again.");
            Console.ReadKey();
            break;
    }
}