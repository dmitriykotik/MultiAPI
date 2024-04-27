using System;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.Win32;
using System.Drawing;
using System.Runtime.InteropServices;
using MultiAPI;

namespace MultiAPI_Tester
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WinAPI.ConsoleWindow.CursorVisibility(false);
            WinAPI.ConsoleWindow.ScrollVisibleFalse();
            Console.ReadLine();
            WinAPI.ConsoleWindow.InjectPicture(WinAPI.ConsoleWindow.GetWindow, "D:\\a.png", 640, 480, 0, 0, false);
            Console.ReadLine();
            WinAPI.ConsoleWindow.ScrollVisibleTrue();
            Console.ReadLine();
            
        }

    }

}

