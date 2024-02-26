using System;
using System.IO;
using System.Text.RegularExpressions;

namespace MultiAPI_Tester
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("E:\\repos\\MultiAPI\\MultiAPI_lib-framework\\Main.cs");
            string line24 = lines[23]; // индексация начинается с 0, поэтому 24-я строка имеет индекс 23
            string textInBrackets = line24.Split('"')[1]; // извлечение текста в скобках
            Console.WriteLine(textInBrackets);
            Console.ReadLine();
        }


    }
}
