/* 
  =================- INFO -===================
 * File:         | Exceptions.cs
 * Class:        | Exceptions
 * Project:      | MultiAPI
 * Author:       | dmitriykotik
 * [OPEN SOURCE] | +True
 * [CONSTRUCTOR] | -False
  ============================================
 */

namespace MultiAPI
{
    #region CLASS | Exceptions
    /// <summary>
    /// Класс исключений MultiAPI
    /// </summary>
    public class Exceptions
    {
        #region CLASS | NullField
        /// <summary>
        /// Исключение нулевого поля
        /// </summary>
        public class NullField : Exception
        {
            /// <summary>
            /// Нулевое поле
            /// </summary>
            public NullField() : base("The value cannot be empty or equal to null.") { }

            /// <summary>
            /// Нулевое поле
            /// </summary>
            /// <param name="Trace">Ручная трассировка</param>
            public NullField(string Trace) : base($"The value cannot be empty or equal to null. Trace: {Trace}.") { }
        }
        #endregion

        #region CLASS | FileNotExists
        /// <summary>
        /// Исключение несуществующего файла
        /// </summary>
        public class FileNotExists : Exception
        {
            /// <summary>
            /// Файл не существует
            /// </summary>
            public FileNotExists() : base("The specified file does not exist.") { }

            /// <summary>
            /// Файл не существует
            /// </summary>
            /// <param name="Trace">Ручная трассировка</param>
            public FileNotExists(string Trace) : base($"The specified file does not exist. Trace: {Trace}.") { }

            /// <summary>
            /// Файл не существует
            /// </summary>
            /// <param name="Trace">Ручная трассировка</param>
            /// <param name="File">Файл который не существует</param>
            public FileNotExists(string Trace, string File) : base($"The specified file does not exist. Trace: {Trace}. File: {File}.") { }
        }
        #endregion

        #region CLASS | FileExists
        /// <summary>
        /// Исключение существующего файла
        /// </summary>
        public class FileExists : Exception
        {
            /// <summary>
            /// Файл уже существует
            /// </summary>
            public FileExists() : base("The specified file already exists.") { }

            /// <summary>
            /// Файл уже существует
            /// </summary>
            /// <param name="Trace">Ручная трассировка</param>
            public FileExists(string Trace) : base($"The specified file already exists. Trace: {Trace}.") { }

            /// <summary>
            /// Файл уже существует
            /// </summary>
            /// <param name="Trace">Ручная трассировка</param>
            /// <param name="File">Файл который уже существует</param>
            public FileExists(string Trace, string File) : base($"The specified file already exists. Trace: {Trace}. File: {File}.") { }
        }
        #endregion

        #region CLASS | DirectoryNotExists
        /// <summary>
        /// Исключение несуществующей директории
        /// </summary>
        public class DirectoryNotExists : Exception
        {
            /// <summary>
            /// Директория не существует
            /// </summary>
            public DirectoryNotExists() : base("The specified directory does not exist.") { }

            /// <summary>
            /// Директория не существует
            /// </summary>
            /// <param name="Trace">Ручная трассировка</param>
            public DirectoryNotExists(string Trace) : base($"The specified directory does not exist. Trace: {Trace}.") { }

            /// <summary>
            /// Директория не существует
            /// </summary>
            /// <param name="Trace">Ручная трассировка</param>
            /// <param name="Directory">Директория которая не существует</param>
            public DirectoryNotExists(string Trace, string Directory) : base($"The specified directory does not exist. Trace: {Trace}. File: {Directory}.") { }
        }
        #endregion

        #region CLASS | DirectoryExists
        /// <summary>
        /// Исключение существующей директории
        /// </summary>
        public class DirectoryExists : Exception
        {
            /// <summary>
            /// Директория уже существует
            /// </summary>
            public DirectoryExists() : base("The specified directory already exists.") { }

            /// <summary>
            /// Директория уже существует
            /// </summary>
            /// <param name="Trace">Ручная трассировка</param>
            public DirectoryExists(string Trace) : base($"The specified directory already exists. Trace: {Trace}.") { }

            /// <summary>
            /// Директория уже существует
            /// </summary>
            /// <param name="Trace">Ручная трассировка</param>
            /// <param name="Directory">Директория которая уже существует</param>
            public DirectoryExists(string Trace, string Directory) : base($"The specified directory already exists. Trace: {Trace}. Directory: {Directory}.") { }
        }
        #endregion

        #region CLASS | NoInternetConnection
        /// <summary>
        /// Исключение отсутствия интернета
        /// </summary>
        public class NoInternetConnection : Exception
        {
            /// <summary>
            /// Нет подключения к интернету
            /// </summary>
            public NoInternetConnection() : base("No internet connection. Please check your internet connection.") { }

            /// <summary>
            /// Нет подключения к интернету
            /// </summary>
            /// <param name="Trace">Ручная трассировка</param>
            public NoInternetConnection(string Trace) : base($"No internet connection. Please check your internet connection. Trace: {Trace}.") { }
        }
        #endregion

        #region CLASS | OutOfBounds
        /// <summary>
        /// Исключение выхода за пределы границ
        /// </summary>
        public class OutOfBounds : Exception
        {
            /// <summary>
            /// Выход за пределы границ
            /// </summary>
            public OutOfBounds() : base("Going beyond the established boundaries.") { }

            /// <summary>
            /// Выход за пределы границ
            /// </summary>
            /// <param name="Trace">Ручная трассировка</param>
            public OutOfBounds(string Trace) : base($"Going beyond the established boundaries. Trace: {Trace}.") { }
        }
        #endregion

        #region CLASS | OSNotSupported
        /// <summary>
        /// Исключение неподдерживаемой операционной системы
        /// </summary>
        public class OSNotSupported : Exception
        {
            /// <summary>
            /// Операционная система не поддерживается
            /// </summary>
            public OSNotSupported() : base("The method used does not support the current operating system.") { }

            /// <summary>
            /// Операционная система не поддерживается
            /// </summary>
            /// <param name="Trace">Ручная трассировка</param>
            public OSNotSupported(string Trace) : base($"The method used does not support the current operating system. Trace: {Trace}.") { }

            /// <summary>
            /// Операционная система не поддерживается
            /// </summary>
            /// <param name="Trace">Ручная трассировка</param>
            /// <param name="SupportedOS">Поддерживаемые операционные системы</param>
            public OSNotSupported(string Trace, OS.OSTypes[] SupportedOS) : base($"The method used does not support the current operating system. Trace: {Trace}. Supported OS: {string.Join(", ", SupportedOS)}.") { }
        }
        #endregion

        #region CLASS | InvalidValue
        /// <summary>
        /// Недопустимое значение
        /// </summary>
        public class InvalidValue : Exception
        {
            /// <summary>
            /// Недопустимое значение
            /// </summary>
            public InvalidValue() : base("An invalid value is specified.") { }

            /// <summary>
            /// Недопустимое значение
            /// </summary>
            /// <param name="Trace">Ручная трассировка</param>
            public InvalidValue(string Trace) : base($"An invalid value is specified. Trace: {Trace}.") { }

            /// <summary>
            /// Недопустимое значение
            /// </summary>
            /// <param name="Trace">Ручная трассировка</param>
            /// <param name="Value">Значение</param>
            public InvalidValue(string Trace, string Value) : base($"An invalid value is specified. Trace: {Trace}. Value: {Value}.") { }
        }
        #endregion
    }
    #endregion
}
