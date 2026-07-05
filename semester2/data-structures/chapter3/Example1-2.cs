#!
//Cryptography

var cipher = new CaeserCipher();

var message = "THE EAGLE IS IN PLAY; MEET AT JOE'S.";

var coded = cipher.EncryptWithCreate(message);

System.Console.WriteLine($"Encode: {coded}");

var decoded = cipher.DecryptWithCreate(coded);

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
        return new string(messageArray);
    }

    //Kana's suggestion: Use string . create for performance (stops copying in heap)
    public string EncryptWithCreate(string message)
    {
        //Kana's suggestion: Use string . create for performance
        return string.Create(message.Length, (object?)null, (span, _) =>
        {
            for (var i = 0; i < message.Length; i++)
            {
                if (Char.IsUpper(message[i]))
                {
                    var item = (char)('A' + (message[i] + rotation) % 26);
                    span[i] = item;
                }
                else
                {
                    span[i] = message[i];
                }
            }
        });
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
        return new string(messageArray);
    }



    //Kana's suggestion: Use string . create for performance (stops the copying in heap)
    public string DecryptWithCreate(string message)
    {
        return string.Create(message.Length, (object?)null, (span, _) =>
        {
            for (var i = 0; i < message.Length; i++)
            {
                if (Char.IsUpper(message[i]))
                {
                    var item = (char)('A' + (message[i] - rotation + 26) % 26);
                    span[i] = item;
                }
                else
                {
                    span[i] = message[i];
                }
            }
        });
    }
}