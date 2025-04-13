/* 
  =================- INFO -===================
 * File:         | IDirectoryException.cs
 * Interface:    | IDirectoryException
 * Project:      | MultiAPI
 * Author:       | dmitriykotik
 * [OPEN SOURCE] | +True
 * [CONSTRUCTOR] | -False
  ============================================
 */

namespace MultiAPI
{
    #region INTERFACE | IDirectoryException
    /// <summary>
    /// Интерфейс для обработки исключения, если директория уже существует
    /// </summary>
    public interface IDirectoryException
    {
        #region METHOD-VOID | DirectoryExists
        /// <summary>
        /// Метод, вызываемый при возникновении исключения
        /// <param name="Directory">Директория</param>
        /// </summary>
        void DirectoryExists(string Directory);
        #endregion
    }
    #endregion
}
