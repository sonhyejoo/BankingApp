namespace BankingApp.Models;

public class AllAccounts
{
    private Account _activeAccount = Account.Empty;
    
    public Account ActiveAccount
    {
        get => _activeAccount;
        set
        {
            PreviousAccount = _activeAccount;
            _activeAccount = value;
        }
    }

    public Account PreviousAccount { get; set; } = Account.Empty;

    public List<Account> AccountList = [];
}