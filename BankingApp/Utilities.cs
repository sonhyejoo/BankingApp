
namespace BankingApp;

public class Utilities
{
    private static List<Account> _accounts = new();
    public static void ShowMainMenu()
    {
        // Console.ResetColor();
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
                ShowMainMenu();
                break;
        }
    }
    
    private static void ShowAccountCreationMenu()
    {
        Console.Clear();
        Console.WriteLine("Account creation: \n");
        bool emptyName = true;
        string? userName = null;
        while (emptyName)
        {
            Console.WriteLine("Please enter account holder's name: ");
            userName = Console.ReadLine();
            if (string.IsNullOrEmpty(userName))
            {
                Console.WriteLine("Name cannot be empty.");
            }
            else
            {
                emptyName = false;
            }
        }

        bool validBalance = false;
        decimal userBalance = 0;
        while (!validBalance)
        {
            Console.WriteLine("Please enter initial deposit amount: ");
            if (!decimal.TryParse(Console.ReadLine(), out userBalance))
            {
                Console.WriteLine("Initial deposit must be a valid decimal value.");
                continue;
            }

            if (userBalance <= 0)
            {
                Console.WriteLine("Initial deposit amount must be greater than zero.");
            }
            else
            {
                validBalance = true;
            }
        }

        Account newAccount = new(userName, userBalance);
        _accounts.Add(newAccount);
        Console.WriteLine("New bank account created with the following details: ");
        Console.WriteLine($"Name of account holder: {newAccount.Name}");
        Console.WriteLine($"Account's initial balance: ${newAccount.Balance}");
        Console.WriteLine($"Account number used for access: {newAccount.AccountNumber}");
        Console.WriteLine("Press any button to return to main menu...");

        Console.ReadKey();
        ShowMainMenu();
    }

    private static void ShowDepositMenu()
    {
        Console.WriteLine("Deposit Funds: \n");
        Account? foundAccount = FindAccountMenuPrompt();

        bool validDeposit = false;
        while (!validDeposit)
        {
            Console.WriteLine("Please enter deposit amount: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal depositAmount))
            {
                Console.WriteLine("Deposit amount must be a valid decimal value.");
                continue;
            }

            if (depositAmount <= 0)
            {
                Console.WriteLine("Deposit amount must be greater than zero.");
            }
            else
            {
                foundAccount.Deposit(depositAmount);
                Console.WriteLine($"Deposit successful. New balance is: ${foundAccount.Balance}");
                validDeposit = true;
            }
        }
        Console.WriteLine("Press any key to return to main menu");
        Console.ReadKey();
        ShowMainMenu();
    }


    private static void ShowWithdrawMenu()
    {
        Console.WriteLine("Withdraw Menu: \n");
        Account? foundAccount = FindAccountMenuPrompt();
        
        bool validWithdraw = false;
        while (!validWithdraw)
        {
            Console.WriteLine("Please enter withdraw amount: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal withdrawAmount))
            {
                Console.WriteLine("Withdrawal amount must be a valid decimal value.");
                continue;
            }

            if (withdrawAmount <= 0)
            {
                Console.WriteLine("Withdrawal amount must be greater than zero.");
            }
            else if (withdrawAmount > foundAccount.Balance)
            {
                Console.WriteLine($"Withdraw amount cannot exceed your current balance of ${foundAccount.Balance}.");
            }
            else
            {
                foundAccount.Withdraw(withdrawAmount);
                Console.WriteLine(
                    $"${withdrawAmount} successfully withdrawn. New balance is: ${foundAccount.Balance}");
                validWithdraw = true;
            }
        }
        Console.WriteLine("Press any key to return to main menu");
        Console.ReadKey();
        ShowMainMenu();
    }

    private static void ShowBalanceMenu()
    {
        Console.WriteLine("Balance Menu: \n");
        Account? foundAccount = FindAccountMenuPrompt();
        Console.WriteLine($"Current account balance is: {foundAccount.Balance} \n");
        
        Console.WriteLine("Press any key to return to main menu");
        Console.ReadKey();
        ShowMainMenu();
    }

    private static void ShowTransferMenu()
    {
        Console.WriteLine("Transfer Funds Menu: \n");
        Account? sendingAccount = FindAccountMenuPrompt();

        Account? receiveAccount = FindAccountMenuPrompt();
        bool validTransfer = false;
        while (!validTransfer)
        {
            Console.WriteLine("Please enter transfer amount: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal transferAmount))
            {
                Console.WriteLine("Transfer amount must be a valid decimal value.");
                continue;
            }

            if (transferAmount <= 0)
            {
                Console.WriteLine("Transfer amount must be greater than zero.");
            }
            else if (transferAmount > sendingAccount.Balance)
            {
                Console.WriteLine($"Transfer amount cannot exceed sender's balance of ${sendingAccount.Balance}.");
            }
            else
            {
                sendingAccount.Withdraw(transferAmount);
                receiveAccount.Deposit(transferAmount);
                Console.WriteLine(
                    $"\n ${transferAmount} successfully transferred.");
                Console.WriteLine($"Sender's new balance is: ${sendingAccount.Balance}");
                Console.WriteLine($"Recipients's balance is: ${receiveAccount.Balance} \n");
                validTransfer = true;
            }
        }

        Console.WriteLine("Press any key to return to main menu");
        Console.ReadKey();
        ShowMainMenu();
    }
    private static Account? FindAccountWithNumberOrNull(string? accountNumber)
    {
        var foundAccount = _accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
        return foundAccount;
    }
    private static Account? FindAccountMenuPrompt()
    {
        Account? foundAccount = null;
        bool accountWasFound = false;
        while (!accountWasFound)
        {
            Console.WriteLine("Please enter account number: ");

            string? inputNumber = Console.ReadLine();
            var findingAccount = FindAccountWithNumberOrNull(inputNumber);
            if (findingAccount is null)
            {
                Console.WriteLine("No account found with that account number.");
            }
            else
            {
                Console.WriteLine("Account found.");
                foundAccount = findingAccount;
                accountWasFound = true;
            }
        }

        return foundAccount;
    }

}