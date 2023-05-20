using System;
using System.Diagnostics;
using System.IO;

class Program
{
    static void Main()
    {
        string directoryPath = "шлях_до_каталогу";

        if (!Directory.Exists(directoryPath))
        {
            Console.WriteLine("Каталог не існує.");
            return;
        }

        ProcessStartInfo startInfo = new ProcessStartInfo();
        startInfo.FileName = "cmd.exe";
        startInfo.RedirectStandardOutput = true;
        startInfo.UseShellExecute = false;
        startInfo.Arguments = $"/c dir /a-d /b \"{directoryPath}\" | find /v /c \"\" > files_count.txt";

        Process process = new Process();
        process.StartInfo = startInfo;
        process.Start();
        process.WaitForExit();

        string filesCountPath = Path.Combine(directoryPath, "files_count.txt");

        if (File.Exists(filesCountPath))
        {
            string filesCount = File.ReadAllText(filesCountPath);
            Console.WriteLine($"Number of files: {filesCount}");
        }
        else
        {
            Console.WriteLine("Не вдалося знайти файл files_count.txt.");
        }
    }
}