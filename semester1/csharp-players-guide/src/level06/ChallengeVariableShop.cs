namespace CSharpPlayersGuide.level06
{
    internal class ChallengeVariableShop : IExercise
    {
        public void Run()
        {
            int myInt = 42;

            double myDouble = 3.14159;

            float myFloat = 2.718f;

            decimal myDecimal = 19.99m;

            bool myBool = true;

            char myChar = 'A';

            string myString = "Hello, world!";

            byte myByte = 255;

            sbyte mySByte = -100;

            short myShort = -32000;

            ushort myUShort = 65000;

            uint myUInt = 4000000000;

            long myLong = 9000000000000000000;

            ulong myULong = 18000000000000000000;

            // Display all values
            Console.WriteLine("int: " + myInt);
            Console.WriteLine("double: " + myDouble);
            Console.WriteLine("float: " + myFloat);
            Console.WriteLine("decimal: " + myDecimal);
            Console.WriteLine("bool: " + myBool);
            Console.WriteLine("char: " + myChar);
            Console.WriteLine("string: " + myString);
            Console.WriteLine("byte: " + myByte);
            Console.WriteLine("sbyte: " + mySByte);
            Console.WriteLine("short: " + myShort);
            Console.WriteLine("ushort: " + myUShort);
            Console.WriteLine("uint: " + myUInt);
            Console.WriteLine("long: " + myLong);
            Console.WriteLine("ulong: " + myULong);
        }
    }
}
