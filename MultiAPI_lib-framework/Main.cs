﻿using System;
using System.Threading;

/* 
  =================- INFO -===================
 * File:         | Main.cs
 * Class:        | Basic
 * Project:      | MultiAPI
 * Author:       | dmitriykotik
 * Version:      | 0.1.4.221
 * VerType:      | major_version.minor_version.patch_version.build
 * Main file:    | Main.cs
 * [OPEN SOURCE] | +True
 * [CONSTRUCTOR] | -False
  ============================================
 */

namespace MultiAPI
{
    #region Assembly Info
    internal class AssemblyI
    {
        internal const string version = "0.1.4.221";
    }
    #endregion

    #region CLASS | Basic
    /// <summary>
    /// Базовые функции
    /// </summary>
    public static class Basic
    {

        #region METHOD-INT | rnd
        /// <summary>
        /// Возвращает случайное число в диапазоне от "startInt" до "endInt"
        /// </summary>
        /// <param name="startInt">Начальное число</param>
        /// <param name="endInt">Конечное число</param>
        /// <returns>Случайное число в диапазоне от "startInt" до "endInt"</returns>
        public static int rnd(int startInt, int endInt)
        {
            Random rnd = new Random();
            return rnd.Next(startInt, endInt);
        }
        #endregion

        #region METHOD-VOID | terminate
        /// <summary>
        /// Завершает работу программы с определённым кодом ошибки
        /// </summary>
        /// <param name="errorCode">Код ошибки</param>
        public static void terminate(int errorCode) => Environment.Exit(errorCode);
        #endregion

        #region METHOD-STRING | getCurrentFolder
        /// <summary>
        /// Получение пути к текущей папке
        /// </summary>
        /// <returns>Путь к текущей папке программы</returns>
        public static string getCurrentFolder() { return Environment.CurrentDirectory; }
        #endregion

        #region METHOD-VOID | writeMachine
        /// <summary>
        /// Печатает текст побуквенно с определённым промежутком времени в терминал
        /// </summary>
        /// <param name="text">Текст строки</param>
        /// <param name="countDown">Промежуток времени между буквами в миллисекундах</param>
        /// <param name="writeLine">Отступить строчку после выполнения?</param>
        public static void writeMachine(string text, int countDown = 40, bool writeLine = true)
        {
            if (string.IsNullOrEmpty(text)) throw new Exception("0x00003");
            if (countDown == 0) throw new Exception("0x00001");
            else if (countDown < 0) throw new Exception("0x00002");
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(countDown);
            }
            if (writeLine) Console.WriteLine();
        }
        #endregion

    }
    #endregion
}
