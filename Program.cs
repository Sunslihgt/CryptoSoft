using System.Diagnostics;

public class CryptoSoft
{
    public static int Main(string[] args)
    {
        if (args.Length != 3)
        {
            return -1; // Argument count is incorrect
        }

        string inputFilePath = args[0];
        string outputFilePath = args[1];
        string key = args[2];

        return EncryptDecryptFile(inputFilePath, outputFilePath, key);
    }

    // Returns the time taken to encrypt/decrypt the file in milliseconds or -1 if an error occurred
    private static int EncryptDecryptFile(string inputFilePath, string outputFilePath, string key)
    {
        if (!File.Exists(inputFilePath))
        {
            return -1; // Input file does not exist
        }

        if (key == null || key.Length < 16)
        {
            return -1; // Key is null
        }

        // Start stopwatch
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        byte[] keyBytes = System.Text.Encoding.UTF8.GetBytes(key);

        byte[] inputBytes = File.ReadAllBytes(inputFilePath);
        byte[] outputBytes = new byte[inputBytes.Length];

        // Encrypt
        for (int i = 0; i < inputBytes.Length; i++)
        {
            outputBytes[i] = (byte)(inputBytes[i] ^ keyBytes[i % keyBytes.Length]);
        }

        File.WriteAllBytes(outputFilePath, outputBytes);

        // Stop stopwatch
        stopwatch.Stop();
        Console.WriteLine($"Time taken: {stopwatch.ElapsedMilliseconds} ms");

        return (int) stopwatch.Elapsed.TotalMilliseconds;
    }
}
