#!

public class Account
{
    public Customer Customer { get; private set; }
    public decimal Balance { get; private set; }
    public int AccountNumber { get; private set; }
    public Transaction[] Transactions { get; private set; }

    public Account(Customer customer, decimal balance, int accountNumber)
    {
        Customer = customer;
        Balance = balance;
        AccountNumber = accountNumber;
        Transactions = new Transaction[100];
    }

    public override string ToString()
    {
        return " ";
    }
}


public class Customer
{
}

public class Transaction
{
}