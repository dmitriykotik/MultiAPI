using System.Text;

/* 
  =================- INFO -===================
 * File:         | Generator.cs
 * Class:        | Generator
 * Project:      | MultiAPI
 * Author:       | dmitriykotik
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
        /// <param name="Length">Длина пароля (Мин. значение: 1)</param>
        /// <returns>Пароль</returns>
        /// <exception cref="Exceptions.OutOfBounds">Выход за пределы границ</exception>
        public static string GenPassword(int Length)
        {
            if (Length < 1) throw new Exceptions.OutOfBounds("Generator.GenPassword -> Length < 1");

            const string chars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ@-+=%*&?$#";

            StringBuilder sb = new StringBuilder();
            Random rnd = new Random();

            for (int i = 0; i < Length; i++)
            {
                int index = rnd.Next(chars.Length);
                sb.Append(chars[index]);
            }
            return sb.ToString();
        }

        /// <summary>
        /// Генерация пароля со своим словарём символов
        /// </summary>
        /// <param name="Length">Длина пароля</param>
        /// <param name="Dictionary">Словарь символов</param>
        /// <returns>Пароль</returns>
        /// <exception cref="Exceptions.NullField">Нулевое поле</exception>
        /// <exception cref="Exceptions.OutOfBounds">Выход за пределы границ</exception>
        public static string GenPassword(int Length, string Dictionary)
        {
            if (string.IsNullOrEmpty(Dictionary)) throw new Exceptions.NullField("Generator.GenPassword -> string Dictionary");
            if (Length < 1) throw new Exceptions.OutOfBounds("Generator.GenPassword -> Length < 1");

            StringBuilder sb = new StringBuilder();
            Random rnd = new Random();

            for (int i = 0; i < Length; i++)
            {
                int index = rnd.Next(Dictionary.Length);
                sb.Append(Dictionary[index]);
            }
            return sb.ToString();
        }
        #endregion

    }
    #endregion

}
