﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

/* 
  =================- INFO -===================
 * File:         | RegEdit.cs
 * Class:        | RegEdit
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

    #region CLASS | RegEdit
    /// <summary>
    /// Действия с реестром
    /// </summary>
    public static class RegEdit
    {

        #region METHOD-VOID | create
        /// <summary>
        /// Создание под-ключа из корневого ключа
        /// </summary>
        /// <param name="key">Ссылка на корневой ключ с помощью "Registry" (Обязательно импортируйте библиотеку "Microsoft.Win32" (Примерное значение: Registry.LocalMachine) )</param>
        /// <param name="keyName">Имя под-ключа для его создания</param>
        public static void create(RegistryKey key, string keyName)
        {
            key.CreateSubKey(keyName);
            key.Close();
        }
        #endregion

        #region METHOD-VOID | delete
        /// <summary>
        /// Удаление под-ключа из корневого ключа
        /// </summary>
        /// <param name="key">Ссылка на корневой ключ с помощью "Registry" (Обязательно импортируйте библиотеку "Microsoft.Win32" (Примерное значение: Registry.LocalMachine) )</param>
        /// <param name="keyName">Имя под-ключа для его удаления</param>
        public static void delete(RegistryKey key, string keyName)
        {
            key.DeleteSubKeyTree(keyName);
            key.Close();
        }
        #endregion

        #region METHOD-VOID | createVariable
        /// <summary>
        /// Создание переменной внутри под-ключа
        /// </summary>
        /// <param name="key">Ссылка на корневой ключ с помощью "Registry" (Обязательно импортируйте библиотеку "Microsoft.Win32" (Примерное значение: Registry.LocalMachine) )</param>
        /// <param name="keyName">Имя под-ключа</param>
        /// <param name="varName">Название переменной для её создания</param>
        /// <param name="varValue">Значение переменной</param>
        public static void createVariable(RegistryKey key, string keyName, string varName, object varValue)
        {
            RegistryKey key2 = key.OpenSubKey(keyName, true);
            key2.SetValue(varName, varValue);
            key.Close();
            key2.Close();
        }
        #endregion

        #region METHOD-OBJECT | getValue
        /// <summary>
        /// Получение значения из переменной внутри под-ключа
        /// </summary>
        /// <param name="key">Ссылка на корневой ключ с помощью "Registry" (Обязательно импортируйте библиотеку "Microsoft.Win32" (Примерное значение: Registry.LocalMachine) )</param>
        /// <param name="keyName">Имя под-ключа</param>
        /// <param name="varName">Название переменной</param>
        /// <returns>Значение переменной varName в формате object</returns>
        public static object getValue(RegistryKey key, string keyName, string varName)
        {
            RegistryKey key2 = key.OpenSubKey(keyName);
            object value = key2.GetValue(varName);
            key.Close();
            key2.Close();
            return value;
        }
        #endregion

        #region METHOD-VOID | deleteVariable
        /// <summary>
        /// Удаление переменной внутри под-ключа
        /// </summary>
        /// <param name="key">Ссылка на корневой ключ с помощью "Registry" (Обязательно импортируйте библиотеку "Microsoft.Win32" (Примерное значение: Registry.LocalMachine) )</param>
        /// <param name="keyName">Имя под-ключа</param>
        /// <param name="varName">Название переменной для её удаления</param>
        public static void deleteVariable(RegistryKey key, string keyName, string varName)
        {
            RegistryKey key2 = key.OpenSubKey(keyName, true);
            key2.DeleteValue(varName);
            key.Close();
            key2.Close();
        }
        #endregion

        #region METHOD-VOID | editVariable
        /// <summary>
        /// Редактирование переменной внутри под-ключа
        /// </summary>
        /// <param name="key">Ссылка на корневой ключ с помощью "Registry" (Обязательно импортируйте библиотеку "Microsoft.Win32" (Примерное значение: Registry.LocalMachine) )</param>
        /// <param name="keyName">Имя под-ключа</param>
        /// <param name="varName">Название переменной</param>
        /// <param name="varValue">Новое значение переменной</param>
        public static void editVariable(RegistryKey key, string keyName, string varName, object varValue)
        {
            RegistryKey key2 = key.OpenSubKey(keyName, true);
            key2.SetValue(varName, varValue);
            key.Close();
            key2.Close();
        }
        #endregion

        #region METHOD-BOOL | existsVariable
        /// <summary>
        /// Проверка существования переменной внутри под-ключа (Проверяет наличие значения)
        /// </summary>
        /// <param name="key">Ссылка на корневой ключ с помощью "Registry" (Обязательно импортируйте библиотеку "Microsoft.Win32" (Примерное значение: Registry.LocalMachine) )</param>
        /// <param name="keyName">Имя под-ключа</param>
        /// <param name="varName">Название переменной для проверки</param>
        /// <returns>true - в случае если переменная существует, false - в случае если переменная НЕ существует</returns>
        public static bool existsVariable(RegistryKey key, string keyName, string varName)
        {
            if (key.OpenSubKey(keyName) == null) return false;
            else return true;
        }
        #endregion

    }
    #endregion

}
