namespace BankingApp.Models;

public class Account
{
    public string AccountNumber { get; }
    public string Name { get; }
    public decimal Balance { get; private set; }

    public Account(string name, decimal balance = 0)
    {
        Name = name;
        Balance = balance;
        AccountNumber = Guid.NewGuid().ToString();
    }   

    public void Deposit(decimal depositAmount)
    {
        Balance += depositAmount;
    }
    
    public void Withdraw(decimal withdrawAmount)
    {
        Balance -= withdrawAmount;
    }
}
