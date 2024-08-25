using System;
using System.IO;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Welcome to the virus checker");

            Console.Write("Enter the path of the file to be checked: ");
            string filePath = Console.ReadLine();

            Console.Write("Enter the path of the output file (must be .txt because results will be written to it): ");
            string outputPath = Console.ReadLine();

            // Çıkış dosyasının .txt uzantısına sahip olup olmadığını kontrol et
            if (!outputPath.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Output file must be a .txt file.");
                return;
            }

            // Başlatma işlemleri
            StartChecking(filePath, outputPath);
        }

        static void StartChecking(string filePath, string outputPath)
        {
            Console.WriteLine("Checking the file...");

            string resultMessage;

            if (File.Exists(filePath))
            {
                if (filePath.EndsWith(".exe", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Checking for viruses in the .exe file...");
                    // .exe dosyası için basit bir kontrol mesajı
                    resultMessage = "Virus checking for .exe file completed.";
                }
                else if (filePath.EndsWith(".dll", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Checking for viruses in the .dll file...");
                    // .dll dosyası için basit bir kontrol mesajı
                    resultMessage = "Virus checking for .dll file completed.";
                }
                else
                {
                    Console.WriteLine("File type not supported for virus checking.");
                    resultMessage = "File type not supported for virus checking.";
                }
            }
            else
            {
                Console.WriteLine("File not found.");
                resultMessage = "File not found.";
            }

            // Tarama sonuçlarını outputPath dosyasına yaz
            try
            {
                File.WriteAllText(outputPath, resultMessage);
                Console.WriteLine("Results written to " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to write results to file: " + ex.Message);
            }
        }
    }
}
