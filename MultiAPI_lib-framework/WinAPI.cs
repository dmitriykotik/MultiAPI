﻿using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Drawing;

/* 
  =================- INFO -===================
 * File:         | WinAPI.cs
 * Class:        | WinAPI
 * Project:      | MultiAPI
 * Author:       | dmitriykotik
 * Version:      | 0.0.0.0
 * VerType:      | major_version.minor_version.patch_version.builds
 * Main file:    | Main.cs
 * [OPEN SOURCE] | +True
 * [CONSTRUCTOR] | -False
  =- ATTENTION -==============================
 * ATTENTION! The use of this function may cause irreversible consequences 
 * for an ordinary user in case of incorrect use or incorrectly written class code. 
 * Before publishing your software using this class, please make sure that your 
 * software will not harm the average user in any way. We are not responsible 
 * for the fact that you can harm or destroy the system with methods from the class 
 * and the like. All responsibility shifts to you. 
 * Be careful! Good luck!
 * 
 * This code was generated by AI. It is also written, added or modified by a human. 
 * The code may not work correctly in some places.
  ============================================
 */

namespace MultiAPI
{
    #region CLASS | WinAPI
    /// <summary>
    /// Класс взаимодействия с библиотекой WinAPI
    /// </summary>
    public static class WinAPI
    {
        #region CLASS | Window
        /// <summary>
        /// Взаимодействие с окнами
        /// </summary>
        public static class Window
        {
            #region Импорт методов
            [DllImport("user32.dll")]
            private static extern IntPtr CreateWindowEx(
                WindowStylesEx dwExStyle,
                string lpClassName,
                string lpWindowName,
                WindowStyles dwStyle,
                int x,
                int y,
                int nWidth,
                int nHeight,
                IntPtr hWndParent,
                IntPtr hMenu,
                IntPtr hInstance,
                IntPtr lpParam
            );

            [DllImport("user32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            private static extern bool ShowWindow(IntPtr hWnd, ShowWindowCommands nCmdShow);

            [DllImport("user32.dll", SetLastError = true)]
            private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

            [DllImport("user32.dll", SetLastError = true)]
            private static extern bool DestroyWindow(IntPtr hWnd);

            [DllImport("user32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            private static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

            [DllImport("user32.dll")]
            private static extern bool UpdateWindow(IntPtr hWnd);

            [DllImport("user32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            private static extern bool SetWindowText(IntPtr hWnd, string lpString);

            [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
            static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);
            #endregion

            #region Стили
            /// <summary>
            /// Стили окна
            /// </summary>
            public enum WindowStyles : uint
            {
                /// <summary>
                /// 
                /// </summary>
                WS_OVERLAPPED = 0x00000000,
                /// <summary>
                /// 
                /// </summary>
                WS_CAPTION = 0x00C00000,
                /// <summary>
                /// 
                /// </summary>
                WS_SYSMENU = 0x00080000,
                /// <summary>
                /// 
                /// </summary>
                WS_MINIMIZEBOX = 0x00020000,
                /// <summary>
                /// 
                /// </summary>
                WS_MAXIMIZEBOX = 0x00010000,
                /// <summary>
                /// 
                /// </summary>
                WS_THICKFRAME = 0x00040000,
                /// <summary>
                /// 
                /// </summary>
                WS_VISIBLE = 0x10000000
            }

            /// <summary>
            /// Стили окна
            /// </summary>
            public enum WindowStylesEx : uint
            {
                /// <summary>
                /// 
                /// </summary>
                WS_EX_APPWINDOW = 0x00040000,
                /// <summary>
                /// 
                /// </summary>
                WS_EX_WINDOWEDGE = 0x00000100
            }

            /// <summary>
            /// Тип отображения окна
            /// </summary>
            public enum ShowWindowCommands : int
            {
                /// <summary>
                /// 
                /// </summary>
                SW_SHOWNORMAL = 1,
                /// <summary>
                /// 
                /// </summary>
                SW_SHOWMAXIMIZED = 3
            }
            #endregion

            #region METHOD-INTPTR | Create
            /// <summary>
            /// Создать окно
            /// </summary>
            /// <param name="windowStyleEx">Стиль окна из WindowStylesEx</param>
            /// <param name="windowStyle">Стиль окна из WindowStyle</param>
            /// <param name="className">Название класса в котором будет находится окно</param>
            /// <param name="windowName">Имя окна (отображается)</param>
            /// <param name="x">Положение окна по оси X</param>
            /// <param name="y">Положение окна по оси Y</param>
            /// <param name="width">Размер окна (Ширина)</param>
            /// <param name="height">Размер окна (Высота)</param>
            /// <returns>hWindow для дальнейшего использования в методах (для переменных укажите тип IntPtr, например: IntPtr windowExample = WinAPI.Window.Create(...); )</returns>
            public static IntPtr Create(WindowStylesEx windowStyleEx, WindowStyles windowStyle, string className, string windowName, int x, int y, int width, int height)
            {
                if (string.IsNullOrEmpty(className) || string.IsNullOrEmpty(windowName)) throw new Exception("0x00003");
                if (x < 0 || y < 0 || width < 1 || height < 1) throw new Exception("0x00006");
                return CreateWindowEx(
                    windowStyleEx,
                    className,
                    windowName,
                    windowStyle,
                    x,
                    y,
                    width,
                    height,
                    IntPtr.Zero,
                    IntPtr.Zero,
                    IntPtr.Zero,
                    IntPtr.Zero
                );
            }
            #endregion

            #region METHOD-BOOL | Show
            /// <summary>
            /// Отобразить окно
            /// </summary>
            /// <param name="hWindow">Окно</param>
            /// <param name="command">Тип отображения окна из ShowWindowCommands</param>
            /// <returns></returns>
            public static bool Show(IntPtr hWindow, ShowWindowCommands command)
            {
                return ShowWindow(hWindow, command);
            }
            #endregion

            #region METHOD-INTPTR | Find
            /// <summary>
            /// Найти окно по классу и названию
            /// </summary>
            /// <param name="className">Класс окна</param>
            /// <param name="windowName">Имя окна</param>
            /// <returns>Само окно в IntPtr для дальнейшего использования в методах или переменных</returns>
            public static IntPtr Find(string className, string windowName)
            {
                if (string.IsNullOrEmpty(className) || string.IsNullOrEmpty(windowName)) throw new Exception("0x00003");
                return FindWindow(className, windowName);
            }
            #endregion

            #region METHOD-BOOL | Destroy
            /// <summary>
            /// Уничтожение окна
            /// </summary>
            /// <param name="hWnd">Само окно</param>
            /// <returns></returns>
            public static bool Destroy(IntPtr hWnd) => DestroyWindow(hWnd);
            #endregion

            #region METHOD-BOOL | Move
            /// <summary>
            /// Изменить размер и позицию окна
            /// </summary>
            /// <param name="hWindow">Само окно</param>
            /// <param name="x">Новая позиция по оси X</param>
            /// <param name="y">Новая позиция по оси Y</param>
            /// <param name="width">Новый размер по ширине</param>
            /// <param name="height">Новый размер по высоте</param>
            /// <returns></returns>
            public static bool Move(IntPtr hWindow, int x, int y, int width, int height)
            {
                if (x < 0 || y < 0 || width < 1 || height < 1) throw new Exception("0x00006");
                return MoveWindow(hWindow, x, y, width, height, true);
            }
            #endregion

            #region METHOD-BOOL | Update
            /// <summary>
            /// Обновить окно
            /// </summary>
            /// <param name="hWindow">Само окно</param>
            /// <returns></returns>
            public static bool Update(IntPtr hWindow) => UpdateWindow(hWindow);
            #endregion

            #region METHOD-BOOL | SetText
            /// <summary>
            /// Установить новый текст (новое имя) окну
            /// </summary>
            /// <param name="hWindow">Само окно</param>
            /// <param name="text">Новый текст (Новое имя)</param>
            /// <returns></returns>
            public static bool SetText(IntPtr hWindow, string text)
            {
                if (string.IsNullOrEmpty(text)) throw new Exception("0x00003");
                return SetWindowText(hWindow, text);
            }
            #endregion

            #region METHOD-STRING | GetText
            /// <summary>
            /// Получить текст (имя) окна
            /// </summary>
            /// <param name="hWnd">Окно</param>
            /// <param name="maxLength">Максимальный размер получаемого текста</param>
            /// <returns>Текст (имя) окна</returns>
            public static string GetText(IntPtr hWnd, int maxLength = 1024)
            {
                var buff = new StringBuilder(maxLength);
                GetWindowText(hWnd, buff, maxLength);
                return buff.ToString();
            }
            #endregion
        }
        #endregion

        #region CLASS | ConsoleWindow
        /// <summary>
        /// Взаимодействие с консольными окнами
        /// </summary>
        public static class ConsoleWindow
        {
            #region Импорт методов
            [DllImport("kernel32.dll", SetLastError = true)]
            private static extern IntPtr GetConsoleWindow();

            [DllImport("user32.dll", SetLastError = true)]
            private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

            [DllImport("user32.dll", SetLastError = true)]
            private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

            [DllImport("user32.dll", SetLastError = true)]
            private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

            [DllImport("user32.dll")]
            private static extern bool RemoveMenu(IntPtr hMenu, uint uPosition, uint uFlags);

            private const int GWL_STYLE = -16;

            private const uint MF_BYCOMMAND = 0x00000000;

            [DllImport("kernel32.dll", SetLastError = true)]
            private static extern IntPtr CreateFile(
            string lpFileName,
            int dwDesiredAccess,
            int dwShareMode,
            IntPtr lpSecurityAttributes,
            int dwCreationDisposition,
            int dwFlagsAndAttributes,
            IntPtr hTemplateFile);

            [DllImport("kernel32.dll", SetLastError = true)]
            private static extern bool GetCurrentConsoleFont(
                IntPtr hConsoleOutput,
                bool bMaximumWindow,
                [Out][MarshalAs(UnmanagedType.LPStruct)] ConsoleFontInfo lpConsoleCurrentFont);

            [DllImport("kernel32.dll", SetLastError = true)]
            private static extern IntPtr GetStdHandle(int nStdHandle);

            [DllImport("kernel32.dll")]
            private static extern bool GetConsoleCursorInfo(IntPtr hConsoleOutput, out CONSOLE_CURSOR_INFO lpConsoleCursorInfo);

            [DllImport("kernel32.dll")]
            private static extern bool SetConsoleCursorInfo(IntPtr hConsoleOutput, ref CONSOLE_CURSOR_INFO lpConsoleCursorInfo);


            [StructLayout(LayoutKind.Explicit)]
            private struct CharInfo
            {
                [FieldOffset(0)]
                public char UnicodeChar;
                [FieldOffset(2)]
                public short Attributes;
            }

            private const int STD_OUTPUT_HANDLE = -11;

            [StructLayout(LayoutKind.Sequential)]
            private class ConsoleFontInfo
            {
                internal int nFont;
                internal Coord dwFontSize;
            }

            [StructLayout(LayoutKind.Explicit)]
            private struct Coord
            {
                [FieldOffset(0)]
                internal short X;
                [FieldOffset(2)]
                internal short Y;
            }

            [StructLayout(LayoutKind.Sequential)]
            private struct CONSOLE_CURSOR_INFO
            {
                public uint dwSize;
                public bool bVisible;
            }
            #endregion

            #region Стили
            #region Скрытый
            private enum ConsoleFont : int
            {
                GENERIC_READ = unchecked((int)0x80000000),
                GENERIC_WRITE = 0x40000000,
                FILE_SHARE_READ = 1,
                FILE_SHARE_WRITE = 2,
                INVALID_HANDLE_VALUE = -1,
                OPEN_EXISTING = 3
            }
            #endregion
            #region Открытый
            /// <summary>
            /// Кнопки
            /// </summary>
            public enum WindowStyle : int
            {
                /// <summary>
                /// 
                /// </summary>
                WS_MAXIMIZEBOX = 0x00010000,
                /// <summary>
                /// 
                /// </summary>
                WS_MINIMIZEBOX = 0x00020000,
                /// <summary>
                /// 
                /// </summary>
                WS_SYSMENU = 0x00080000
            }

            /// <summary>
            /// Кнопки
            /// </summary>
            public enum SCWindowStyle : uint
            {
                /// <summary>
                /// 
                /// </summary>
                SC_CLOSE = 0xF060,
                /// <summary>
                /// 
                /// </summary>
                SC_MINIMIZE = 0xF020,
                /// <summary>
                /// 
                /// </summary>
                SC_MAXIMIZE = 0xF030,
                /// <summary>
                /// 
                /// </summary>
                SC_SIZE = 0xF000
            }
            #endregion
            #endregion

            #region METHOD-IntPtr | GetConsoleWindow
            /// <summary>
            /// Получает hWnd текущего консольного окна
            /// </summary>
            public static IntPtr GetWindow() => GetConsoleWindow();
            #endregion

            #region METHOD-SIZE | GetFontSize
            /// <summary>
            /// Получает размер шрифта консоли для разметки по символам
            /// </summary>
            /// <returns>Размер шрифта</returns>
            public static Size GetFontSize()
            {
                IntPtr outHandle = CreateFile("CONOUT$", (int)ConsoleFont.GENERIC_READ | (int)ConsoleFont.GENERIC_WRITE,
                    (int)ConsoleFont.FILE_SHARE_READ | (int)ConsoleFont.FILE_SHARE_WRITE,
                    IntPtr.Zero,
                    (int)ConsoleFont.OPEN_EXISTING,
                    0,
                    IntPtr.Zero);
                ConsoleFontInfo cfi = new ConsoleFontInfo();
                return new Size(cfi.dwFontSize.X, cfi.dwFontSize.Y);
            }
            #endregion

            #region METHOD-VOID | InjectPicture
            /// <summary>
            /// Инъецирует картинку в определённое консольное окно
            /// </summary>
            /// <param name="hWnd">Окно</param>
            /// <param name="pathToImage">Путь до изображения которое нужно вставить</param>
            /// <param name="size_x">Размер в точках по оси X или в символах если параметр useMetricFont включён</param>
            /// <param name="size_y">Размер в точках по оси Y или в символах если параметр useMetricFont включён</param>
            /// <param name="pos_x">Позиция изображения в точках по оси X или в символах если параметр useMetricFont включён</param>
            /// <param name="pos_y">Позиция изображения в точках по оси X или в символах если параметр useMetricFont включён</param>
            /// <param name="useMetricFont">Включает использование метрической системы в виде символов (Определяется по размеру шрифта)</param>
            public static void InjectPicture(IntPtr hWnd, string pathToImage, int size_x, int size_y, int pos_x, int pos_y, bool useMetricFont = true)
            {
                using (Graphics g = Graphics.FromHwnd(hWnd))
                {
                    using (System.Drawing.Image image = System.Drawing.Image.FromFile(pathToImage))
                    {
                        if (useMetricFont)
                        {
                            Size fontSize = GetFontSize();
                            Rectangle imageRect = new Rectangle(
                                pos_x * fontSize.Width,
                                pos_y * fontSize.Height,
                                size_x * fontSize.Width,
                                size_y * fontSize.Height);
                            g.DrawImage(image, imageRect);
                        }
                        else
                        {
                            Rectangle imageRect = new Rectangle(
                                pos_x,
                                pos_y,
                                size_x,
                                size_y);
                            g.DrawImage(image, imageRect);
                        }
                    }
                }
            }
            #endregion

            #region METHOD-VOID | ModifyStyleControl
            /// <summary>
            /// Модификация стиля панели управления (Кнопки, изменение размера и т.д.)
            /// </summary>
            /// <param name="hWnd">Окно</param>
            /// <param name="windowStyle">Стиль из ConsoleWindow.WindowStyle</param>
            public static void ModifyStyleControl(IntPtr hWnd, WindowStyle windowStyle) => SetWindowLong(hWnd, GWL_STYLE, GetWindowLong(hWnd, GWL_STYLE) & ~(int)windowStyle);
            #endregion

            #region METHOD-VOID | ModifyStyleControlSC
            /// <summary>
            /// Модификация стиля панели управления (Кнопки, изменение размера и т.д.). Фактически аналог ModifyStyleControl с дополнительным функционалом
            /// </summary>
            /// <param name="hWnd">Окно</param>
            /// <param name="SCwindowStyle">Стиль из ConsoleWindow.SCWindowStyle</param>
            public static void ModifyStyleControlSC(IntPtr hWnd, SCWindowStyle SCwindowStyle) => RemoveMenu(GetSystemMenu(hWnd, false), (uint)SCwindowStyle, MF_BYCOMMAND);
            #endregion

            #region METHOD-VOID | CursorVisiblity
            /// <summary>
            /// Активен ли консольный курсор?
            /// </summary>
            /// <param name="visible">Виден? (true или false)</param>
            public static void CursorVisibility(bool visible)
            {
                IntPtr consoleHandle = GetStdHandle(-11); // Получаем дескриптор вывода консоли (STD_OUTPUT_HANDLE)
                CONSOLE_CURSOR_INFO cursorInfo;
                GetConsoleCursorInfo(consoleHandle, out cursorInfo);
                cursorInfo.bVisible = visible;
                SetConsoleCursorInfo(consoleHandle, ref cursorInfo);
            }
            #endregion

            #region METHOD-VOID | ScrollVisible(False - True)
            /// <summary>
            /// Выключают консольный скрол
            /// </summary>
            public static void ScrollVisibleFalse()
            {
                Console.BufferWidth = Console.WindowWidth;
                Console.BufferHeight = Console.WindowHeight;
            }

            /// <summary>
            /// Включает консольный курсор
            /// </summary>
            public static void ScrollVisibleTrue()
            {
                Console.BufferHeight = Console.BufferHeight + 4096;
            }
            #endregion
        }
        #endregion
    }
    #endregion
}
