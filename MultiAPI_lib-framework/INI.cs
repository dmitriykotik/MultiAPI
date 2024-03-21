using System;
using System.IO;
using IniParser;
using IniParser.Model;


/* 
  =================- INFO -===================
 * File:         | INI.cs
 * Class:        | INI
 * Project:      | MultiAPI
 * Author:       | Plufik
 * Version:      | 0.0.0.0
 * VerType:      | major_version.minor_version.patch_version.builds
 * Main file:    | Main.cs
 * [OPEN SOURCE] | +True
 * [CONSTRUCTOR] | +True
  ============================================
 */

namespace MultiAPI
{
    #region CLASS | INI
    /// <summary>
    /// Действие с INI файлами
    /// </summary>
    public class INI
    {

        #region METHOD-STRING | _iniFile
        private string _iniFile;
        #endregion

        #region METHOD-INI | INI
        /// <summary>
        /// Конструктор для INI файла ( INI nameVar = new INI("C:\\Path\\To\\Ini_File.ini") )
        /// </summary>
        /// <param name="iniFile">Полный путь до INI файла</param>
        public INI(string iniFile)
        {
            if (string.IsNullOrEmpty(iniFile)) throw new Exception("0x00003");
            if (!File.Exists(iniFile)) File.Create(iniFile).Close();
            _iniFile = iniFile;
        }
        #endregion

        #region METHOD-STRING | getValue
        /// <summary>
        /// Получение значения из переменной в секции
        /// </summary>
        /// <param name="section">Секция</param>
        /// <param name="variable">Переменная в секции</param>
        /// <returns>Значение из переменной в INI-файле</returns>
        public string getValue(string section, string variable)
        {
            if (string.IsNullOrEmpty(section) || string.IsNullOrEmpty(variable)) throw new Exception("0x00003");
            FileIniDataParser parser = new FileIniDataParser();
            IniData data = parser.ReadFile(_iniFile);
            return data[section][variable];
        }
        #endregion

        #region METHOD-STRING | setValue
        /// <summary>
        /// Установка значения в переменную из секции
        /// </summary>
        /// <param name="section">Секция</param>
        /// <param name="variable">Переменная в секции</param>
        /// <param name="text">Новый текст в переменной</param>
        public void setValue(string section, string variable, string text)
        {
            if (string.IsNullOrEmpty(section) || string.IsNullOrEmpty(variable) || string.IsNullOrEmpty(text)) throw new Exception("0x00003");
            FileIniDataParser parser = new FileIniDataParser();
            IniData data = parser.ReadFile(_iniFile);
            data[section][variable] = text;
            parser.WriteFile(_iniFile, data);
        }
        #endregion

        #region METHOD-BOOL | existVariable
        /// <summary>
        /// Существует переменная в секции?
        /// </summary>
        /// <param name="section">Секция</param>
        /// <param name="variable">Переменная в секции</param>
        /// <returns>true - если переменная существует, false - если переменная НЕ существует</returns>
        public bool existVariable(string section, string variable)
        {
            if (string.IsNullOrEmpty(section) || string.IsNullOrEmpty(variable)) throw new Exception("0x00003");
            FileIniDataParser parser = new FileIniDataParser();
            IniData data = parser.ReadFile(_iniFile);
            return data[section].ContainsKey(variable);
        }
        #endregion

        #region METHOD-VOID | deleteVariable
        /// <summary>
        /// Удаление переменной из секции
        /// </summary>
        /// <param name="section">Секция</param>
        /// <param name="variable">Переменная в секции</param>
        public void deleteVariable(string section, string variable)
        {
            if (string.IsNullOrEmpty(section) || string.IsNullOrEmpty(variable)) throw new Exception("0x00003");
            FileIniDataParser parser = new FileIniDataParser();
            IniData data = parser.ReadFile(_iniFile);
            data[section].RemoveKey(variable);
            parser.WriteFile(_iniFile, data);
        }
        #endregion

        #region METHOD-VOID | deleteAllVariables
        /// <summary>
        /// Удаление всех переменных из секции
        /// </summary>
        /// <param name="section">Секция</param>
        public void deleteAllVariables(string section)
        {
            if (string.IsNullOrEmpty(section)) throw new Exception("0x00003");
            FileIniDataParser parser = new FileIniDataParser();
            IniData data = parser.ReadFile(_iniFile);
            data[section].RemoveAllKeys();
            parser.WriteFile(_iniFile, data);
        }
        #endregion

    }
    #endregion
}
