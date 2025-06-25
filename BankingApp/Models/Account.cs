namespace BankingApp.Models;

public class Account(string name, decimal balance = 0)
{
    public Guid Id { get; } = Guid.NewGuid();
    public string Name { get; } = name;
    public decimal Balance { get; set; } = balance;

    public static readonly Account Empty = new Account("", Decimal.MinValue);

    public void Deconstruct(out Guid id, out string name, out decimal balance)
    {
        id = Id;
        name = Name;
        balance = Balance;
    }
}
