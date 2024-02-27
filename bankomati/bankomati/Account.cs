class Account
{
    public int AccountNumber { get; private set; }
    public string Name { get; private set; }
    public double Balance { get; private set; }

    public Account(int accountNumber, string name, double balance)
    {
        AccountNumber = accountNumber;
        Name = name;
        Balance = balance;
    }

    public void Deposit(double amount)
    {
        Balance += amount;
    }

    public bool Withdraw(double amount)
    {
        if (Balance >= amount)
        {
            Balance -= amount;
            return true;
        }
        return false;
    }
}
