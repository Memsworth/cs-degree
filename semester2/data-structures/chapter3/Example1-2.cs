//Cryptography

var cipher = new CaeserCipher();

var message = "THE EAGLE IS IN PLAY; MEET AT JOE'S.";

var coded = cipher.Encrypt(message);

System.Console.WriteLine($"Encode: {coded}");

var decoded = cipher.Decrypt(coded);

System.Console.WriteLine($"Decrypted: {decoded}");

if (string.Equals(message, decoded))
{
    System.Console.WriteLine("message is original");
}

public class CaeserCipher
{
    private static readonly Random rand = new Random();
    private readonly int rotation;

    public CaeserCipher()
    {
        rotation = rand.Next(1, 6);
    }

    public string Encrypt(string message)
    {
        var messageArray = message.ToCharArray();
        for (int i = 0; i < messageArray.Length; i++)
        {
            if (Char.IsUpper(messageArray[i]))
            {
                var item = (char)('A' + (messageArray[i] + rotation) % 26);
                messageArray[i] = item;
            }
        }

        //Kana's suggestion: Use string . create for performance
        return string.Create(messageArray);
    }


    public string Decrypt(string message)
    {
        var messageArray = message.ToCharArray();
        for (int i = 0; i < messageArray.Length; i++)
        {
            if (Char.IsUpper(messageArray[i]))
            {
                var item = (char)('A' + (messageArray[i] - rotation + 26) % 26);
                messageArray[i] = item;
            }
        }
        return string.Create(messageArray);
    }

}