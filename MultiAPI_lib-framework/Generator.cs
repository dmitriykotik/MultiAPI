using System;
using System.Text;

/* 
  =================- INFO -===================
 * File:         | Generator.cs
 * Class:        | Generator
 * Project:      | MultiAPI
 * Author:       | Plufik
 * Version:      | 0.0.0.0
 * VerType:      | major_version.minor_version.patch_version.builds
 * Main file:    | Main.cs
 * [OPEN SOURCE] | +True
 * [CONSTRUCTOR] | -False
  ============================================
 */

namespace MultiAPI.Generator
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
            if (string.IsNullOrEmpty(Convert.ToString(length))) throw new Exception("0x00003");

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
            if (string.IsNullOrEmpty(Convert.ToString(length)) || string.IsNullOrEmpty(dictionary)) throw new Exception("0x00003");
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
