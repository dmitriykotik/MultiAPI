/* 
  =================- INFO -===================
 * File:         | IFileException.cs
 * Interface:    | IFileException
 * Project:      | MultiAPI
 * Author:       | dmitriykotik
 * [OPEN SOURCE] | +True
 * [CONSTRUCTOR] | -False
  ============================================
 */

namespace MultiAPI
{
    #region INTERFACE | IFileException
    /// <summary>
    /// Интерфейс для обработки исключения, если файл уже существует
    /// </summary>
    public interface IFileException
    {
        #region METHOD-VOID | FileExists
        /// <summary>
        /// Метод, вызываемый при возникновении исключения
        /// <param name="File">Файл</param>
        /// </summary>
        void FileExists(string File);
        #endregion

        #region METHOD-VOID | FilesExists
        /// <summary>
        /// Метод, вызываемый при возникновении исключения
        /// <param name="Files">Файлы</param>
        /// </summary>
        void FilesExists(string[] Files);
        #endregion
    }
    #endregion
}
