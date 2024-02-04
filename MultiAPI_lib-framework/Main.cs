using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

/* 
  ============================================
 * File:         | Main.cs
 * Project:      | MultiAPI
 * Author:       | Plufik
 * Version:      | 0.1.0.1
 * VerType:      | major_version.minor_version.patch_version.builds
 * Main file:    | Main.cs
 * [OPEN SOURCE] | +True
  ============================================
 */

namespace MultiAPI
{
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
        public static void terminate(int errorCode)
        {
            Environment.Exit(errorCode);
        }
        #endregion

        #region METHOD-STRING | getCurrentFolder
        /// <summary>
        /// Получение пути к текущей папке
        /// </summary>
        /// <returns>Путь к текущей папке программы</returns>
        public static string getCurrentFolder()
        {
            return Environment.CurrentDirectory;
        }
        #endregion

    }
    #endregion
}
