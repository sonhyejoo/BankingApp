using BankingApp.Models;
using BankingApp.Utils;

namespace BankingApp.Controllers;

public class AccountController() : Singleton<AccountController>
{
    private Account _account = Account.Empty;
    
    public Account Account 
    {
        get => _account;
        set
        {
            PreviousAccount = _account;
            _account = value;
        }
    }

    private Account PreviousAccount { get; set; } = Account.Empty;

    public decimal GetBalance() => Account.Balance;

    public bool TryDeposit(decimal amount, out (decimal depositAmount, decimal balance) amountAndBalance)
    {
        if (amount > 0)
        {
            Account.Balance += amount;
            amountAndBalance = (amount, Account.Balance);
            
            return true;
        }

        amountAndBalance = default;
        return false;
    }

    public bool TryWithdraw(decimal amount, out (decimal depositAmount, decimal balance) amountAndBalance)
    {
        if (amount > 0 && amount <= Account.Balance)
        {
            Account.Balance -= amount;
            amountAndBalance = (amount, Account.Balance);
            
            return true;
        }

        amountAndBalance = default;
        return false;
    }

    public bool TryTransfer(decimal amount,
        out (decimal transferAmount, decimal senderBalance, decimal receiverBalance) amountAndBalances)
    {
        if (amount > 0 && amount <= PreviousAccount.Balance)
        {
            PreviousAccount.Balance -= amount;
            Account.Balance += amount;

            amountAndBalances = (amount, PreviousAccount.Balance, Account.Balance);
            return true;
        }

        amountAndBalances = default;
        return false;
    }
}