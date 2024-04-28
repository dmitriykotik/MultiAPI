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
            //WinAPI.ConsoleWindow.CursorVisibility(false);
            //WinAPI.ConsoleWindow.ScrollVisibleFalse();
            //WinAPI.ConsoleWindow.ModifyStyleControlSC(WinAPI.ConsoleWindow.GetWindow, WinAPI.ConsoleWindow.SCWindowStyle.SC_CLOSE);
            //WinAPI.ConsoleWindow.ModifyStyleControlSC(WinAPI.ConsoleWindow.GetWindow, WinAPI.ConsoleWindow.SCWindowStyle.SC_SIZE);
            //WinAPI.ConsoleWindow.ModifyStyleControlSC(WinAPI.ConsoleWindow.GetWindow, WinAPI.ConsoleWindow.SCWindowStyle.SC_MAXIMIZE);
            //WinAPI.ConsoleWindow.ModifyStyleControlSC(WinAPI.ConsoleWindow.GetWindow, WinAPI.ConsoleWindow.SCWindowStyle.SC_MINIMIZE);
            //WinAPI.ConsoleWindow.ModifyStyleControl(WinAPI.ConsoleWindow.GetWindow, WinAPI.ConsoleWindow.WindowStyle.WS_SYSMENU);
            Console.WriteLine(WinAPI.Window.GetText(WinAPI.ConsoleWindow.GetWindow, 1024));
            Console.ReadLine();
            WinAPI.Window.SetText(WinAPI.ConsoleWindow.GetWindow, "IZI4ELIC");
            Console.ReadLine();
            WinAPI.ConsoleWindow.ScrollVisibleTrue();
            Console.ReadLine();

            
        }

    }

}


