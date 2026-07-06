#!
#:package Spectre.Console@*

using project;

var bank = new Bank();

namespace project
{
    public abstract class Account
    {
        public Customer Customer { get; set; }

        public decimal Balance { get; set; }

        public string AccountNumber { get; set; }

        public Transaction[] Transactions { get; set; }
        public int TransactionCount { get; set; }

        public Account()
        {
            Transactions = new Transaction[100];
            TransactionCount = 0;
        }

        public override string ToString()
        {
            return " ";
        }

        public abstract void Deposit(decimal amount);
        public abstract void Withdraw(decimal amount);
        public abstract void AddInterest();

        public void ExpandAndCopy()
        {

        }

        public void ExpandAndCopy()
        {
            var newTransactions = new Transaction[Transactions.Length * 2];

            for (var i = 0; i < Accounts.Length; i++)
                newAccounts[i] = Accounts[i];

            Accounts = newAccounts;
        }

    }


    public class SavingsAccount : Account
    {
        public override void AddInterest()
        {
            throw new NotImplementedException();
        }

        public override void Deposit(decimal amount)
        {
            throw new NotImplementedException();
        }

        public override void Withdraw(decimal amount)
        {
            throw new NotImplementedException();
        }
    }

    public class CheckingAccount : Account
    {
        public override void AddInterest()
        {
            var rate = Customer.GetCheckInterest() / 365;
            Balance += (rate * Balance);
        }

        public override void Deposit(decimal amount)
        {
            var transaction = new Transaction(AccountNumber, TransactionType.Deposit, amount, DateTime.UtcNow, "");

            if (TransactionCount >= Transactions.Length)
                System.Console.WriteLine();

            if (TransactionCount < Transactions.Length)
                TransactionCount++;

            Transactions[TransactionCount - 1] = transaction;

            Balance += amount;
        }

        public override void Withdraw(decimal amount)
        {
            var transaction = new Transaction(AccountNumber, TransactionType.Withdraw, amount, DateTime.UtcNow, "");

            if (TransactionCount >= Transactions.Length)
                System.Console.WriteLine();

            if (TransactionCount < Transactions.Length)
                TransactionCount++;

            Transactions[TransactionCount - 1] = transaction;

            Balance -= amount;

            if (Balance <= 0)
            {
                if (TransactionCount >= Transactions.Length)
                    System.Console.WriteLine();

                if (TransactionCount < Transactions.Length)
                    TransactionCount++;

                Transactions[TransactionCount - 1] = transaction;

                Balance -= Customer.GetOverdraftPenalty();
            }
        }


        pr
    }

    public abstract class Customer
    {
        // Properties
        public string Name { get; set; }

        public string Address { get; set; }

        public int Age { get; set; }

        public string TelephoneNumber { get; set; }

        public string CustomerNumber { get; set; }

        // Abstract methods
        public abstract decimal GetSavingsInterest();
        public abstract decimal GetCheckInterest();
        public abstract decimal GetCheckCharge();
        public abstract decimal GetOverdraftPenalty();

        public Customer(string name, string address, int age, string tele, string customerNumber)
        {
            Name = name;
            Address = address;
            Age = age;
            TelephoneNumber = tele;
            CustomerNumber = customerNumber;
        }
    }


    public class Senior : Customer
    {
        private static decimal SavingsInterest { get; set; } = 0.05m;
        private static decimal CheckInterest { get; set; } = 0.02m;
        private static decimal CheckCahrge { get; set; } = 5.00m;
        private static decimal OverdraftPenalty { get; set; } = 20.00m;

        public Senior(string name, string address, int age, string tele, string customerNumber)
            : base(name, address, age, tele, customerNumber)
        {
        }

        public override decimal GetSavingsInterest() => SavingsInterest;

        public override decimal GetCheckInterest() => CheckInterest;

        public override decimal GetCheckCharge() => CheckCahrge;

        public override decimal GetOverdraftPenalty() => OverdraftPenalty;
    }

    public class Adult : Customer
    {
        private static decimal SavingsInterest { get; set; } = 0.04m;
        private static decimal CheckInterest { get; set; } = 0.01m;
        private static decimal CheckCahrge { get; set; } = 8.00m;
        private static decimal OverdraftPenalty { get; set; } = 30.00m;

        public Adult(string name, string address, int age, string tele, string customerNumber)
            : base(name, address, age, tele, customerNumber)
        {
        }

        public override decimal GetSavingsInterest() => SavingsInterest;

        public override decimal GetCheckInterest() => CheckInterest;

        public override decimal GetCheckCharge() => CheckCahrge;

        public override decimal GetOverdraftPenalty() => OverdraftPenalty;
    }



    public class Student : Customer
    {
        private static decimal SavingsInterest { get; set; } = 0.06m;
        private static decimal CheckInterest { get; set; } = 0.03m;
        private static decimal CheckCahrge { get; set; } = 2.00m;
        private static decimal OverdraftPenalty { get; set; } = 10.00m;

        public Student(string name, string address, int age, string tele, string customerNumber)
            : base(name, address, age, tele, customerNumber)
        {
        }

        public override decimal GetSavingsInterest() => SavingsInterest;

        public override decimal GetCheckInterest() => CheckInterest;

        public override decimal GetCheckCharge() => CheckCahrge;

        public override decimal GetOverdraftPenalty() => OverdraftPenalty;
    }



    public class Bank
    {
        public Account[] Accounts { get; private set; }
        private int CurrentCount { get; set; }

        public Bank()
        {
            CurrentCount = 0;
            Accounts = new Account[100];
        }

        public void AddAccount(Account account)
        {
            if (CurrentCount >= Accounts.Length)
                ExpandAndCopy();

            if (CurrentCount < Accounts.Length)
                CurrentCount++;

            Accounts[CurrentCount - 1] = account;
        }

        public void MakeDeposit(string accountNumber, decimal amount)
        {
            // Deposit money into the account
            var account = GetAccount(accountNumber);
            if (account is null)
                return;

            account.Deposit(amount);

        }

        public void MakeWithdrawal(string accountNumber, decimal amount)
        {
            // Withdraw money from the account
            var account = GetAccount(accountNumber);
            if (account is null)
                return;

            var transaction = new Transaction(account.AccountNumber, TransactionType.Withdraw, amount, DateTime.UtcNow, "");

        }

        private Account? GetAccount(string accountNumber) =>
            Accounts.FirstOrDefault(x => x.AccountNumber == accountNumber);

        public void ExpandAndCopy()
        {
            var newAccounts = new Account[Accounts.Length * 2];

            for (var i = 0; i < Accounts.Length; i++)
                newAccounts[i] = Accounts[i];

            Accounts = newAccounts;
        }
    }



    public enum TransactionType
    {
        Withdraw = 0,
        Deposit = 1,
        Overdraft = 2,

    };

    public record Transaction(string CustomerNumber, TransactionType TransactionType, decimal Amount, DateTime Date, string Fees);
}