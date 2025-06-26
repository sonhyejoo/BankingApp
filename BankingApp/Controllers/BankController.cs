using BankingApp.Models;

namespace BankingApp.Controllers;

public class BankController(AllAccounts accounts)//: Singleton<BankController>
{
    private AllAccounts _accounts = accounts;

    public bool TryCreateAccount(string? name, out (Guid, string, decimal) account)
    {
        if (string.IsNullOrWhiteSpace(name) || string.IsNullOrEmpty(name))
        {
            account = (Account.Empty.Id, Account.Empty.Name, Account.Empty.Balance);

            return false;
        }

        var acct = new Account(name);
        _accounts.AccountList.Add(acct);
        account = (acct.Id, acct.Name, acct.Balance);

        return true;
    }
    
    public bool TrySetAccount(string? idToParse)
    {
        if (!Guid.TryParse(idToParse, out var parsedId))
        {
            return false;
        }

        var foundAccount = _accounts.AccountList.FirstOrDefault(a => a.Id == parsedId);
        if (foundAccount is null)
        {
            return false;
        }

        _accounts.ActiveAccount = foundAccount;

        return true;
    }
}