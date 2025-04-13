using System.Text;

/* 
  =================- INFO -===================
 * File:         | FileManager.cs
 * Class:        | FileManager
 * Project:      | MultiAPI
 * Author:       | dmitriykotik
 * [OPEN SOURCE] | +True
 * [CONSTRUCTOR] | +True
  ============================================
 */

namespace MultiAPI
{
    #region CLASS | FileManager
    /// <summary>
    /// Действия с файловой системой
    /// </summary>
    public class FileManager
    {
        #region CLASS | File
        /// <summary>
        /// Класс работы с файлами
        /// </summary>
        public class File
        {
            #region STRING | _File
            private string _File { get; set; }
            #endregion

            #region METHOD-File | File
            /// <summary>
            /// Конструктор класса
            /// </summary>
            /// <param name="File">Файл</param>
            /// <exception cref="Exceptions.NullField">Нулевое поле</exception>
            public File(string File)
            {
                if (string.IsNullOrEmpty(File)) throw new Exceptions.NullField("FileManager.File -> string File");
                if (!Exists(File)) Create(File);
                _File = File;
            }
            #endregion

            #region METHOD-BOOL | Exists
            /// <summary>
            /// Проверка существования файла
            /// </summary>
            /// <param name="File">Файл</param>
            /// <returns>true - Если файл существует, иначе false</returns>
            /// <exception cref="Exceptions.NullField">Нулевое поле</exception>
            public static bool Exists(string File)
            {
                if (string.IsNullOrEmpty(File)) throw new Exceptions.NullField("FileManager.File.Exists -> string File");
                FileInfo fi = new FileInfo(File);
                return fi.Exists;
            }
            #endregion

            #region METHOD-VOID | Create
            /// <summary>
            /// Создание файла
            /// </summary>
            /// <param name="File">Файл</param>
            /// <param name="FCE">Интерфейс обработки ошибки существования файла. По умолчанию ExampleFCE (см. Документацию)</param>
            /// <exception cref="Exceptions.NullField">Нулевое поле</exception>
            public static void Create(string File, IFileException? FCE = null)
            {
                if (string.IsNullOrEmpty(File)) throw new Exceptions.NullField("FileManager.File.Create -> string File");
                if (FCE == null) FCE = new ExampleFCE();

                if (Exists(File)) FCE.FileExists(File);
                else
                {
                    FileInfo fi = new FileInfo(File);
                    fi.Create().Close();
                }
            }
            #endregion

            #region METHOD-VOID | Create
            /// <summary>
            /// Создание файлов
            /// </summary>
            /// <param name="Files">Файлы</param>
            /// <param name="FCE">Интерфейс обработки ошибки существования файла. По умолчанию ExampleFCE (см. Документацию)</param>
            /// <exception cref="Exceptions.NullField">Нулевое поле</exception>
            public static void Create(string[] Files, IFileException? FCE = null)
            {
                if (Files == null) throw new Exceptions.NullField("FileManager.File.Create -> string File");
                if (FCE == null) FCE = new ExampleFCE();

                foreach (string File in Files)
                {
                    if (Exists(File)) FCE.FileExists(File);
                    else
                    {
                        FileInfo fi = new FileInfo(File);
                        fi.Create().Close();
                    }
                }
            }
            #endregion

            #region METHOD-VOID | Delete
            /// <summary>
            /// Удаление файлов
            /// </summary>
            /// <param name="File">Файл</param>
            /// <exception cref="Exceptions.NullField">Нулевое поле</exception>
            /// <exception cref="Exceptions.FileNotExists">Файл не существует</exception>
            public static void Delete(string File)
            {
                if (string.IsNullOrEmpty(File)) throw new Exceptions.NullField("FileManager.File.Delete -> string File");
                if (!Exists(File)) throw new Exceptions.FileNotExists("FileManager.File.Delete -> File", File);

                FileInfo fi = new FileInfo(File);
                fi.Delete();
            }
            #endregion

            #region METHOD-BYTE[] | ReadAllBytes
            /// <summary>
            /// Чтение файла
            /// </summary>
            /// <param name="File">Файл</param>
            /// <returns>Байтовое представление файла</returns>
            /// <exception cref="Exceptions.NullField">Нулевое поле</exception>
            /// <exception cref="Exceptions.FileNotExists">Файл не существует</exception>
            public static byte[] ReadAllBytes(string File)
            {
                if (string.IsNullOrEmpty(File)) throw new Exceptions.NullField("FileManager.File.ReadAllBytes -> string File");
                if (!Exists(File)) throw new Exceptions.FileNotExists("FileManager.File.ReadAllBytes -> File", File);

                FileStream fs = new FileStream(File, FileMode.Open, FileAccess.Read);
                byte[] data = new byte[fs.Length];
                fs.Read(data, 0, data.Length);
                fs.Close();
                return data;
            }
            #endregion

            #region METHOD-BYTE[] | ReadAllBytes
            /// <summary>
            /// Чтение файла
            /// </summary>
            /// <param name="File">Файл</param>
            /// <param name="Offset">Смещение в байтах массива</param>
            /// <returns>Байтовое представление файла</returns>
            /// <exception cref="Exceptions.NullField">Нулевое поле</exception>
            /// <exception cref="Exceptions.FileNotExists">Файл не существует</exception>
            public static byte[] ReadAllBytes(string File, int Offset)
            {
                if (string.IsNullOrEmpty(File)) throw new Exceptions.NullField("FileManager.File.ReadAllBytes -> string File");
                if (!Exists(File)) throw new Exceptions.FileNotExists("FileManager.File.ReadAllBytes -> File", File);

                FileStream fs = new FileStream(File, FileMode.Open, FileAccess.Read);
                byte[] data = new byte[fs.Length];
                fs.Read(data, Offset, data.Length);
                fs.Close();
                return data;
            }
            #endregion

            #region METHOD-STRING | ReadAllText
            /// <summary>
            /// Чтение файла в текстовом виде
            /// </summary>
            /// <param name="File">Файл</param>
            /// <returns>Текстовое представление файла</returns>
            /// <exception cref="Exceptions.NullField">Нулевое поле</exception>
            /// <exception cref="Exceptions.FileNotExists">Файл не существует</exception>
            public static string ReadAllText(string File)
            {
                if (string.IsNullOrEmpty(File)) throw new Exceptions.NullField("FileManager.File.ReadAllText -> string File");
                if (!Exists(File)) throw new Exceptions.FileNotExists("FileManager.File.ReadAllText -> File", File);

                FileStream fs = new FileStream(File, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);
                string data = sr.ReadToEnd();
                sr.Close();
                fs.Close();
                return data;
            }
            #endregion

            #region METHOD-STRING[] | ReadAllLines
            /// <summary>
            /// Чтение файла в текстовом виде
            /// </summary>
            /// <param name="File">Файл</param>
            /// <returns>Массив строк файла</returns>
            /// <exception cref="Exceptions.NullField">Нулевое поле</exception>
            /// <exception cref="Exceptions.FileNotExists">Файл не существует</exception>
            public static string[] ReadAllLines(string File)
            {
                if (string.IsNullOrEmpty(File)) throw new Exceptions.NullField("FileManager.File.ReadAllLines -> string File");
                if (!Exists(File)) throw new Exceptions.FileNotExists("FileManager.File.ReadAllLines -> File", File);

                FileStream fs = new FileStream(File, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);
                string[] data = sr.ReadToEnd().Split('\n');
                sr.Close();
                fs.Close();
                return data;
            }
            #endregion

            #region METHOD-STRING | ReadLine
            /// <summary>
            /// Чтение строки
            /// </summary>
            /// <param name="File">Файл</param>
            /// <param name="Line">Строка</param>
            /// <returns>Текстовое представление строки из файла</returns>
            /// <exception cref="Exceptions.NullField">Нулевое поле</exception>
            /// <exception cref="Exceptions.FileNotExists">Файл не существует</exception>
            public static string ReadLine(string File, int Line)
            {
                if (string.IsNullOrEmpty(File)) throw new Exceptions.NullField("FileManager.File.ReadLine -> string File");
                if (!Exists(File)) throw new Exceptions.FileNotExists("FileManager.File.ReadLine -> File", File);

                FileStream fs = new FileStream(File, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);
                string[] data = sr.ReadToEnd().Split('\n');
                sr.Close();
                fs.Close();
                return data[Line];
            }
            #endregion

            #region METHOD-VOID | WriteAllBytes
            /// <summary>
            /// Запись массива байтов в файл
            /// </summary>
            /// <param name="File">Файл</param>
            /// <param name="Content">Байтовый массив</param>
            /// <exception cref="Exceptions.NullField">Нулевое поле</exception>
            public static void WriteAllBytes(string File, byte[] Content)
            {
                if (string.IsNullOrEmpty(File)) throw new Exceptions.NullField("FileManager.File.WriteAllBytes -> string File");
                if (!Exists(File)) Create(File);

                FileStream fs = new FileStream(File, FileMode.Open, FileAccess.Write);
                fs.Write(Content, 0, Content.Length);
                fs.Close();
            }
            #endregion

            #region METHOD-VOID | WriteAllText
            /// <summary>
            /// Запись всего текста в файл
            /// </summary>
            /// <param name="File">Файл</param>
            /// <param name="Content">Текстовое содержимое</param>
            /// <exception cref="Exceptions.NullField">Нулевое поле</exception>
            public static void WriteAllText(string File, string Content)
            {
                if (string.IsNullOrEmpty(File)) throw new Exceptions.NullField("FileManager.File.WriteAllText -> string File");
                if (!Exists(File)) Create(File);

                FileStream fs = new FileStream(File, FileMode.Open, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.Write(Content);
                sw.Close();
                fs.Close();
            }
            #endregion

            #region METHOD-VOID | WriteAllLines
            /// <summary>
            /// Запись массива строк в файл
            /// </summary>
            /// <param name="File">Файл</param>
            /// <param name="Content">Массив строк</param>
            /// <exception cref="Exceptions.NullField">Нулевое поле</exception>
            public static void WriteAllLines(string File, string[] Content)
            {
                if (string.IsNullOrEmpty(File)) throw new Exceptions.NullField("FileManager.File.WriteAllLines -> string File");
                if (!Exists(File)) Create(File);

                FileStream fs = new FileStream(File, FileMode.Open, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                foreach (string line in Content) sw.WriteLine(line);
                sw.Close();
                fs.Close();
            }
            #endregion

            #region METHOD-VOID | WriteLine
            /// <summary>
            /// Запись строки в файл
            /// </summary>
            /// <param name="File">Файл</param>
            /// <param name="Content">Текстовое содержимое</param>
            /// <param name="Line">Строка</param>
            /// <exception cref="Exceptions.NullField">Нулевое поле</exception>
            public static void WriteLine(string File, string Content, int Line)
            {
                if (string.IsNullOrEmpty(File)) throw new Exceptions.NullField("FileManager.File.WriteLine -> string File");
                if (!Exists(File)) Create(File);

                FileStream fs = new FileStream(File, FileMode.Open, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                string[] data = ReadAllLines(File);
                data[Line] = Content;
                foreach (string line in data) sw.WriteLine(line);
                sw.Close();
                fs.Close();
            }
            #endregion

            #region METHOD-VOID | AppendAllText
            /// <summary>
            /// Добавление текста в файл
            /// </summary>
            /// <param name="File">Файл</param>
            /// <param name="Content">Текстовое содержимое</param>
            /// <exception cref="Exceptions.NullField">Нулевое поле</exception>
            public static void AppendAllText(string File, string Content)
            {
                if (string.IsNullOrEmpty(File)) throw new Exceptions.NullField("FileManager.File.AppendAllText -> string File");
                if (!Exists(File)) Create(File);

                FileStream fs = new FileStream(File, FileMode.Append, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.Write(Content);
                sw.Close();
                fs.Close();
            }
            #endregion

            #region METHOD-VOID | AppendAllLines
            /// <summary>
            /// Добавление массива строк в файл
            /// </summary>
            /// <param name="File">Файл</param>
            /// <param name="Content">Массив строк</param>
            /// <exception cref="Exceptions.NullField">Нулевое поле</exception>
            public static void AppendAllLines(string File, string[] Content)
            {
                if (string.IsNullOrEmpty(File)) throw new Exceptions.NullField("FileManager.File.AppendAllLines -> string File");
                if (!Exists(File)) Create(File);

                FileStream fs = new FileStream(File, FileMode.Append, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                foreach (string line in Content) sw.WriteLine(line);
                sw.Close();
                fs.Close();
            }
            #endregion

            #region METHOD-VOID | AppendLine
            /// <summary>
            /// Добавление строки в файл
            /// </summary>
            /// <param name="File">Файл</param>
            /// <param name="Content">Текстовое содержимое</param>
            /// <exception cref="Exceptions.NullField">Нулевое поле</exception>
            public static void AppendLine(string File, string Content)
            {
                if (string.IsNullOrEmpty(File)) throw new Exceptions.NullField("FileManager.File.AppendLine -> string File");
                if (!Exists(File)) Create(File);

                FileStream fs = new FileStream(File, FileMode.Append, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(Content);
                sw.Close();
                fs.Close();
            }
            #endregion

            #region METHOD-BOOL | ComparisonFiles
            /// <summary>
            /// Сравнение двух файлов
            /// </summary>
            /// <param name="File1">Первый файл</param>
            /// <param name="File2">Второй файл</param>
            /// <param name="Mode">Режим сравнения</param>
            /// <returns>true - Если файлы одинаковые, иначе false</returns>
            /// <exception cref="Exceptions.NullField">Нулевое поле</exception>
            /// <exception cref="Exceptions.FileNotExists">Файл не существует</exception>
            public static bool ComparisonFiles(string File1, string File2, ComparisonMode Mode)
            {
                if (string.IsNullOrEmpty(File1) || string.IsNullOrEmpty(File2)) throw new Exceptions.NullField("FileManager.File.ComparisonFiles -> (string File1 || string File2)");
                if (!Exists(File1) || !Exists(File2)) throw new Exceptions.FileNotExists("FileManager.File.ComparisonFiles -> (File1 || File2)", $"File1 = {File1}; File2 = {File2}");

                if (Mode == ComparisonMode.Byte) return ReadAllBytes(File1) == ReadAllBytes(File2);
                else return GetHash(File1, HashType.SHA256) == GetHash(File2, HashType.SHA256);
            }
            #endregion

            #region METHOD-VOID | MergeFiles
            /// <summary>
            /// Объединение двух файлов
            /// </summary>
            /// <param name="File1">Первый файл</param>
            /// <param name="File2">Второй файл</param>
            /// <param name="OutputFile">Выходной файл</param>
            /// <param name="FCE">Интерфейс обработки ошибки существования файла. По умолчанию ExampleFCE (см. Документацию)</param>
            /// <exception cref="Exceptions.NullField">Нулевое поле</exception>
            /// <exception cref="Exceptions.FileNotExists">Файл не существует</exception>
            public static void MergeFiles(string File1, string File2, string OutputFile, IFileException? FCE = null)
            {
                if (string.IsNullOrEmpty(File1) || string.IsNullOrEmpty(File2) || string.IsNullOrEmpty(OutputFile)) throw new Exceptions.NullField("FileManager.File.MergeFiles -> (string File1 || string File2 || string OutputFile)");
                if (!Exists(File1) || !Exists(File2)) throw new Exceptions.FileNotExists("FileManager.File.MergeFiles -> (File1 || File2)", $"File1 = {File1}; File2 = {File2}");
                if (FCE == null) FCE = new ExampleFCE();
                if (Exists(OutputFile)) FCE.FileExists(OutputFile);

                FileStream fs = new FileStream(OutputFile, FileMode.Create, FileAccess.Write);
                fs.Write(ReadAllBytes(File1), 0, ReadAllBytes(File1).Length);
                fs.Write(ReadAllBytes(File2), 0, ReadAllBytes(File2).Length);
                fs.Close();
            }
            #endregion

            #region METHOD-VOID | CreateBackup
            /// <summary>
            /// Создание резервной копии
            /// </summary>
            /// <param name="File">Файл</param>
            /// <exception cref="Exceptions.NullField">Нулевое поле</exception>
            public static void CreateBackup(string File)
            {
                if (string.IsNullOrEmpty(File)) throw new Exceptions.NullField("FileManager.File.CreateBackup -> string File");

                byte[] content = ReadAllBytes(File);
                WriteAllBytes(File + ".bak", content);
            }
            #endregion

            #region METHOD-ENCODING | EncodingDetermine
            /// <summary>
            /// Определение кодировки
            /// </summary>
            /// <param name="File">Файл</param>
            /// <returns>Кодировка</returns>
            /// <exception cref="Exceptions.NullField">Нулевое поле</exception>
            /// <exception cref="Exceptions.FileNotExists">Файл не существует</exception>
            public static Encoding EncodingDetermine(string File)
            {
                if (string.IsNullOrEmpty(File)) throw new Exceptions.NullField("FileManager.File.EncodingDetermine -> string File");
                if (!Exists(File)) throw new Exceptions.FileNotExists("FileManager.File.EncodingDetermine -> File", File);

                StreamReader reader = new StreamReader(File, Encoding.Default, true);
                reader.Peek();
                return reader.CurrentEncoding;
            }
            #endregion

            #region METHOD-VOID | ConvertEncoding
            /// <summary>
            /// Конвертирование кодировки
            /// </summary>
            /// <param name="File">Файл</param>
            /// <param name="To">Кодировка</param>
            /// <param name="Backup">Создать резервную копию? (По умолчанию: true)</param>
            /// <exception cref="Exceptions.NullField">Нулевое поле</exception>
            /// <exception cref="Exceptions.FileNotExists">Файл не существует</exception>
            public static void ConvertEncoding(string File, Encoding To, bool Backup = true)
            {
                if (string.IsNullOrEmpty(File) || To == null) throw new Exceptions.NullField("FileManager.File.ConvertEncoding -> (string File || Encoding To)");
                if (!Exists(File)) throw new Exceptions.FileNotExists("FileManager.File.ConvertEncoding -> File", File);

                byte[] source = ReadAllBytes(File);
                byte[] converted = Encoding.Convert(EncodingDetermine(File), To, source);
                if (Backup) CreateBackup(File);
                WriteAllBytes(File, converted);
            }
            #endregion

            #region METHOD-STRING | GetHash
            /// <summary>
            /// Получение хэша файла
            /// </summary>
            /// <param name="File">Файл</param>
            /// <param name="Type">Тип получаемого хэша</param>
            /// <returns>Хэш файла в формате текста</returns>
            /// <exception cref="Exceptions.NullField">Нулевое поле</exception>
            /// <exception cref="Exceptions.FileNotExists">Файл не существует</exception>
            public static string GetHash(string File, HashType Type)
            {
                if (string.IsNullOrEmpty(File)) throw new Exceptions.NullField("FileManager.File.GetHash -> string File");
                if (!Exists(File)) throw new Exceptions.FileNotExists("FileManager.File.GetHash -> File", File);

                if (Type == HashType.MD5) return BitConverter.ToString(System.Security.Cryptography.MD5.Create().ComputeHash(ReadAllBytes(File))).Replace("-", "").ToLowerInvariant();
                else if (Type == HashType.SHA1) return BitConverter.ToString(System.Security.Cryptography.SHA1.Create().ComputeHash(ReadAllBytes(File))).Replace("-", "").ToLowerInvariant();
                else return BitConverter.ToString(System.Security.Cryptography.SHA256.Create().ComputeHash(ReadAllBytes(File))).Replace("-", "").ToLowerInvariant();
            }
            #endregion

            #region METHOD-VOID | SplitFile
            /// <summary>
            /// Разделение файла
            /// </summary>
            /// <param name="File">Файл</param>
            /// <param name="PartSize">Размер партий (В байтах)</param>
            /// <exception cref="Exceptions.NullField">Нулевое поле</exception>
            /// <exception cref="Exceptions.FileNotExists">Файл не существует</exception>
            public static void SplitFile(string File, int PartSize)
            {
                if (string.IsNullOrEmpty(File)) throw new Exceptions.NullField("FileManager.File.SplitFile -> string File");
                if (!Exists(File)) throw new Exceptions.FileNotExists("FileManager.File.SplitFile -> File", File);

                byte[] content = ReadAllBytes(File);
                int parts = (int)Math.Ceiling((double)content.Length / PartSize);
                for (int i = 0; i < parts; i++) WriteAllBytes(File + "." + i, content.Skip(PartSize * i).Take(PartSize).ToArray());
            }
            #endregion

            #region METHOD-VOID | MergeFiles
            /// <summary>
            /// Объединение файлов
            /// </summary>
            /// <param name="Files">Файлы</param>
            /// <param name="OutputFile">Выходной файл</param>
            /// <param name="FCE">Интерфейс обработки ошибки существования файла. По умолчанию ExampleFCE (см. Документацию)</param>
            /// <exception cref="Exceptions.NullField">Нулевое поле</exception>
            public static void MergeFiles(string[] Files, string OutputFile, IFileException? FCE = null)
            {
                if (string.IsNullOrEmpty(OutputFile)) throw new Exceptions.NullField("FileManager.File.Create -> string File");
                if (FCE == null) FCE = new ExampleFCE();
                if (Exists(OutputFile)) FCE.FilesExists(Files);

                FileStream fs = new FileStream(OutputFile, FileMode.Create, FileAccess.Write);
                foreach (string file in Files) fs.Write(ReadAllBytes(file), 0, ReadAllBytes(file).Length);
                fs.Close();
            }
            #endregion

            #region METHOD-LONG | GetSize
            /// <summary>
            /// Получение размера файла
            /// </summary>
            /// <returns>Размер файла в байтах</returns>
            /// <exception cref="Exceptions.FileNotExists">Файл не существует</exception>
            public long GetSize()
            {
                if (!Exists(_File)) throw new Exceptions.FileNotExists("FileManager.File.GetSize -> _File", _File);

                FileInfo fi = new FileInfo(_File);
                return fi.Length;
            }
            #endregion

            #region METHOD-DATETIME | GetCreationTime
            /// <summary>
            /// Получить дату создания файла
            /// </summary>
            /// <returns>Дата создания файла</returns>
            /// <exception cref="Exceptions.FileNotExists">Файл не существует</exception>
            public DateTime GetCreationTime()
            {
                if (!Exists(_File)) throw new Exceptions.FileNotExists("FileManager.File.GetCreationTime -> _File", _File);

                FileInfo fi = new FileInfo(_File);
                return fi.CreationTime;
            }
            #endregion

            #region METHOD-DATETIME | GetCreationTimeUTC
            /// <summary>
            /// Получить дату создания файла в UTC
            /// </summary>
            /// <returns>Дата создания файла в UTC</returns>
            /// <exception cref="Exceptions.FileNotExists">Файл не существует</exception>
            public DateTime GetCreationTimeUTC()
            {
                if (!Exists(_File)) throw new Exceptions.FileNotExists("FileManager.File.GetCreationTimeUTC -> _File", _File);

                FileInfo fi = new FileInfo(_File);
                return fi.CreationTimeUtc;
            }
            #endregion

            #region METHOD-DIRECTORYINFO | GetDirectory
            /// <summary>
            /// Получить директорию
            /// </summary>
            /// <returns>Директория</returns>
            /// <exception cref="Exceptions.FileNotExists">Файл не существует</exception>
            public DirectoryInfo? GetDirectory()
            {
                if (!Exists(_File)) throw new Exceptions.FileNotExists("FileManager.File.GetDirectory -> _File", _File);

                FileInfo fi = new FileInfo(_File);
                return fi.Directory;
            }
            #endregion

            #region METHOD-STRING | GetDirectoryName
            /// <summary>
            /// Получить имя директории
            /// </summary>
            /// <returns>Имя директории</returns>
            /// <exception cref="Exceptions.FileNotExists">Файл не существует</exception>
            public string? GetDirectoryName()
            {
                if (!Exists(_File)) throw new Exceptions.FileNotExists("FileManager.File.GetDirectoryName -> _File", _File);

                FileInfo fi = new FileInfo(_File);
                return fi.DirectoryName;
            }
            #endregion

            #region METHOD-STRING | GetExtension
            /// <summary>
            /// Получить расширение файла
            /// </summary>
            /// <returns>Расширение файла</returns>
            /// <exception cref="Exceptions.FileNotExists">Файл не существует</exception>
            public string GetExtension()
            {
                if (!Exists(_File)) throw new Exceptions.FileNotExists("FileManager.File.GetExtension -> _File", _File);

                FileInfo fi = new FileInfo(_File);
                return fi.Extension;
            }
            #endregion

            #region METHOD-STRING | GetFullName
            /// <summary>
            /// Получить полный путь к файлу
            /// </summary>
            /// <returns>Полный путь файла</returns>
            /// <exception cref="Exceptions.FileNotExists">Файл не существует</exception>
            public string GetFullName()
            {
                if (!Exists(_File)) throw new Exceptions.FileNotExists("FileManager.File.GetFullName -> _File", _File);

                FileInfo fi = new FileInfo(_File);
                return fi.FullName;
            }
            #endregion

            #region METHOD-BOOL | GetReadOnly
            /// <summary>
            /// Получить значение Только для чтения
            /// </summary>
            /// <returns>true - Если файл открыт только для чтения, иначе false</returns>
            /// <exception cref="Exceptions.FileNotExists">Файл не существует</exception>
            public bool GetReadOnly()
            {
                if (!Exists(_File)) throw new Exceptions.FileNotExists("FileManager.File.GetReadOnly -> _File", _File);

                FileInfo fi = new FileInfo(_File);
                return fi.IsReadOnly;
            }
            #endregion

            #region METHOD-DATETIME | GetLastAccessTime
            /// <summary>
            /// Получить дату последнего доступа
            /// </summary>
            /// <returns>Дата последнего доступа</returns>
            /// <exception cref="Exceptions.FileNotExists">Файл не существует</exception>
            public DateTime GetLastAccessTime()
            {
                if (!Exists(_File)) throw new Exceptions.FileNotExists("FileManager.File.GetLastAccessTime -> _File", _File);

                FileInfo fi = new FileInfo(_File);
                return fi.LastAccessTime;
            }
            #endregion

            #region METHOD-DATETIME | GetLastAccessTimeUTC
            /// <summary>
            /// Получить дату последнего доступа в UTC
            /// </summary>
            /// <returns>Дата последнего доступа в UTC</returns>
            /// <exception cref="Exceptions.FileNotExists">Файл не существует</exception>
            public DateTime GetLastAccessTimeUTC()
            {
                if (!Exists(_File)) throw new Exceptions.FileNotExists("FileManager.File.GetLastAccessTimeUTC -> _File", _File);

                FileInfo fi = new FileInfo(_File);
                return fi.LastAccessTimeUtc;
            }
            #endregion

            #region METHOD-DATETIME | GetLastWriteTime
            /// <summary>
            /// Получить дату последнего изменения
            /// </summary>
            /// <returns>Дата последнего изменения</returns>
            /// <exception cref="Exceptions.FileNotExists">Файл не существует</exception>
            public DateTime GetLastWriteTime()
            {
                if (!Exists(_File)) throw new Exceptions.FileNotExists("FileManager.File.GetLastWriteTime -> _File", _File);

                FileInfo fi = new FileInfo(_File);
                return fi.LastWriteTime;
            }
            #endregion

            #region METHOD-DATETIME | GetLastWriteTimeUTC
            /// <summary>
            /// Получить дату последнего изменения в UTC
            /// </summary>
            /// <returns>Дата последнего изменения в UTC</returns>
            /// <exception cref="Exceptions.FileNotExists">Файл не существует</exception>
            public DateTime GetLastWriteTimeUTC()
            {
                if (!Exists(_File)) throw new Exceptions.FileNotExists("FileManager.File.GetLastWriteTimeUTC -> _File", _File);

                FileInfo fi = new FileInfo(_File);
                return fi.LastWriteTimeUtc;
            }
            #endregion

            #region METHOD-STRING | GetName
            /// <summary>
            /// Получить имя файла
            /// </summary>
            /// <returns>Имя файла</returns>
            /// <exception cref="Exceptions.FileNotExists">Файл не существует</exception>
            public string GetName()
            {
                if (!Exists(_File)) throw new Exceptions.FileNotExists("FileManager.File.GetName -> _File", _File);

                FileInfo fi = new FileInfo(_File);
                return fi.Name;
            }
            #endregion

            #region METHOD-FILEATTRIBUTES | GetAttributes
            /// <summary>
            /// Получить атрибуты файла
            /// </summary>
            /// <returns>Атрибуты файла</returns>
            /// <exception cref="Exceptions.FileNotExists">Файл не существует</exception>
            public FileAttributes GetAttributes()
            {
                if (!Exists(_File)) throw new Exceptions.FileNotExists("FileManager.File.GetAttributes -> _File", _File);

                FileInfo fi = new FileInfo(_File);
                return fi.Attributes;
            }
            #endregion

            #region METHOD-VOID | EditCreationTime
            /// <summary>
            /// Изменить дату создания
            /// </summary>
            /// <param name="CreationTime">Новая дата создания (Мин. значение: 1700)</param>
            /// <exception cref="Exceptions.FileNotExists">Файл не существует</exception>
            /// <exception cref="Exceptions.OutOfBounds">Выход за границы</exception>
            public void EditCreationTime(DateTime CreationTime)
            {
                if (!Exists(_File)) throw new Exceptions.FileNotExists("FileManager.File.EditCreationTime -> _File", _File);
                if (CreationTime.Year < 1700) throw new Exceptions.OutOfBounds("FileManager.File.EditCreationTime -> CreationTime.Year < 1700");

                FileInfo fi = new FileInfo(_File);
                fi.CreationTime = CreationTime;
            }
            #endregion

            #region METHOD-VOID | EditLastAccessTime
            /// <summary>
            /// Изменить дату последнего доступа
            /// </summary>
            /// <param name="LastAccessTime">Новая дата последнего доступа (Мин. значение: 1700)</param>
            /// <exception cref="Exceptions.FileNotExists">Файл не существует</exception>
            /// <exception cref="Exceptions.OutOfBounds">Выход за границы</exception>
            public void EditLastAccessTime(DateTime LastAccessTime)
            {
                if (!Exists(_File)) throw new Exceptions.FileNotExists("FileManager.File.EditLastAccessTime -> _File", _File);
                if (LastAccessTime.Year < 1700) throw new Exceptions.OutOfBounds("FileManager.File.LastAccessTime -> LastAccessTime.Year < 1700");

                FileInfo fi = new FileInfo(_File);
                fi.LastAccessTime = LastAccessTime;
            }
            #endregion

            #region METHOD-VOID | EditLastWriteTime
            /// <summary>
            /// Изменить дату последнего изменения
            /// </summary>
            /// <param name="LastWriteTime">Новая дата последнего изменения (Мин. значение: 1700)</param>
            /// <exception cref="Exceptions.FileNotExists">Файл не существует</exception>
            /// <exception cref="Exceptions.OutOfBounds">Выход за границы</exception>
            public void EditLastWriteTime(DateTime LastWriteTime)
            {
                if (!Exists(_File)) throw new Exceptions.FileNotExists("FileManager.File.EditLastWriteTime -> _File", _File);
                if (LastWriteTime.Year < 1700) throw new Exceptions.OutOfBounds("FileManager.File.LastWriteTime -> LastWriteTime.Year < 1700");

                FileInfo fi = new FileInfo(_File);
                fi.LastWriteTime = LastWriteTime;
            }
            #endregion

            #region METHOD-VOID | EditLength
            /// <summary>
            /// Изменить размер файла
            /// </summary>
            /// <param name="Length">Новый размер (Мин. значение: 0)</param>
            /// <exception cref="Exceptions.FileNotExists">Файл не существует</exception>
            /// <exception cref="Exceptions.OutOfBounds">Выход за границы</exception>
            public void EditLength(long Length)
            {
                if (!Exists(_File)) throw new Exceptions.FileNotExists("FileManager.File.EditLenght -> _File", _File);
                if (Length < 0) throw new Exceptions.OutOfBounds("FileManager.File.Length -> Length < 0");

                FileStream fs = new FileStream(_File, FileMode.Open, FileAccess.Write);
                fs.SetLength(Length);
                fs.Close();
            }
            #endregion

            #region ENUM | HashType
            /// <summary>
            /// Тип хэша
            /// </summary>
            public enum HashType
            {
                /// <summary>
                /// MD5
                /// </summary>
                MD5,
                /// <summary>
                /// SHA1
                /// </summary>
                SHA1,
                /// <summary>
                /// SHA256
                /// </summary>
                SHA256
            }
            #endregion

            #region ENUM | ComparisonMode
            /// <summary>
            /// Метод сравнения
            /// </summary>
            public enum ComparisonMode
            {
                /// <summary>
                /// Байтовый
                /// </summary>
                Byte,
                /// <summary>
                /// По хэшу
                /// </summary>
                Hash
            }
            #endregion

            #region CLASS | ExampleFCE
            internal class ExampleFCE : IFileException
            {
                public void FileExists(string File)
                {
                    throw new Exceptions.FileExists("FileManager.File.* -> ?File", File);
                }

                public void FilesExists(string[] Files){
                    throw new Exceptions.FileExists("FileManager.File.* -> ?Files", string.Join("; ", Files));
                }
            }
            #endregion
        }
        #endregion

        #region CLASS | Directory
        /// <summary>
        /// Класс директорий
        /// </summary>
        public class Directory
        {
            #region STRING | _Directory
            private string _Directory;
            #endregion

            #region METHOD-DIRECTORY | Directory
            /// <summary>
            /// Конструктор класса
            /// </summary>
            /// <param name="Directory">Директория</param>
            /// <exception cref="Exceptions.NullField">Нулевое поле</exception>
            public Directory(string Directory)
            {
                if (string.IsNullOrEmpty(Directory)) throw new Exceptions.NullField("FileManager.Directory -> string Directory");
                if (Exists(Directory)) Create(Directory);
                _Directory = Directory;
            }
            #endregion

            #region METHOD-BOOL | Exists
            /// <summary>
            /// Проверить существует ли директория
            /// </summary>
            /// <param name="Directory">Директория</param>
            /// <returns>true - Если директория существует, иначе false</returns>
            /// <exception cref="Exceptions.NullField">Нулевое поле</exception>
            public static bool Exists(string Directory)
            {
                if (string.IsNullOrEmpty(Directory)) throw new Exceptions.NullField("FileManager.Directory.Exists -> string Directory");
                DirectoryInfo di = new DirectoryInfo(Directory);
                return di.Exists;
            }
            #endregion

            #region METHOD-VOID | Create
            /// <summary>
            /// Создать директорию
            /// </summary>
            /// <param name="Directory">Директория</param>
            /// <param name="DCE">Интерфейс обработки ошибки существования директории. По умолчанию ExampleDCE (см. Документацию)</param>
            /// <exception cref="Exceptions.NullField">Нулевое поле</exception>
            public static void Create(string Directory, IDirectoryException? DCE = null)
            {
                if (string.IsNullOrEmpty(Directory)) throw new Exceptions.NullField("FileManager.Directory.Create -> string Directory");
                if (DCE == null) DCE = new ExampleDCE();
                if (Exists(Directory)) DCE.DirectoryExists(Directory);

                DirectoryInfo di = new DirectoryInfo(Directory);
                di.Create();
            }
            #endregion

            #region METHOD-VOID | Delete
            /// <summary>
            /// Удалить директорию
            /// </summary>
            /// <param name="Directory">Директория</param>
            /// <param name="Recursive">Удалить рекурсивно? По умолчанию: false</param>
            /// <exception cref="Exceptions.NullField">Нулевое поле</exception>
            /// <exception cref="Exceptions.DirectoryNotExists">Директория не существует</exception>
            public static void Delete(string Directory, bool Recursive = false)
            {
                if (string.IsNullOrEmpty(Directory)) throw new Exceptions.NullField("FileManager.Directory.Delete -> string Directory");
                if (!Exists(Directory)) throw new Exceptions.DirectoryNotExists("FileManager.Directory.Delete -> Directory", Directory);

                DirectoryInfo di = new DirectoryInfo(Directory);
                di.Delete(Recursive);
            }
            #endregion

            #region METHOD-VOID | Move
            /// <summary>
            /// Переместить директорию
            /// </summary>
            /// <param name="Directory">Директория</param>
            /// <param name="NewDirectory">Новая директория</param>
            /// <exception cref="Exceptions.NullField">Нулевое поле</exception>
            /// <exception cref="Exceptions.DirectoryNotExists">Директория не существует</exception>
            public static void Move(string Directory, string NewDirectory)
            {
                if (string.IsNullOrEmpty(Directory) || string.IsNullOrEmpty(NewDirectory)) throw new Exceptions.NullField("FileManager.Directory.Move -> (string Directory || NewDirectory)");
                if (!Exists(Directory)) throw new Exceptions.DirectoryNotExists("FileManager.Directory.Move -> Directory", Directory);

                DirectoryInfo di = new DirectoryInfo(Directory);
                di.MoveTo(NewDirectory);
            }
            #endregion

            #region METHOD-VOID | Clean
            /// <summary>
            /// Очистить директорию
            /// </summary>
            /// <exception cref="Exceptions.DirectoryNotExists">Директория не существует</exception>
            public void Clean()
            {
                if (!Exists(_Directory)) throw new Exceptions.DirectoryNotExists("FileManager.Directory.Clean -> _Directory", _Directory);
                if (GetFiles().Length <= 0) return;

                foreach (var file in GetFiles()) file.Delete();
            }
            #endregion

            #region METHOD-FILEINFO[] | GetFiles
            /// <summary>
            /// Получить список файлов
            /// </summary>
            /// <returns>Список файлов в массиве</returns>
            /// <exception cref="Exceptions.DirectoryNotExists">Директория не существует</exception>
            public FileInfo[] GetFiles()
            {
                if (!Exists(_Directory)) throw new Exceptions.DirectoryNotExists("FileManager.Directory.GetFiles -> _Directory", _Directory);

                DirectoryInfo di = new DirectoryInfo(_Directory);
                return di.GetFiles();
            }
            #endregion

            #region METHOD-INT | GetFilesCount
            /// <summary>
            /// Получить количество файлов
            /// </summary>
            /// <returns>Количество файлов</returns>
            /// <exception cref="Exceptions.DirectoryNotExists">Директория не существует</exception>
            public int GetFilesCount()
            {
                if (!Exists(_Directory)) throw new Exceptions.DirectoryNotExists("FileManager.Directory.GetFilesCount -> _Directory", _Directory);

                return GetFiles().Length;
            }
            #endregion

            #region METHOD-STRING | GetBigFile
            /// <summary>
            /// Получить самый большой файл
            /// </summary>
            /// <returns>Полный путь самого большого файла</returns>
            /// <exception cref="Exceptions.DirectoryNotExists">Директория не существует</exception>
            public string GetBigFile()
            {
                if (!Exists(_Directory)) throw new Exceptions.DirectoryNotExists("FileManager.Directory.GetBigFile -> _Directory", _Directory);

                FileInfo[] files = GetFiles();
                FileInfo fi = files[0];
                foreach (var file in files) if (file.Length > fi.Length) fi = file;
                return fi.FullName;
            }
            #endregion

            #region METHOD-STRING | GetSmallFile
            /// <summary>
            /// Получить самый маленький файл
            /// </summary>
            /// <returns>Получить путь самого маленького файла</returns>
            /// <exception cref="Exceptions.DirectoryNotExists">Директория не существует</exception>
            public string GetSmallFile()
            {
                if (!Exists(_Directory)) throw new Exceptions.DirectoryNotExists("FileManager.Directory.GetSmallFile -> _Directory", _Directory);

                FileInfo[] files = GetFiles();
                FileInfo fi = files[0];
                foreach (var file in files) if (file.Length < fi.Length) fi = file;
                return fi.FullName;
            }
            #endregion

            #region METHOD-STRING | GetName
            /// <summary>
            /// Получить имя директории
            /// </summary>
            /// <returns>Имя директории</returns>
            /// <exception cref="Exceptions.DirectoryNotExists">Директория не существует</exception>
            public string GetName()
            {
                if (!Exists(_Directory)) throw new Exceptions.DirectoryNotExists("FileManager.Directory.GetName -> _Directory", _Directory);

                DirectoryInfo di = new DirectoryInfo(_Directory);
                return di.Name;
            }
            #endregion

            #region METHOD-STRING | GetPath
            /// <summary>
            /// Получить полный путь
            /// </summary>
            /// <returns>Полный путь до директории</returns>
            /// <exception cref="Exceptions.DirectoryNotExists">Директория не существует</exception>
            public string GetPath()
            {
                if (!Exists(_Directory)) throw new Exceptions.DirectoryNotExists("FileManager.Directory.GetPath -> _Directory", _Directory);

                DirectoryInfo di = new DirectoryInfo(_Directory);
                return di.FullName;
            }
            #endregion

            #region METHOD-FILEATTRIBUTES | GetAttributes
            /// <summary>
            /// Получить атрибуты директории
            /// </summary>
            /// <returns>Атрибуты директории</returns>
            /// <exception cref="Exceptions.DirectoryNotExists">Директория не существует</exception>
            public FileAttributes GetAttributes()
            {
                if (!Exists(_Directory)) throw new Exceptions.DirectoryNotExists("FileManager.Directory.GetAttributes -> _Directory", _Directory);

                DirectoryInfo di = new DirectoryInfo(_Directory);
                return di.Attributes;
            }
            #endregion

            #region METHOD-DATETIME | GetCreationTime
            /// <summary>
            /// Получить дату создания
            /// </summary>
            /// <returns>Дата создания директории</returns>
            /// <exception cref="Exceptions.DirectoryNotExists">Директория не существует</exception>
            public DateTime GetCreationTime()
            {
                if (!Exists(_Directory)) throw new Exceptions.DirectoryNotExists("FileManager.Directory.GetCreationTime -> _Directory", _Directory);

                DirectoryInfo di = new DirectoryInfo(_Directory);
                return di.CreationTime;
            }
            #endregion

            #region METHOD-DATETIME | GetCreationTimeUTC
            /// <summary>
            /// Получить дату создания в UTC
            /// </summary>
            /// <returns>Дата создания директории в UTC</returns>
            /// <exception cref="Exceptions.DirectoryNotExists">Директория не существует</exception>
            public DateTime GetCreationTimeUTC()
            {
                if (!Exists(_Directory)) throw new Exceptions.DirectoryNotExists("FileManager.Directory.GetCreationTimeUTC -> _Directory", _Directory);

                DirectoryInfo di = new DirectoryInfo(_Directory);
                return di.CreationTimeUtc;
            }
            #endregion

            #region METHOD-DATETIME | GetLastAccessTime
            /// <summary>
            /// Получить дату последнего доступа
            /// </summary>
            /// <returns>Дата последнего доступа к директории</returns>
            /// <exception cref="Exceptions.DirectoryNotExists">Директория не существует</exception>
            public DateTime GetLastAccessTime()
            {
                if (!Exists(_Directory)) throw new Exceptions.DirectoryNotExists("FileManager.Directory.GetLastAccessTime -> _Directory", _Directory);

                DirectoryInfo di = new DirectoryInfo(_Directory);
                return di.LastAccessTime;
            }
            #endregion

            #region METHOD-DATETIME | GetLastAccessTimeUTC
            /// <summary>
            /// Получить дату последнего доступа в UTC
            /// </summary>
            /// <returns>Дата последнего доступа к директории в UTC</returns>
            /// <exception cref="Exceptions.DirectoryNotExists">Директория не существует</exception>
            public DateTime GetLastAccessTimeUTC()
            {
                if (!Exists(_Directory)) throw new Exceptions.DirectoryNotExists("FileManager.Directory.GetLastAccessTimeUTC -> _Directory", _Directory);

                DirectoryInfo di = new DirectoryInfo(_Directory);
                return di.LastAccessTimeUtc;
            }
            #endregion

            #region METHOD-DATETIME | GetLastWriteTime
            /// <summary>
            /// Получить дату последнего изменения
            /// </summary>
            /// <returns>Дата последнего изменения директории</returns>
            /// <exception cref="Exceptions.DirectoryNotExists">Директория не существует</exception>
            public DateTime GetLastWriteTime()
            {
                if (!Exists(_Directory)) throw new Exceptions.DirectoryNotExists("FileManager.Directory.GetLastWriteTime -> _Directory", _Directory);

                DirectoryInfo di = new DirectoryInfo(_Directory);
                return di.LastWriteTime;
            }
            #endregion

            #region METHOD-DATETIME | GetLastWriteTimeUTC
            /// <summary>
            /// Получить дату последнего изменения в UTC
            /// </summary>
            /// <returns>Дата последнего изменения в UTC</returns>
            /// <exception cref="Exceptions.DirectoryNotExists">Директория не существует</exception>
            public DateTime GetLastWriteTimeUTC()
            {
                if (!Exists(_Directory)) throw new Exceptions.DirectoryNotExists("FileManager.Directory.GetLastWriteTimeUTC -> _Directory", _Directory);

                DirectoryInfo di = new DirectoryInfo(_Directory);
                return di.LastWriteTimeUtc;
            }
            #endregion

            #region METHOD-VOID | EditCreationTime
            /// <summary>
            /// Изменить дату создания директории
            /// </summary>
            /// <param name="CreationTime">Новая дата создания директории</param>
            /// <exception cref="Exceptions.DirectoryNotExists">Директория не существует</exception>
            /// <exception cref="Exceptions.OutOfBounds">Выход за пределы границ</exception>
            public void EditCreationTime(DateTime CreationTime)
            {
                if (!Exists(_Directory)) throw new Exceptions.DirectoryNotExists("FileManager.Directory.EditCreationTime -> _Directory", _Directory);
                if (CreationTime.Year < 1700) throw new Exceptions.OutOfBounds("FileManager.Directory.EditCreationTime -> CreationTime.Year < 1700");

                DirectoryInfo di = new DirectoryInfo(_Directory);
                di.CreationTime = CreationTime;
            }
            #endregion

            #region METHOD-VOID | EditLastAccessTime
            /// <summary>
            /// Изменить дату последнего доступа к директории
            /// </summary>
            /// <param name="LastAccessTime">Новая дата последнего доступа</param>
            /// <exception cref="Exceptions.DirectoryNotExists">Директория не существует</exception>
            /// <exception cref="Exceptions.OutOfBounds">Выход за пределы границ</exception>
            public void EditLastAccessTime(DateTime LastAccessTime)
            {
                if (!Exists(_Directory)) throw new Exceptions.DirectoryNotExists("FileManager.Directory.EditLastAccessTime -> _Directory", _Directory);
                if (LastAccessTime.Year < 1700) throw new Exceptions.OutOfBounds("FileManager.Directory.EditLastAccessTime -> LastAccessTime.Year < 1700");

                DirectoryInfo di = new DirectoryInfo(_Directory);
                di.LastAccessTime = LastAccessTime;
            }
            #endregion

            #region METHOD-VOID | EditLastWriteTime
            /// <summary>
            /// Изменить дату последней записи в директории
            /// </summary>
            /// <param name="LastWriteTime">Новая дата последней записи</param>
            /// <exception cref="Exceptions.DirectoryNotExists">Директория не существует</exception>
            /// <exception cref="Exceptions.OutOfBounds">Выход за пределы границ</exception>
            public void EditLastWriteTime(DateTime LastWriteTime)
            {
                if (!Exists(_Directory)) throw new Exceptions.DirectoryNotExists("FileManager.Directory.EditLastWriteTime -> _Directory", _Directory);
                if (LastWriteTime.Year < 1700) throw new Exceptions.OutOfBounds("FileManager.Directory.EditLastWriteTime -> LastWriteTime.Year < 1700");

                DirectoryInfo di = new DirectoryInfo(_Directory);
                di.LastWriteTime = LastWriteTime;
            }
            #endregion

            #region CLASS | ExampleDCE
            internal class ExampleDCE : IDirectoryException
            {
                public void DirectoryExists(string Directory)
                {
                    throw new Exceptions.DirectoryExists("FileManager.Directory.* -> ?Directory", Directory);
                }
            }
            #endregion
        }
        #endregion
    }
    #endregion
}
