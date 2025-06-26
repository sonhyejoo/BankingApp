using BankingApp.Models;

namespace BankingApp.Controllers;

public class AccountController(Account account, Account? receiverAccount = null)// : Singleton<AccountController>
{
    public decimal GetBalance() => account.Balance;

    public bool TryDeposit(decimal amount, out (decimal depositAmount, decimal balance) amountAndBalance)
    {
        if (amount > 0)
        {
            account.Balance += amount;
            amountAndBalance = (amount, account.Balance);
            
            return true;
        }

        amountAndBalance = default;
        
        return false;
    }

    public bool TryWithdraw(decimal amount, out (decimal depositAmount, decimal balance) amountAndBalance)
    {
        if (amount > 0 && amount <= account.Balance)
        {
            account.Balance -= amount;
            amountAndBalance = (amount, account.Balance);
            
            return true;
        }

        amountAndBalance = default;
        
        return false;
    }

    public bool TryTransfer(decimal amount,
        out (decimal transferAmount, decimal senderBalance, decimal receiverBalance) amountAndBalances)
    {
        
        if (receiverAccount is null ||
            account.Id == receiverAccount.Id ||
            !(amount > 0 && amount <= receiverAccount.Balance))
        {
            amountAndBalances = default;
        
            return false;
        }
        
        receiverAccount.Balance -= amount;
        account.Balance += amount;

        amountAndBalances = (amount, receiverAccount.Balance, account.Balance);
        
        return true;
    }
}