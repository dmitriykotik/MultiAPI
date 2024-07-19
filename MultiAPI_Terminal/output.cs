using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiAPI_Terminal
{
    public static class output
    {
        public static void errorMsg(string Message)
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("[ERROR] " + Message);
            Console.ResetColor();
        }

        public static void warningMsg(string Message)
        {
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("[WARNING] " + Message);
            Console.ResetColor();
        }

        public static void infoMsg(string Message)
        {
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("[INFO] " + Message);
            Console.ResetColor();
        }
    }
}
