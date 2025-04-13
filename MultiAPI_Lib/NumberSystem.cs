using System.Text;

/* 
  =================- INFO -===================
 * File:         | NumberSystem.cs
 * Class:        | NumberSystem
 * Project:      | MultiAPI
 * Author:       | dmitriykotik
 * [OPEN SOURCE] | +True
 * [CONSTRUCTOR] | -False
  ============================================
 */

namespace MultiAPI
{
    #region CLASS | NumberSystem
    /// <summary>
    /// Класс для преобразований между систем счислений
    /// </summary>
    public static class NumberSystem
    {
        #region PRIVATE_METHOD-INT | CharToValue
        private static int CharToValue(char c)
        {
            if (c >= '0' && c <= '9')
                return c - '0';
            if (c >= 'A' && c <= 'F')
                return c - 'A' + 10;
            if (c >= 'a' && c <= 'f')
                return c - 'a' + 10;
            throw new Exceptions.InvalidValue("NumberSystem.CharToValue -> char c", c.ToString());
        }
        #endregion

        #region PRIVATE_METHOD-INT | ValueToChar
        private static char ValueToChar(int Value)
        {
            if (Value >= 0 && Value <= 9)
                return (char)('0' + Value);
            if (Value >= 10 && Value <= 15)
                return (char)('A' + (Value - 10));
            throw new Exceptions.InvalidValue("NumberSystem.ValueToChar -> int Value", Value.ToString());
        }
        #endregion

        #region PRIVATE_METHOD-INT | ToDecimal
        private static int ToDecimal(string Number, int FromBase)
        {
            int result = 0;
            foreach (char c in Number)
            {
                int digit = CharToValue(c);
                if (digit >= FromBase)
                    throw new Exceptions.InvalidValue("NumberSystem.ToDecimal -> (string Number || int FromBase)", $"Number = {Number}; FromBase = {FromBase}");
                result = result * FromBase + digit;
            }
            return result;
        }
        #endregion

        #region PRIVATE_METHOD-INT | FromDecimal
        private static string FromDecimal(int DecimalNumber, int ToBase)
        {
            if (DecimalNumber == 0)
                return "0";

            StringBuilder sb = new StringBuilder();
            int number = DecimalNumber;
            while (number > 0)
            {
                int remainder = number % ToBase;
                sb.Insert(0, ValueToChar(remainder));
                number /= ToBase;
            }
            return sb.ToString();
        }
        #endregion

        #region METHOD-STRING | Convert
        /// <summary>
        /// Преобразовать число из одной системы счисления в другую
        /// </summary>
        /// <param name="Number">Число</param>
        /// <param name="FromBase">Из какой системы счисления конвертируем (2, 8, 10, 16)</param>
        /// <param name="ToBase">В какую систему счисления конвертируем (2, 8, 10, 16)</param>
        /// <returns></returns>
        public static string Convert(string Number, int FromBase, int ToBase)
        {
            int[] Bases = {2, 8, 10, 16};
            if (!Bases.Contains(FromBase) || !Bases.Contains(ToBase)) throw new Exceptions.OutOfBounds("NumberSystem.Convert -> (!Bases.Contaions(FromBase) || !Bases.Contains(ToBase))");
            int decimalValue = ToDecimal(Number, FromBase);
            return FromDecimal(decimalValue, ToBase);
        }
        #endregion
    }
    #endregion
}