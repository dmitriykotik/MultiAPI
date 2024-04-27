using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                string[] input = Console.ReadLine().Split(' ');
                switch (input[0])
                {
                    default:
                        if (!string.IsNullOrEmpty(input[0]))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($@"""{input[0]}"" не является внутренней или внешней
командой, исполняемой программой или пакетным файлом.
");
                            Console.ResetColor();
                        }
                        break;
                }
            }
        }
    }
}
