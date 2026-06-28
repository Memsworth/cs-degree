
public class C2
{
    public class CreditCard
    {
        public string Customer { get; private set; }
        public string BankName { get; private set; }
        public string Account { get; private set; }
        public int Limit { get; private set; }
        public double Balance { get; private set; }

        public CreditCard(string customer, string bankName, string account, int limit, double initialBalance)
        {
            Customer = customer;
            BankName = bankName;
            Account = account;
            Limit = limit;
            Balance = initialBalance;
        }

        public CreditCard(string customer, string bankName, string account, int limit) : this(customer, bankName, account, limit, 0.0)
        { }


        public bool Charge(double price)
        {
            if (price + Balance > Limit)
            {
                return false;
            }

            else
            {
                Balance += price;
                return true;
            }
        }

        public void MakePayment(double amount) => Balance -= amount;

        public void PrintSummery()
        {
            System.Console.WriteLine("Customer = " + Customer);
            System.Console.WriteLine("Bank = " + BankName);
            System.Console.WriteLine("Account = " + Account);
            System.Console.WriteLine("Balance = " + Balance);
            System.Console.WriteLine("Limit = " + Limit);
        }

        public override string ToString()
        {
            return $"Customer = {Customer}\n" +
                   $"Bank = {BankName}\n" +
                   $"Account = {Account}\n" +
                   $"Balance = {Balance}\n" +
                   $"Limit = {Limit}";
        }
    }

    public void Run()
    {
        var wallet = new CreditCard[3];

        wallet[0] = new CreditCard("John Bowman", "California Savings",
            "5391 0375 9387 5309", 5000);
        wallet[1] = new CreditCard("John Bowman", "California Federal",
            "3485 0399 3395 1954", 3500);
        wallet[2] = new CreditCard("John Bowman", "California Finance",
            "5391 0375 9387 5309", 2500, 300);

        for (int val = 1; val <= 16; val++)
        {
            wallet[0].Charge(val * 3);
            wallet[1].Charge(val * 2);
            wallet[2].Charge(val);
        }

        foreach (var card in wallet)
        {
            System.Console.WriteLine(card);
            while (card.Balance > 200.0)
            {
                card.MakePayment(200.0);
                System.Console.WriteLine("New balance = " + card.Balance);
            }
        }
    }
}