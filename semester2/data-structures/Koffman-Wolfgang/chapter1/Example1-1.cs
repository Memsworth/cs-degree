#!
using Example1;

namespace Example1
{
    public interface IAtm
    {
        bool VerifyPin(string pin);
        string SelectAccount();
        bool Withdraw(string account, double amount);

        void Display(string account, double amount, bool success);
        void Display(string pin, bool success);
        void ShowBalance(string account);
    }
}

/*****************************************************************************************************/


namespace Exercise
{
    public interface Resizeable
    {
        public void Resize();
    }

    public class VerifyPinExercise
    {
        public class ATMbankAmerica : IAtm
        {
            public string Pin { get; private set; }

            public ATMbankAmerica(string pin)
            {
                Pin = pin;
            }


            public void Display(string account, double amount, bool success)
            {
                throw new NotImplementedException();
            }

            public void Display(string pin, bool success)
            {
                throw new NotImplementedException();
            }

            public string SelectAccount()
            {
                throw new NotImplementedException();
            }

            public void ShowBalance(string account)
            {
                throw new NotImplementedException();
            }

            public bool VerifyPin(string pin)
            {
                if (!string.IsNullOrEmpty(pin))
                    return Pin == pin;

                return false;
            }


            public bool Withdraw(string account, double amount)
            {
                throw new NotImplementedException();
            }
        }
    }
}


