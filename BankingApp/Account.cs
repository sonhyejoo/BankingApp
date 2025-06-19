using System;
using System.Globalization;

namespace BankingApp;

public class Account
{
    private static int s_numberSeed = 1234567890;
    public string AccountNumber { get; set; }
    public string Name { get; set; }
    public decimal Balance { get; protected set; }

    public Account(string name, decimal balance)
    {
        Name = name;
        Balance = balance;
        AccountNumber = s_numberSeed.ToString();
        s_numberSeed++;
    }

    public void Deposit(decimal depositAmount)
    {
        Balance += depositAmount;
        return;
    }

    public void Withdraw(decimal withdrawAmount)
    {
        Balance += withdrawAmount;
        return;
    }

}
