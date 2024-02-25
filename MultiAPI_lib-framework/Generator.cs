using System;
using System.Text;

/* 
  =================- INFO -===================
 * File:         | Generator.cs
 * Class:        | Generator
 * Project:      | MultiAPI
 * Author:       | Plufik
 * Version:      | 0.1.1.32
 * VerType:      | major_version.minor_version.patch_version.builds
 * Main file:    | Main.cs
 * [OPEN SOURCE] | +True
 * [CONSTRUCTOR] | -False
  ============================================
 */

namespace MultiAPI
{

    #region CLASS | Generator
    /// <summary>
    /// Действия с генераторами
    /// </summary>
    public static class Generator
    {

        #region METHOD-STRING | GenPassword
        /// <summary>
        /// Генерация пароля со стандартным словарём символов
        /// </summary>
        /// <param name="length">Длина пароля</param>
        /// <returns>Пароль</returns>
        public static string GenPassword(int length)
        {
            const string chars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ@-+=%*&?$#";

            StringBuilder sb = new StringBuilder();
            Random rnd = new Random();

            for (int i = 0; i < length; i++)
            {
                int index = rnd.Next(chars.Length);
                sb.Append(chars[index]);
            }
            return sb.ToString();
        }

        /// <summary>
        /// Генерация пароля со своим словарём символов
        /// </summary>
        /// <param name="length">Длина пароля</param>
        /// <param name="dictionary">Словарь символов</param>
        /// <returns>Пароль</returns>
        public static string GenPassword(int length, string dictionary)
        {
            StringBuilder sb = new StringBuilder();
            Random rnd = new Random();

            for (int i = 0; i < length; i++)
            {
                int index = rnd.Next(dictionary.Length);
                sb.Append(dictionary[index]);
            }
            return sb.ToString();
        }
        #endregion

    }
    #endregion

}
