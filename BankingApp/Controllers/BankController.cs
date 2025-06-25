using BankingApp.Models;
using BankingApp.Utils;

namespace BankingApp.Controllers;

public class BankController: Singleton<BankController>
{
    private readonly List<Account> _accounts = new();
    
    public bool TryCreateAccount(string? name, out (Guid, string, decimal) account)
    {
        if (string.IsNullOrWhiteSpace(name) || string.IsNullOrEmpty(name))
        {
            account = (Account.Empty.Id, Account.Empty.Name, Account.Empty.Balance);

            return false;
        }

        var acct = new Account(name);
        _accounts.Add(acct);
        account = (acct.Id, acct.Name, acct.Balance);
        // account = acct;

        return true;
    }

    public bool TryParseId(string? userInput, out Guid? id)
    {
        if (Guid.TryParse(userInput, out var guid))
        {
            id = guid;

            return true;
        }

        id = null;

        return false;
    }

    public bool TryGetAccount(string? userInput)
    {
        if (TryParseId(userInput, out var id))
        {
            var foundAccount = _accounts.FirstOrDefault(a => a.Id == id);
            if (foundAccount is not null)
            {
                AccountController.Instance.Account = foundAccount;

                return true;
            }
        }

        return false;
    }
    
    public bool TryParseAmount(string? userInput, out decimal amount)
    {
        if (decimal.TryParse(userInput, out var parsedAmount))
        {
            amount = parsedAmount;
            
            return true;
        }

        amount = 0;
        return false;
    }
}