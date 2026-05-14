using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPlayersGuide.level24;

internal class ChallengeThePasswordValidator : IExercise
{
    public void Run()
    {
        var pass = new PasswordValidator();

        while (true)
        {
            pass.Prompt();
            pass.ValidatePassword();
        }
    }


    class PasswordValidator
    {
        private string Password { get; set; } = string.Empty;
        public void Prompt()
        {
            System.Console.WriteLine("Enter a password");
            Password = Console.ReadLine();
        }

        public void ValidatePassword()
        {
            var isCapital = false;
            var isSmol = false;
            var isNumber = false;

            if (Password.Length > 13 || Password.Length < 6)
            {
                System.Console.WriteLine("invalid");
                return;
            }


            foreach (var character in Password)
            {
                if (character == 'T' || character == '&')
                {
                    System.Console.WriteLine("invalid");
                    return;
                }

                if (char.IsUpper(character))
                    isCapital = true;
                else if (char.IsLower(character))
                    isSmol = true;
                else if (char.IsDigit(character))
                    isNumber = true;
            }

            Console.WriteLine((isCapital && isSmol && isNumber) ? "Valid" : "Invalid");
        }
    }
}
