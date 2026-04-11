System.Console.WriteLine("Hello world");

//when you want to use bank of america
ATM bankA = new ATMbankAmerica();
ATM bankB = new ATMforAllBanks();

public interface ATM
{
    //Verifies pin
    public bool VerifyPIN(string pin);
    
    //Select an account and send data back
    public string SelectAccount();
    
    //Did the withdraw occur?
    public bool Withdraw(string account, double amount);
    
    //Result of an operation
    public void Display(string account, double amount, bool success);
    
    //Result of a PIN verification
    public void Display(string pin, bool success);
    
    //Show Balance
    public void ShowBalance(string account);

    //You can even do const (acts like a const)
    public static double Deductions = 2.25;
}


public class ATMbankAmerica : ATM
{
    //Each method has it's own implementation

    public bool VerifyPIN(string pin) => false;

    public string SelectAccount() => "Bank of America";
    
    public bool Withdraw(string account, double amount) => false;
    
    public void Display(string account, double amount, bool success) => System.Console.WriteLine("Nope");
    
    public void Display(string pin, bool success) => System.Console.WriteLine("Nope2");
    
    public void ShowBalance(string account) => System.Console.WriteLine("Nope3");
}


public class ATMforAllBanks : ATM
{
    //Each method has it's own implementation

    public bool VerifyPIN(string pin) => true;

    public string SelectAccount() => "All Banks";
    
    public bool Withdraw(string account, double amount) => true;
    
    public void Display(string account, double amount, bool success) => System.Console.WriteLine("Yes");
    
    public void Display(string pin, bool success) => System.Console.WriteLine("Yes2");
    
    public void ShowBalance(string account) => System.Console.WriteLine("Yes3");
}