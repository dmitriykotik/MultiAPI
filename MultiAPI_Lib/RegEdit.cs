using Microsoft.Win32;

/* 
  =================- INFO -===================
 * File:         | RegEdit.cs
 * Class:        | RegEdit
 * Project:      | MultiAPI
 * Author:       | dmitriykotik
 * [OPEN SOURCE] | +True
 * [CONSTRUCTOR] | -False
  ============================================
 */

namespace MultiAPI
{
    #region CLASS | RegEdit
    #pragma warning disable CA1416
    /// <summary>
    /// Действия с реестром
    /// </summary>
    public static class RegEdit
    {

        #region METHOD-VOID | Create
        /// <summary>
        /// Создание под-ключа из корневого ключа
        /// </summary>
        /// <param name="Key">Ссылка на корневой ключ с помощью "Registry" (Обязательно импортируйте библиотеку "Microsoft.Win32" (Примерное значение: Registry.LocalMachine) )</param>
        /// <param name="KeyName">Имя под-ключа для его создания</param>
        /// <exception cref="Exceptions.OSNotSupported">Операционная система не поддерживается</exception>
        /// <exception cref="Exceptions.NullField">Нулевое поле</exception>
        public static void Create(RegistryKey Key, string KeyName)
        {
            if (!OS.isSupported([OS.OSTypes.Windows])) throw new Exceptions.OSNotSupported("RegEdit.Create -> OS.isSupported", [OS.OSTypes.Windows]);
            if (string.IsNullOrEmpty(KeyName)) throw new Exceptions.NullField("RegEdit.Create -> string KeyName");
            Key.CreateSubKey(KeyName);
            Key.Close();
        }
        #endregion

        #region METHOD-VOID | Delete
        /// <summary>
        /// Удаление под-ключа из корневого ключа
        /// </summary>
        /// <param name="Key">Ссылка на корневой ключ с помощью "Registry" (Обязательно импортируйте библиотеку "Microsoft.Win32" (Примерное значение: Registry.LocalMachine) )</param>
        /// <param name="KeyName">Имя под-ключа для его удаления</param>
        /// <exception cref="Exceptions.OSNotSupported">Операционная система не поддерживается</exception>
        /// <exception cref="Exceptions.NullField">Нулевое поле</exception>
        public static void Delete(RegistryKey Key, string KeyName)
        {
            if (!OS.isSupported([OS.OSTypes.Windows])) throw new Exceptions.OSNotSupported("RegEdit.Delete -> OS.isSupported", [OS.OSTypes.Windows]);
            if (string.IsNullOrEmpty(KeyName)) throw new Exceptions.NullField();
            Key.DeleteSubKeyTree(KeyName);
            Key.Close();
        }
        #endregion

        #region METHOD-VOID | CreateVariable
        /// <summary>
        /// Создание переменной внутри под-ключа
        /// </summary>
        /// <param name="Key">Ссылка на корневой ключ с помощью "Registry" (Обязательно импортируйте библиотеку "Microsoft.Win32" (Примерное значение: Registry.LocalMachine) )</param>
        /// <param name="KeyName">Имя под-ключа</param>
        /// <param name="VarName">Название переменной для её создания</param>
        /// <param name="Value">Значение переменной</param>
        /// <exception cref="Exceptions.OSNotSupported">Операционная система не поддерживается</exception>
        /// <exception cref="Exceptions.NullField">Нулевое поле</exception>
        public static void CreateVariable(RegistryKey Key, string KeyName, string VarName, object Value)
        {
            if (!OS.isSupported([OS.OSTypes.Windows])) throw new Exceptions.OSNotSupported("RegEdit.CreateVariable -> OS.isSupported", [OS.OSTypes.Windows]);
            if (string.IsNullOrEmpty(KeyName) || string.IsNullOrEmpty(VarName) || Value == null) throw new Exceptions.NullField("RegEdit.CreateVariable -> (string KeyName || string VarName || object Value)");
            RegistryKey? Key2 = Key.OpenSubKey(KeyName, true);
            Key2?.SetValue(VarName, Value);
            Key.Close();
            Key2?.Close();
        }
        #endregion

        #region METHOD-OBJECT | GetValue
        /// <summary>
        /// Получение значения из переменной внутри под-ключа
        /// </summary>
        /// <param name="Key">Ссылка на корневой ключ с помощью "Registry" (Обязательно импортируйте библиотеку "Microsoft.Win32" (Примерное значение: Registry.LocalMachine) )</param>
        /// <param name="KeyName">Имя под-ключа</param>
        /// <param name="VarName">Название переменной</param>
        /// <returns>Значение переменной varName в формате object</returns>
        /// <exception cref="Exceptions.OSNotSupported">Операционная система не поддерживается</exception>
        /// <exception cref="Exceptions.NullField">Нулевое поле</exception>
        public static object? GetValue(RegistryKey Key, string KeyName, string VarName)
        {
            if (!OS.isSupported([OS.OSTypes.Windows])) throw new Exceptions.OSNotSupported("RegEdit.GetValue -> OS.isSupported", [OS.OSTypes.Windows]);
            if (string.IsNullOrEmpty(KeyName) || string.IsNullOrEmpty(VarName)) throw new Exceptions.NullField("RegEdit.GetValue -> (string KeyName || string VarName)");
            RegistryKey? Key2 = Key.OpenSubKey(KeyName);
            object? Value = Key2?.GetValue(VarName);
            Key.Close();
            Key2?.Close();
            return Value;
        }
        #endregion

        #region METHOD-VOID | DeleteVariable
        /// <summary>
        /// Удаление переменной внутри под-ключа
        /// </summary>
        /// <param name="Key">Ссылка на корневой ключ с помощью "Registry" (Обязательно импортируйте библиотеку "Microsoft.Win32" (Примерное значение: Registry.LocalMachine) )</param>
        /// <param name="KeyName">Имя под-ключа</param>
        /// <param name="VarName">Название переменной для её удаления</param>
        /// <exception cref="Exceptions.OSNotSupported">Операционная система не поддерживается</exception>
        /// <exception cref="Exceptions.NullField">Нулевое поле</exception>
        public static void DeleteVariable(RegistryKey Key, string KeyName, string VarName)
        {
            if (!OS.isSupported([OS.OSTypes.Windows])) throw new Exceptions.OSNotSupported("RegEdit.DeleteVariable -> OS.isSupported", [OS.OSTypes.Windows]);
            if (string.IsNullOrEmpty(KeyName) || string.IsNullOrEmpty(VarName)) throw new Exceptions.NullField("RegEdit.DeleteVariable -> (string KeyName || string VarName)");
            RegistryKey? Key2 = Key.OpenSubKey(KeyName, true);
            Key2?.DeleteValue(VarName);
            Key.Close();
            Key2?.Close();
        }
        #endregion

        #region METHOD-VOID | EditVariable
        /// <summary>
        /// Редактирование переменной внутри под-ключа
        /// </summary>
        /// <param name="Key">Ссылка на корневой ключ с помощью "Registry" (Обязательно импортируйте библиотеку "Microsoft.Win32" (Примерное значение: Registry.LocalMachine) )</param>
        /// <param name="KeyName">Имя под-ключа</param>
        /// <param name="VarName">Название переменной</param>
        /// <param name="Value">Новое значение переменной</param>
        /// <exception cref="Exceptions.OSNotSupported">Операционная система не поддерживается</exception>
        /// <exception cref="Exceptions.NullField">Нулевое поле</exception>
        public static void EditVariable(RegistryKey Key, string KeyName, string VarName, object Value)
        {
            if (!OS.isSupported([OS.OSTypes.Windows])) throw new Exceptions.OSNotSupported("RegEdit.EditVariable -> OS.isSupported", [OS.OSTypes.Windows]);
            if (string.IsNullOrEmpty(KeyName) || string.IsNullOrEmpty(VarName) || Value == null) throw new Exceptions.NullField("RegEdit.EditVariable -> (string KeyName || string VarName || object Value)");
            RegistryKey? Key2 = Key.OpenSubKey(KeyName, true);
            Key2?.SetValue(VarName, Value);
            Key.Close();
            Key2?.Close();
        }
        #endregion

        #region METHOD-BOOL | ExistsVariable
        /// <summary>
        /// Проверка существования переменной внутри под-ключа (Проверяет наличие значения)
        /// </summary>
        /// <param name="Key">Ссылка на корневой ключ с помощью "Registry" (Обязательно импортируйте библиотеку "Microsoft.Win32" (Примерное значение: Registry.LocalMachine) )</param>
        /// <param name="KeyName">Имя под-ключа</param>
        /// <param name="VarName">Название переменной для проверки</param>
        /// <returns>true - в случае если переменная существует, false - в случае если переменная НЕ существует</returns>
        /// <exception cref="Exceptions.OSNotSupported">Операционная система не поддерживается</exception>
        /// <exception cref="Exceptions.NullField">Нулевое поле</exception>
        public static bool ExistsVariable(RegistryKey Key, string KeyName, string VarName)
        {
            if (!OS.isSupported([OS.OSTypes.Windows])) throw new Exceptions.OSNotSupported("RegEdit.ExistsVariable -> OS.isSupported", [OS.OSTypes.Windows]);
            if (string.IsNullOrEmpty(KeyName) || string.IsNullOrEmpty(VarName)) throw new Exceptions.NullField("RegEdit.ExistsVariable -> (string KeyName || string VarName)");
            RegistryKey? Key2 = Key.OpenSubKey(KeyName);
            if (Key2 == null) return false;
            else if (Key2.GetValue(VarName) == null) return false;
            else return true;
        }
        #endregion

    }
    #endregion
}
