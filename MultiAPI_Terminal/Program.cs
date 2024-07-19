using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using MultiAPI;

namespace MultiAPI_Terminal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($@"// Добро пожаловать в терминал MultiAPI!
//
// Текущая дата: {DateTime.Today}
// Название компьютера: {Environment.MachineName} 
// ОС: {Environment.OSVersion}
// Кол-во ядер процессора: {Environment.ProcessorCount}
// Имя пользователя: {Environment.UserName}
//
// Показанные данные не будут никуда отправлены, они были отображены в качестве доп. информации.
// Подробнее про MultiAPI вы можете найти в этом репозитории: https://github.com/dmitriykotik/MultiAPI
");
            while (true)
            {
                Console.Write("> ");
                string[] input = Console.ReadLine().ToLower().Split(' ');
                switch (input[0])
                {
                    case "help":
                        Console.WriteLine($@"help - текущее меню
packages (help/delete/install) - Работа с пакетами");
                        break;

                    case "packages":
                        if (input.Length >= 2)
                        {
                            switch (input[1])
                            {
                                case "help":
                                    Console.WriteLine($@"packages help - Выводит справку
packages delete [пакет] - Удаляет пакет
packages install [пакет] - Устанавливает пакет");
                                    break;

                                case "delete":
                                    if (input.Length != 3)
                                    {
                                        Console.WriteLine("Введите имя пакета для удаления (exit - для выхода):");
                                        string pack = Console.ReadLine();
                                        if (pack == "exit") break;
                                        else
                                        {
                                            if (!Directory.Exists("package\\" + pack))
                                            {
                                                output.errorMsg("Такого пакета не существует!");
                                                break;
                                            }
                                            else
                                            {
                                                try
                                                {
                                                    Directory.Delete("package\\" + pack, true);
                                                }
                                                catch
                                                {
                                                    output.errorMsg("Не удалось удалить пакет!");
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (!Directory.Exists("package\\" + input[2]))
                                        {
                                            output.errorMsg("Такого пакета не существует!");
                                            break;
                                        }
                                        else
                                        {
                                            try
                                            {
                                                Directory.Delete("package\\" + input[2], true);
                                            }
                                            catch
                                            {
                                                output.errorMsg("Не удалось удалить пакет!");
                                            }
                                        }
                                    }
                                    break;

                                case "install":
                                    if (input.Length != 3)
                                    {
                                        Console.WriteLine("Введите путь до пакетного файла (Например: C:\\folder\\superpackage.mpack) (exit - для выхода):");
                                        string pack = Console.ReadLine();
                                        if (pack == "exit") break;
                                        else Permission.MS(pack);
                                    }
                                    else Permission.MS(input[2]);
                                    break;
                            }
                        }
                        else
                        {
                            output.errorMsg("Неверные аргументы!");
                        }
                        break;

                    default:
                        if (!string.IsNullOrEmpty(input[0]))
                        {
                            if (File.Exists(input[0]) || Directory.Exists("package\\" + input[0])) Permission.MS(input[0]);
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($@"""{input[0]}"" не является внутренней или внешней
командой, исполняемой программой или пакетным файлом.
");
                                Console.ResetColor();
                            }
                        }
                        break;
                }
            }
        }
    }
}
