// See https://aka.ms/new-console-template for more information

using BankingApp.Controllers;
using BankingApp.Models;
using BankingApp.Views;

var allAccounts = new AllAccounts();
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
                      
                      Type your selection:
                      """);
    var userSelection = Console.ReadLine();

    switch (userSelection)
    {
        case "1":
            var createView = new CreateView();
            var createName = createView.GetNameOrId();
            if (!new BankController(allAccounts).TryCreateAccount(createName, out var createdAccount))
            {
                createView.Failure();
            }
            else 
            {
                createView.Success(createdAccount);
            }
            break;
        case "2":
            var depositView = new DepositView();
            var depositId = depositView.GetNameOrId();
            if (!new BankController(allAccounts).TrySetAccount(depositId))
            {
                depositView.Failure();
                break;
            }
            var depositAmount = depositView.GetAmount();
            if (!(TryParseAmount(depositAmount, out var parsedDepositAmount) &&
                  new AccountController(allAccounts.ActiveAccount).TryDeposit(
                      parsedDepositAmount, out var depositAmountAndBalance)))
            {
                depositView.Failure();
            }
            else
            {
                depositView.Success(depositAmountAndBalance);
            }
            break;
        case "3": 
            var withdrawView = new WithdrawView();
            var withdrawId = withdrawView.GetNameOrId();
            if (!new BankController(allAccounts).TrySetAccount(withdrawId))
            {
                withdrawView.Failure();
                break;
            }
            var withdrawAmount = withdrawView.GetAmount();
            if (!(TryParseAmount(withdrawAmount, out var parsedWithdrawAmount) &&
                  new AccountController(allAccounts.ActiveAccount).TryWithdraw(
                      parsedWithdrawAmount, out var withdrawAmountAndBalance)))
            {
                withdrawView.Failure();
            }
            else
            {
                withdrawView.Success(withdrawAmountAndBalance);
            }
            break;
        case "4":
            var checkBalanceView = new CheckBalanceView();
            var balanceId = checkBalanceView.GetNameOrId();
            if (!new BankController(allAccounts).TrySetAccount(balanceId))
            {                
                checkBalanceView.Failure();
            }
            else
            {
                checkBalanceView.Success(new AccountController(allAccounts.ActiveAccount).GetBalance());
            }
            break;
        case "5":
            var transferView = new TransferView();
            var senderId = transferView.GetNameOrId();
            if (!new BankController(allAccounts).TrySetAccount(senderId))
            {
                transferView.Failure();
                break;
            }

            Console.WriteLine("Please enter receiver id: ");
            var receiverId = Console.ReadLine();
            if (!new BankController(allAccounts).TrySetAccount(receiverId))
            {
                transferView.Failure();
                break;
            }
            var transferAmount = transferView.GetAmount();
            if (!(TryParseAmount(transferAmount, out var parsedTransferAmount) &&
                  new AccountController(allAccounts.ActiveAccount, allAccounts.PreviousAccount).TryTransfer(
                      parsedTransferAmount, out var transferAmountAndBalance)))
            {
                transferView.Failure();
            }
            else
            {
                transferView.Success(transferAmountAndBalance);
            }
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

bool TryParseAmount(string? amountToParse, out decimal parsedAmount)
{
    if (decimal.TryParse(amountToParse, out var amount))
    {
        parsedAmount =  amount;
            
        return true;
    }

    parsedAmount = 0;
        
    return false;
}
