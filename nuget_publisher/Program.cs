using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nuget_publisher
{
    // arg0 targetdir
    // arg1 pathToMainCS
    // arg2 SolutionDir
    // arg3 TargetName
    internal class Program
    {
        public static string va;
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(args[1]);
            string line24 = lines[23];
            string textInBrackets = line24.Split('"')[1];
            Console.WriteLine($"Подготовка к публикации пакета {args[3]}.{textInBrackets}.nupkg...");
            Console.WriteLine("В открывшемся диалоговом окне, пожалуйста, введите свой секретный ключ для публикации вашего пакета на NuGet");
            settingsKey n = new settingsKey();
            n.ShowDialog();
            if (va == "ret") 
            { 
                Console.WriteLine("Публикация пакета на NuGet была отменена пользователем"); 
                Environment.Exit(0);
            }
            else
            {
                
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = args[2] + "nuget\\nuget.exe";
                psi.Arguments = $"push {args[0]}{args[3]}.{textInBrackets}.nupkg {va} -Source https://api.nuget.org/v3/index.json";
                Process.Start(psi).WaitForExit();
                Environment.Exit(0);
            }


        }

    }
}
