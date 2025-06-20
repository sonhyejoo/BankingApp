using System;
using System.Globalization;

namespace BankingApp;

public class Account
{
    public string AccountNumber { get; }
    public string Name { get; }
    public decimal Balance { get; protected set; }

    public Account(string name, decimal balance)
    {
        Name = name;
        Balance = balance;
        AccountNumber = Guid.NewGuid().ToString();
    }   

    public void Deposit(decimal depositAmount)
    {
        Balance += depositAmount;
        return;
    }
    
    public void Withdraw(decimal withdrawAmount)
    {
        Balance -= withdrawAmount;
        return;
    }

}
