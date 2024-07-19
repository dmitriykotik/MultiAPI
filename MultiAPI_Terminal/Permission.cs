using MultiAPI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Terminal.Gui;

namespace MultiAPI_Terminal
{
    public static class Permission
    {
        public static void MS(string mpackage, string[] args)
        {
            if (isMPack(mpackage))
            {
                string command_start;

                if (!Directory.Exists("package")) Directory.CreateDirectory("package");
                if (Directory.Exists(".temp")) { Directory.Delete(".temp", true); Directory.CreateDirectory(".temp"); }
                else Directory.CreateDirectory(".temp");
                if (!File.Exists(mpackage)) return;

                try { Zip.unpacking(mpackage, ".temp"); }
                catch { output.errorMsg("Не удалось распаковать пакет!"); return; }

                if (!File.Exists(".temp\\.properties")) return;

                INI _properties = new INI(".temp\\.properties");

                command_start = _properties.getValue("Properties", "commandStart");

                if (Directory.Exists("package\\" + command_start))
                {
                    Console.WriteLine("Пакет с названием " + command_start + " уже существует!");
                    Console.Write("Желаете поместить устанавливаемый пакет в другую директорию? (y/n): ");
                    if (Console.ReadLine().ToLower() == "y")
                    {
                        Console.WriteLine();
                        Console.WriteLine("Введите название для новой директории пакета (с ним будет установлена новая команда пакета): ");
                        string path = Console.ReadLine();
                        if (!string.IsNullOrEmpty(path)) command_start = path;
                    }
                    else return;
                }


                try { Directory.CreateDirectory("package\\" + command_start); }
                catch { output.errorMsg("Не удалось создать папку " + command_start + "!"); return; }
                try { Zip.unpacking(mpackage, "package\\" + command_start); }
                catch { output.errorMsg("Не удалось распаковать пакет!"); return; }
                INI _properiesORG = new INI("package\\" + command_start + "\\.properties");
                _properiesORG.setValue("Properties", "commandStart", command_start);
                try { Directory.Delete(".temp", true); }
                catch { output.errorMsg("Не удалось удалить папку .temp!"); return; }
                Console.WriteLine(_properiesORG.getValue("Terminal", "writeFinishSetupMessage"));
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Пакет успешно установлен! Запустить его можно командой \"{command_start}\"");
                Console.ResetColor();
                return;
            }
            else
            {
                if (!Directory.Exists($"package\\{mpackage}")) return;
                if (!File.Exists($"package\\{mpackage}\\.properties")) return;
                INI g = new INI($"package\\{mpackage}\\.properties");
                string file = g.getValue("Properties", "mainFile");
                if (g.getValue("Terminal", "clearConsoleOnStart") == "true") Console.Clear();
                ProcessStartInfo startinfo = new ProcessStartInfo($"package\\{mpackage}\\{file}");
                if (args.Length > 1) startinfo.Arguments = string.Join(" ", args.Skip(1));
                startinfo.CreateNoWindow = false;
                startinfo.UseShellExecute = false;
                Process p = Process.Start(startinfo);
                p.WaitForExit();
            }
        }

        public static bool isMPack(string mpackage)
        {
            if (Path.GetExtension(mpackage) == ".mpack" || Path.GetExtension(mpackage) == ".mpackage" || Path.GetExtension(mpackage) == ".mp") return true;
            return false;
        }
    }
    
}
