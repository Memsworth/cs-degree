#!

System.Console.WriteLine("Hello world");
var cipher = new CaesarCipher(5);
System.Console.WriteLine($"Encryption = {new string(cipher.Encoder)}");
System.Console.WriteLine($"Decryption = {new string(cipher.Decoder)}");
var message = "THE EAGLE IS IN PLAY; MEET AT JOE'S.";
var encrypted = cipher.Encrypt(message);
System.Console.WriteLine($"secret: {encrypted}");
var decrypted = cipher.Decrypt(encrypted);
System.Console.WriteLine($"secret: {decrypted}");

public class CaesarCipher
{
    public char[] Encoder { get; }
    public char[] Decoder { get; }

    public CaesarCipher(int rotation)
    {
        Encoder = new char[26];
        Decoder = new char[26];
        for (int i = 0; i < 26; i++)
        {
            Encoder[i] = (char)('A' + (i + rotation) % 26);
            Decoder[i] = (char)('A' + (i - rotation + 26) % 26);
        }
    }

    public string Encrypt(string message) => Transform(message, Encoder);
    public string Decrypt(string message) => Transform(message, Decoder);

    private string Transform(string message, char[] encoder)
    {
        if (string.IsNullOrEmpty(message))
            throw new ArgumentNullException();

        char[] messageArray = message.ToCharArray();
        for (int i = 0; i < messageArray.Length; i++)
        {
            if (char.IsUpper(messageArray[i]))
            {
                var newIndex = messageArray[i] - 'A';
                messageArray[i] = encoder[newIndex];
            }
        }

        return new string(messageArray);
    }
}