using System;
using System.Diagnostics;
using System.Text;
using System.Threading;

public class CryptoSoft
{
    public static int Main(string[] args)
    {
        const string mutexName = "Global/CryptoSoftMutex"; // System-wide unique mutex name
        using (Mutex mutex = new Mutex(true, mutexName, out bool createdNew))
        {
            if (!createdNew)
            {
                // Another instance is already running
                return -1;
            }

            // Proceed with normal execution
            if (args.Length != 3)
            {
                return -1; // Argument count is incorrect
            }

            string inputFilePath = args[0];
            string outputFilePath = args[1];
            string key = args[2];

            return EncryptDecryptFile(inputFilePath, outputFilePath, key);
        } 
    }

    private static int EncryptDecryptFile(string inputFilePath, string outputFilePath, string key)
    {
        if (!File.Exists(inputFilePath))
        {
            return -1; // Input file does not exist
        }

        if (key == null || key.Length < 16)
        {
            return -1;
        }

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        byte[] keyBytes = Encoding.UTF8.GetBytes(key);
        const int bufferSize = 1024 * 1024; // 1 MB buffer

        try
        {
            using (FileStream inputStream = new FileStream(inputFilePath, FileMode.Open, FileAccess.Read))
            using (FileStream outputStream = new FileStream(outputFilePath, FileMode.Create, FileAccess.Write))
            {
                byte[] buffer = new byte[bufferSize];
                int bytesRead;
                long position = 0;

                while ((bytesRead = inputStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    for (int i = 0; i < bytesRead; i++)
                    {
                        buffer[i] ^= keyBytes[(position + i) % keyBytes.Length];
                    }

                    outputStream.Write(buffer, 0, bytesRead);
                    position += bytesRead;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return -1;
        }

        stopwatch.Stop();
        return (int)stopwatch.Elapsed.TotalMilliseconds;
    }
}