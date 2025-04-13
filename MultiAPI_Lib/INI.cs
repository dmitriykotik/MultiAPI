using IniParser;
using IniParser.Model;

/* 
  =================- INFO -===================
 * File:         | INI.cs
 * Class:        | INI
 * Project:      | MultiAPI
 * Author:       | dmitriykotik
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

        #region METHOD-STRING | _IniFile
        private string _IniFile;
        #endregion

        #region METHOD-INI | INI
        /// <summary>
        /// Конструктор для INI файла ( INI nameVar = new INI("C:\\Path\\To\\Ini_File.ini") )
        /// </summary>
        /// <param name="IniFile">Полный путь до INI файла</param>
        /// <exception cref="Exceptions.NullField">Нулевое поле</exception>
        public INI(string IniFile)
        {
            if (string.IsNullOrEmpty(IniFile)) throw new Exceptions.NullField("INI -> string IniFile");
            if (!FileManager.File.Exists(IniFile)) FileManager.File.Create(IniFile);
            _IniFile = IniFile;
        }
        #endregion

        #region METHOD-STRING | GetValue
        /// <summary>
        /// Получение значения из переменной в секции
        /// </summary>
        /// <param name="Section">Секция</param>
        /// <param name="Variable">Переменная в секции</param>
        /// <returns>Значение из переменной в INI-файле</returns>
        /// <exception cref="Exceptions.NullField">Нулевое поле</exception>
        public string GetValue(string Section, string Variable)
        {
            if (string.IsNullOrEmpty(Section) || string.IsNullOrEmpty(Variable)) throw new Exceptions.NullField("INI.GetValue -> (string Section || string Variable)");
            FileIniDataParser Parser = new FileIniDataParser();
            IniData data = Parser.ReadFile(_IniFile);
            return data[Section][Variable];
        }
        #endregion

        #region METHOD-STRING | SetValue
        /// <summary>
        /// Установка значения в переменную из секции
        /// </summary>
        /// <param name="Section">Секция</param>
        /// <param name="Variable">Переменная в секции</param>
        /// <param name="Content">Новое содержимое</param>
        /// <exception cref="Exceptions.NullField">Нулевое поле</exception>
        public void SetValue(string Section, string Variable, string Content)
        {
            if (string.IsNullOrEmpty(Section) || string.IsNullOrEmpty(Variable) || string.IsNullOrEmpty(Content)) throw new Exceptions.NullField("INI.SetValue -> (string Section || string Variable || string Content)");
            FileIniDataParser Parser = new FileIniDataParser();
            IniData data = Parser.ReadFile(_IniFile);
            data[Section][Variable] = Content;
            Parser.WriteFile(_IniFile, data);
        }
        #endregion

        #region METHOD-BOOL | ExistVariable
        /// <summary>
        /// Существует переменная в секции?
        /// </summary>
        /// <param name="Section">Секция</param>
        /// <param name="Variable">Переменная в секции</param>
        /// <returns>true - если переменная существует, false - если переменная НЕ существует</returns>
        /// <exception cref="Exceptions.NullField">Нулевое поле</exception>
        public bool ExistVariable(string Section, string Variable)
        {
            if (string.IsNullOrEmpty(Section) || string.IsNullOrEmpty(Variable)) throw new Exceptions.NullField("INI.ExistsVariable -> (string Section || string Variable)");
            FileIniDataParser Parser = new FileIniDataParser();
            IniData data = Parser.ReadFile(_IniFile);
            return data[Section].ContainsKey(Variable);
        }
        #endregion

        #region METHOD-VOID | DeleteVariable
        /// <summary>
        /// Удаление переменной из секции
        /// </summary>
        /// <param name="Section">Секция</param>
        /// <param name="Variable">Переменная в секции</param>
        /// <exception cref="Exceptions.NullField">Нулевое поле</exception>
        public void DeleteVariable(string Section, string Variable)
        {
            if (string.IsNullOrEmpty(Section) || string.IsNullOrEmpty(Variable)) throw new Exceptions.NullField("INI.DeleteVariable -> (string Section || string Variable)");
            FileIniDataParser Parser = new FileIniDataParser();
            IniData data = Parser.ReadFile(_IniFile);
            data[Section].RemoveKey(Variable);
            Parser.WriteFile(_IniFile, data);
        }
        #endregion

        #region METHOD-VOID | DeleteAllVariables
        /// <summary>
        /// Удаление всех переменных из секции
        /// </summary>
        /// <param name="Section">Секция</param>
        /// <exception cref="Exceptions.NullField">Нулевое поле</exception>
        public void DeleteAllVariables(string Section)
        {
            if (string.IsNullOrEmpty(Section)) throw new Exceptions.NullField("INI.DeleteAllVariables -> string Section");
            FileIniDataParser Parser = new FileIniDataParser();
            IniData data = Parser.ReadFile(_IniFile);
            data[Section].RemoveAllKeys();
            Parser.WriteFile(_IniFile, data);
        }
        #endregion

    }
    #endregion
}
