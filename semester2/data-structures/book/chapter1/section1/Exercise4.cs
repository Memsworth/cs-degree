System.Console.WriteLine("Hello world");

ATM bankA = new ATMbankAmerica();

public interface ATM
{
    public bool VerifyPIN(string pin);
    public string SelectAccount();
    public bool Withdraw(string account, double amount);
    public void Display(string account, double amount, bool success);
    public void Display(string pin, bool success);
    public void ShowBalance(string account);
    public static double Deductions = 2.25;
}


public class ATMbankAmerica : ATM
{
    public string Pin { get; set; }
    public bool VerifyPIN(string pin) => Pin == pin;
    public string SelectAccount() => "Bank of America";
    public bool Withdraw(string account, double amount) => false;
    public void Display(string account, double amount, bool success) => System.Console.WriteLine("Nope");
    public void Display(string pin, bool success) => System.Console.WriteLine("Nope2");
    public void ShowBalance(string account) => System.Console.WriteLine("Nope3");
}

