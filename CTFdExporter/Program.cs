using System;
using System.IO;

namespace CTFdExporter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CTFd api/v1/scoreboard to CTFTime converter");
            if (args.Length != 1)
            {
                Console.WriteLine("Provide the scoreboard.json as a parameter to this script (CTFdExprter.exe C:/FullPath/To/scoreboard.json");
                Console.ReadLine();
                return;
            }

            var path = args[0];
            var fileExists = File.Exists(path);
            if (!fileExists)
            {
                Console.WriteLine("Couldn't find file. You sure you provided the correct path (CTFdExprter.exe C:/FullPath/To/scoreboard.json");
                Console.ReadLine();
                return;
            }

            var input = File.ReadAllText(path);
            var ctfTimeJSON = CTFTimeConverter.Convert(input);

            var newPath = GenerateNewPath(path);

            File.WriteAllText(newPath, ctfTimeJSON);
        }

        private static string GenerateNewPath(string path)
        {
            var filename = Path.GetFileNameWithoutExtension(path);
            var ctfTimeFilename = $"{filename}_cttime";
            return path.Replace(filename, ctfTimeFilename);
        }
    }
}
