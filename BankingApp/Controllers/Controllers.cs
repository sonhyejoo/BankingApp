using BankingApp.Views;
using BankingApp.Models;

namespace BankingApp.Controllers;

public static class Controllers
{
    private static List<Account> _accounts = new();
    
    internal static void CreateAccountController()
    {
        string? userName = CreateView.CreateAccountMenu();
        if (string.IsNullOrEmpty(userName))
        {
            CreateView.CreateAccountInvalidName();
        }
        else
        {
            Account newAccount = new(userName);
            _accounts.Add(newAccount);
            CreateView.CreateAccountSuccess(newAccount);
        }
        View.ReturnToMainMenu();
    }
    
    internal static void DepositController()
    {
        DepositView.DepositBanner();
        Account? foundAccount = FindAccount();
        if (foundAccount is not null)
        {
            if (!decimal.TryParse(DepositView.DepositAmount(), out decimal depositAmount))
            {
                DepositView.DepositFailInvalidInput();
            }
            else if (depositAmount <= 0)
            {
                DepositView.DepositFailInvalidAmount();
            }
            else
            {
                foundAccount.Deposit(depositAmount);
                DepositView.DepositSuccess(depositAmount);
                View.BalanceSuccess(foundAccount);
            }
        }

        View.ReturnToMainMenu();
    }
    internal static void WithdrawController()
    {
        WithdrawView.WithdrawBanner();
        Account? foundAccount = FindAccount();
        if (foundAccount is not null)
        {
            if (!decimal.TryParse(WithdrawView.WithdrawAmount(), out decimal withdrawAmount))
            {
                WithdrawView.WithdrawFailInvalidInput();
            }
            
            else if (withdrawAmount <= 0 || withdrawAmount > foundAccount.Balance)
            {
                WithdrawView.WithdrawFailInvalidAmount();
            }
            else
            {
                foundAccount.Withdraw(withdrawAmount);
                WithdrawView.WithdrawSuccess(withdrawAmount);
                View.BalanceSuccess(foundAccount);
            }
        }
        
        View.ReturnToMainMenu();
    }
    internal static void BalanceController()
    {
        View.BalanceBanner();
        Account? foundAccount = FindAccount();
        if (foundAccount is not null)
        {
            View.BalanceSuccess(foundAccount);
        }
        
        View.ReturnToMainMenu();

    }
    internal static void TransferController()
    {
        TransferView.TransferBanner();
        Account? senderAccount = FindAccount();
        if (senderAccount is not null)
        {
            TransferView.TransferReceiveAccountPrompt();
            Account? receiveAccount = FindAccount();
            if (receiveAccount is not null)
            {
                if (!decimal.TryParse(TransferView.TransferAmount(), out decimal transferAmount))
                {
                    TransferView.TransferFailInvalidInput();
                }
                else if (transferAmount <= 0 && transferAmount > senderAccount.Balance )
                {
                    TransferView.TransferFailInvalidAmount();
                }
                else
                {
                    senderAccount.Withdraw(transferAmount);
                    receiveAccount.Deposit(transferAmount);
                    TransferView.TransferSuccess(transferAmount, senderAccount.Balance,  receiveAccount.Balance);
                }
            }
        }
        
        View.ReturnToMainMenu();
    }
    
    private static Account? FindAccount()
    {
        Account? foundAccount = null;
        string? inputNumber = View.FindAccountNumberPrompt();
        var findingAccount = _accounts.FirstOrDefault(a => a.AccountNumber == inputNumber);
        if (findingAccount is null)
        {
            View.FindAccountNotFound();
        }
        else
        {
            foundAccount = findingAccount;
            View.FindAccountSuccess();
        }
        
        return foundAccount;
    }
}