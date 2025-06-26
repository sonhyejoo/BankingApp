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

        return true;
    }

    public bool TryParseId(string? idToParse, out Guid? parsedId)
    {
        if (Guid.TryParse(idToParse, out var guid))
        {
            parsedId = guid;

            return true;
        }

        parsedId = null;

        return false;
    }

    public bool TryGetAccount(string? idToParse)
    {
        if (!TryParseId(idToParse, out var parsedId))
        {
            return false;
        }

        var foundAccount = _accounts.FirstOrDefault(a => a.Id == parsedId);
        if (foundAccount is null)
        {
            return false;
        }

        AccountController.Instance.Account = foundAccount;

        return true;
    }
    
    public bool TryParseAmount(string? amountToParse, out decimal parsedAmount)
    {
        if (decimal.TryParse(amountToParse, out var amount))
        {
            parsedAmount =  amount;
            
            return true;
        }

        parsedAmount = 0;
        
        return false;
    }
}