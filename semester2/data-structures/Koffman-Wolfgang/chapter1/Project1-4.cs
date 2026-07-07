#!
#:package Spectre.Console@*

using project;
using Spectre.Console;

var bank = new Bank();

// Create customers
var senior = new Senior("John Smith", "123 Main St", 68, "555-1111", "C001");
var adult = new Adult("Jane Doe", "456 Oak Ave", 35, "555-2222", "C002");
var student = new Student("Alice Brown", "789 Pine Rd", 20, "555-3333", "C003");

// Create accounts
var savings = new SavingsAccount
{
    Customer = senior,
    AccountNumber = "S1001",
    Balance = 1000m
};

var checking = new CheckingAccount
{
    Customer = adult,
    AccountNumber = "C2001",
    Balance = 500m
};

var studentChecking = new CheckingAccount
{
    Customer = student,
    AccountNumber = "C3001",
    Balance = 100m
};

bank.AddAccount(savings);
bank.AddAccount(checking);
bank.AddAccount(studentChecking);

bool running = true;

while (running)
{
    AnsiConsole.Clear();

    var choice = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
            .Title("[green]Bank Simulation[/]")
            .AddChoices(
                "View Accounts",
                "Deposit",
                "Withdraw",
                "Add Interest",
                "Exit"));

    switch (choice)
    {
        case "View Accounts":
            ShowAccounts(bank);
            break;

        case "Deposit":
            {
                string account = AnsiConsole.Ask<string>("Account Number:");
                decimal amount = AnsiConsole.Ask<decimal>("Deposit Amount:");

                bank.MakeDeposit(account, amount);
                Pause();
                break;
            }

        case "Withdraw":
            {
                string account = AnsiConsole.Ask<string>("Account Number:");
                decimal amount = AnsiConsole.Ask<decimal>("Withdrawal Amount:");

                bank.MakeWithdrawal(account, amount);

                Pause();
                break;
            }

        case "Add Interest":
            {
                foreach (var account in bank.Accounts)
                {
                    if (account == null)
                        continue;

                    account.AddInterest();
                }

                AnsiConsole.MarkupLine("[green]Interest added to all accounts.[/]");
                Pause();
                break;
            }

        case "Exit":
            running = false;
            break;
    }
}

static void ShowAccounts(Bank bank)
{
    var table = new Table();

    table.AddColumn("Account");
    table.AddColumn("Customer");
    table.AddColumn("Type");
    table.AddColumn("Balance");

    foreach (var account in bank.Accounts)
    {
        if (account == null)
            continue;

        table.AddRow(
            account.AccountNumber,
            account.Customer.Name,
            account.GetType().Name,
            account.Balance.ToString("C"));
    }

    AnsiConsole.Write(table);
    Pause();
}

static void Pause()
{
    AnsiConsole.MarkupLine("\n[grey]Press any key to continue...[/]");
    Console.ReadKey(true);
}



#region TheActualClass
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
            return $"Account Type : {GetType().Name}\n" + $"Account No.  : {AccountNumber}\n"
            + $"Customer     : {Customer.Name}\n" + $"Customer No. : {Customer.CustomerNumber}\n"
            + $"Balance      : {Balance:C}";
        }

        public abstract void Deposit(decimal amount);
        public abstract void Withdraw(decimal amount);
        public abstract void AddInterest();

        public void ExpandTransaction()
        {
            var newTransactions = new Transaction[Transactions.Length * 2];

            for (var i = 0; i < Transactions.Length; i++)
                newTransactions[i] = Transactions[i];

            Transactions = newTransactions;
        }

    }


    public class SavingsAccount : Account
    {
        public override void AddInterest()
        {
            var rate = Customer.GetSavingsInterest() / 365;
            Balance += (rate * Balance);
        }

        public override void Deposit(decimal amount)
        {
            if (amount < decimal.Zero)
            {
                //do spectre console here
                AnsiConsole.Write(new Panel("[red]Deposit amount must be greater than zero.[/]").Header("Transaction Failed").Border(BoxBorder.Rounded));

                return;
            }

            var transaction = new Transaction(AccountNumber, TransactionType.Deposit, amount, DateTime.UtcNow, "");

            if (TransactionCount == Transactions.Length)
                ExpandTransaction();

            Transactions[TransactionCount++] = transaction;
            Balance += amount;
            AnsiConsole.MarkupLine("[green]Deposit complete.[/]");

        }

        public override void Withdraw(decimal amount)
        {
            if (amount < decimal.Zero)
            {
                //do spectre console here
                AnsiConsole.Write(new Panel("[red]Withdrawal amount must be greater than zero.[/]").Header("Transaction Failed").Border(BoxBorder.Rounded));

                return;
            }
            if (amount > Balance)
            {
                //spectre console here aswell
                AnsiConsole.Write(new Panel($"[red]Insufficient funds. Current balance: {Balance:C}[/]").Header("Transaction Failed").Border(BoxBorder.Rounded));

                return;

            }


            var transaction = new Transaction(AccountNumber, TransactionType.Withdraw, amount, DateTime.UtcNow, "");
            if (TransactionCount == Transactions.Length)
                ExpandTransaction();


            Transactions[TransactionCount++] = transaction;
            Balance -= amount;
            AnsiConsole.MarkupLine("[green]Withdrawal processed.[/]");

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
            if (amount < decimal.Zero)
            {
                //spectre console here
                AnsiConsole.Write(new Panel("[red]Deposit amount must be greater than zero.[/]").Header("Transaction Failed").Border(BoxBorder.Rounded));
                return;
            }
            var transaction = new Transaction(AccountNumber, TransactionType.Deposit, amount, DateTime.UtcNow, "");

            if (TransactionCount == Transactions.Length)
                ExpandTransaction();

            Transactions[TransactionCount++] = transaction;
            Balance += amount;
            AnsiConsole.MarkupLine("[green]Deposit complete.[/]");

        }

        public override void Withdraw(decimal amount)
        {
            if (amount < decimal.Zero)
            {
                //spectre console here
                AnsiConsole.Write(new Panel("[red]Withdrawal amount must be greater than zero.[/]").Header("Transaction Failed").Border(BoxBorder.Rounded));
                return;
            }
            var transaction = new Transaction(AccountNumber, TransactionType.Withdraw, amount, DateTime.UtcNow, "");

            if (TransactionCount == Transactions.Length)
                ExpandTransaction();


            Transactions[TransactionCount++] = transaction;
            Balance -= amount;

            if (Balance < decimal.Zero)
            {
                if (TransactionCount == Transactions.Length)
                    ExpandTransaction();


                var overdraftAmount = Customer.GetOverdraftPenalty();
                var overdraftTransaction =
                    new Transaction(AccountNumber, TransactionType.Overdraft, overdraftAmount, DateTime.UtcNow, "overdraft charge");

                Transactions[TransactionCount++] = overdraftTransaction;
                Balance -= overdraftAmount;

                AnsiConsole.Write(new Panel($"[yellow]Overdraft fee applied: {overdraftAmount:C}[/]").Header("Warning").Border(BoxBorder.Double));
            }

            AnsiConsole.MarkupLine("[green]Withdrawal processed.[/]");
        }
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
        private static decimal CheckCharge { get; set; } = 5.00m;
        private static decimal OverdraftPenalty { get; set; } = 20.00m;

        public Senior(string name, string address, int age, string tele, string customerNumber)
            : base(name, address, age, tele, customerNumber)
        {
        }

        public override decimal GetSavingsInterest() => SavingsInterest;

        public override decimal GetCheckInterest() => CheckInterest;

        public override decimal GetCheckCharge() => CheckCharge;

        public override decimal GetOverdraftPenalty() => OverdraftPenalty;
    }

    public class Adult : Customer
    {
        private static decimal SavingsInterest { get; set; } = 0.04m;
        private static decimal CheckInterest { get; set; } = 0.01m;
        private static decimal CheckCharge { get; set; } = 8.00m;
        private static decimal OverdraftPenalty { get; set; } = 30.00m;

        public Adult(string name, string address, int age, string tele, string customerNumber)
            : base(name, address, age, tele, customerNumber)
        {
        }

        public override decimal GetSavingsInterest() => SavingsInterest;

        public override decimal GetCheckInterest() => CheckInterest;

        public override decimal GetCheckCharge() => CheckCharge;

        public override decimal GetOverdraftPenalty() => OverdraftPenalty;
    }



    public class Student : Customer
    {
        private static decimal SavingsInterest { get; set; } = 0.06m;
        private static decimal CheckInterest { get; set; } = 0.03m;
        private static decimal CheckCharge { get; set; } = 2.00m;
        private static decimal OverdraftPenalty { get; set; } = 10.00m;

        public Student(string name, string address, int age, string tele, string customerNumber)
            : base(name, address, age, tele, customerNumber)
        {
        }

        public override decimal GetSavingsInterest() => SavingsInterest;

        public override decimal GetCheckInterest() => CheckInterest;

        public override decimal GetCheckCharge() => CheckCharge;

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
            if (CurrentCount == Accounts.Length)
                ExpandAndCopy();


            Accounts[CurrentCount++] = account;
        }

        public void MakeDeposit(string accountNumber, decimal amount)
        {
            // Deposit money into the account
            var account = GetAccount(accountNumber);
            if (account is null)
            {
                AnsiConsole.Write(new Panel("[red]Account doesn't exist.[/]").Header("Transaction Failed").Border(BoxBorder.Rounded));
                return;
            }

            account.Deposit(amount);

        }

        public void MakeWithdrawal(string accountNumber, decimal amount)
        {
            // Withdraw money from the account
            var account = GetAccount(accountNumber);
            if (account is null)
            {
                AnsiConsole.Write(new Panel("[red]Account doesn't exist.[/]").Header("Transaction Failed").Border(BoxBorder.Rounded));
                return;
            }

            account.Withdraw(amount);
        }

        /*public Account? GetAccount(string accountNumber) =>
            Accounts.FirstOrDefault(x => x.AccountNumber == accountNumber);*/

        public Account? GetAccount(string accountNumber)
        {
            int i = 0;
            for (i = 0; i < CurrentCount; i++)
            {
                if (Accounts[i].AccountNumber == accountNumber)
                    return Accounts[i];
            }

            return null;
        }

        public IEnumerable<Account> ActiveAccounts => Accounts.Where(a => a != null);

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
#endregion