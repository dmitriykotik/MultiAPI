using Newtonsoft.Json;
using System.Security.Cryptography;

/* 
  =================- INFO -===================
 * File:         | Cryptography.cs
 * Class:        | Cryptography
 * Project:      | MultiAPI
 * Author:       | dmitriykotik
 * [OPEN SOURCE] | +True
 * [CONSTRUCTOR] | +False
  ============================================
 */

namespace MultiAPI
{

    #region CLASS | Cryptography
    /// <summary>
    /// Класс криптографии
    /// </summary>
    public static class Cryptography
    {

        #region METHOD-VOID | EncryptEncode
        /// <summary>
        /// Ручная шифровка УНИКАЛЬНОЙ кодировкой. Работает только с текстовыми файлами.
        /// </summary>
        /// <param name="InputFile">Входной файл (Например: input.txt)</param>
        /// <param name="OutputFile">Выходной файл (Например: output.txt)</param>
        /// <param name="InputKeyFile">Входной класс CustomEncode (Например: CustomEncode encode = new CustomEncode("key.import");). Для подробной информации посмотрите документацию.</param>
        /// <param name="FCE">Интерфейс обработки ошибки существования файла. По умолчанию ExampleFCE (см. Документацию)</param>
        /// <exception cref="Exceptions.NullField">Нулевое поле</exception>
        /// <exception cref="Exceptions.FileNotExists">Файл не существует</exception>
        #pragma warning disable CS8602
        public static void EncryptEncode(string InputFile, string OutputFile, CustomEncode InputKeyFile, IFileException? FCE = null)
        {
            if (string.IsNullOrEmpty(InputFile) || string.IsNullOrEmpty(OutputFile) || InputKeyFile == null) throw new Exceptions.NullField("Cryptography.EncryptEncode -> (string InputFile || string OutputFile || string InputKeyFile) == null");
            if (!FileManager.File.Exists(InputFile)) throw new Exceptions.FileNotExists("Cryptography.EncryptEncode -> FileManager.File.Exists", InputFile);
            if (FCE == null) FCE = new ExampleFCE();
            if (FileManager.File.Exists(OutputFile)) FCE.FileExists(OutputFile);

            string Content = FileManager.File.ReadAllText(InputFile);
            string EncContent = "";
            foreach (char c in Content)
            {
                if (InputKeyFile.Get().ContainsKey(c)) EncContent += InputKeyFile.Get()[c] + " ";
            }

            FileManager.File.WriteAllText(OutputFile, EncContent);
        }
        #endregion

        #region METHOD-VOID | DecryptEncode
        /// <summary>
        /// Расшифровка УНИКАЛЬНОЙ кодировки с помощью файла кодировки. Работает только с текстовыми файлами.
        /// </summary>
        /// <param name="InputFile">Входной файл (Например: input.txt)</param>
        /// <param name="OutputFile">Выходной файл (Например: output.txt)</param>
        /// <param name="InputKeyFile">Входной класс CustomEncode (Например: CustomEncode encode = new CustomEncode("key.import");). Для подробной информации посмотрите документацию.</param>
        /// <param name="FCE">Интерфейс обработки ошибки существования файла. По умолчанию ExampleFCE (см. Документацию)</param>
        /// <exception cref="Exceptions.NullField">Нулевое поле</exception>
        /// <exception cref="Exceptions.FileNotExists">Файл не существует</exception>
        public static void DecryptEncode(string InputFile, string OutputFile, CustomEncode InputKeyFile, IFileException? FCE = null)
        {
            if (string.IsNullOrEmpty(InputFile) || string.IsNullOrEmpty(OutputFile) || InputKeyFile == null) throw new Exceptions.NullField("Cryptography.DecryptEncode -> (string InputFile || string OutputFile || string InputKeyFile) == null");
            if (!FileManager.File.Exists(InputFile)) throw new Exceptions.FileNotExists("Cryptography.DecryptEncode -> FileManager.File.Exists", InputFile);
            if (FCE == null) FCE = new ExampleFCE();
            if (FileManager.File.Exists(OutputFile)) FCE.FileExists(OutputFile);

            string[] Content = FileManager.File.ReadAllText(InputFile).Split(' ');
            string DecContent = "";
            foreach (string Code in Content)
            {
                if (InputKeyFile.GetReverse().ContainsKey(Code)) DecContent += InputKeyFile.GetReverse()[Code];
            }

            FileManager.File.WriteAllText(OutputFile, DecContent);
        }
#pragma warning restore CS8602
        #endregion

        #region METHOD-VOID | EncryptFile
        /// <summary>
        /// Шифровка файла
        /// </summary>
        /// <param name="InputFile">Входной файл (Например: input.zip)</param>
        /// <param name="OutputFile">Выходной файл (Например: output.zip.enc)</param>
        /// <param name="Password">Пароль для шифровки (Например: qwerty123)</param>
        /// <param name="Salt">Соль. Для генерации соли используйте метод GenerateSalt();</param>
        /// <param name="FCE">Интерфейс обработки ошибки существования файла. По умолчанию ExampleFCE (см. Документацию)</param>
        /// <exception cref="Exceptions.NullField">Нулевое поле</exception>
        /// <exception cref="Exceptions.FileNotExists">Файл не существует</exception>
        public static void EncryptFile(string InputFile, string OutputFile, string Password, byte[] Salt, IFileException? FCE = null)
        {
            if (string.IsNullOrEmpty(InputFile) || string.IsNullOrEmpty(OutputFile) || string.IsNullOrEmpty(Password) || Salt == null) throw new Exceptions.NullField("Cryptography.EncryptFile -> (string InputFile || string OutputFile || string InputKeyFile || byte[] Salt) == null");
            if (!FileManager.File.Exists(InputFile)) throw new Exceptions.FileNotExists("Cryptography.EncryptFile -> FileManager.File.Exists", InputFile);
            if (FCE == null) FCE = new ExampleFCE();
            if (FileManager.File.Exists(OutputFile)) FCE.FileExists(OutputFile);

            byte[] Key;
            using (var KeyDerivation = new Rfc2898DeriveBytes(Password, Salt, 100000, HashAlgorithmName.SHA256)) Key = KeyDerivation.GetBytes(32);

            File.Delete(OutputFile);

            using (FileStream fs = new FileStream(OutputFile, FileMode.Create))
            {
                fs.Write(Salt, 0, Salt.Length);

                using (Aes aes = Aes.Create())
                {
                    aes.Key = Key;
                    aes.IV = aes.IV;

                    fs.Write(aes.IV, 0, aes.IV.Length);

                    using (CryptoStream cryptoStream = new CryptoStream(fs, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        using (FileStream InputFileStream = new FileStream(InputFile, FileMode.Open)) InputFileStream.CopyTo(cryptoStream);
                    }
                }
            }
        }
        #endregion

        #region METHOD-VOID | DecryptFile
        /// <summary>
        /// Дешифровка файла
        /// </summary>
        /// <param name="InputFile">Входной файл (Например: output.zip.enc)</param>
        /// <param name="OutputFile">Выходной файл (Например: input.zip)</param>
        /// <param name="Password">Пароль для дешифровки (Например: qwerty123)</param>
        /// <param name="SizeSalt">Размер соли (Размер должен совпадать с солью зашифрованного файла, по умолчанию 16)</param>
        /// <param name="FCE">Интерфейс обработки ошибки существования файла. По умолчанию ExampleFCE (см. Документацию)</param>
        /// <exception cref="Exceptions.NullField">Нулевое поле</exception>
        /// <exception cref="Exceptions.FileNotExists">Файл не существует</exception>
        /// <exception cref="Exceptions.OutOfBounds">Выход за рамки границ</exception>
        public static void DecryptFile(string InputFile, string OutputFile, string Password, int SizeSalt = 16, IFileException? FCE = null)
        {
            if (string.IsNullOrEmpty(InputFile) || string.IsNullOrEmpty(OutputFile) || string.IsNullOrEmpty(Password)) throw new Exceptions.NullField("Cryptography.DecryptFile -> (string InputFile || string OutputFile || string Password || int SizeSalt = 16) == null");
            if (SizeSalt < 16) throw new Exceptions.OutOfBounds("Cryptography.DecryptFile -> SizeSalt < 16");
            if (!FileManager.File.Exists(InputFile)) throw new Exceptions.FileNotExists("Cryptography.EncryptFile -> FileManager.File.Exists", InputFile);
            if (FCE == null) FCE = new ExampleFCE();
            if (FileManager.File.Exists(OutputFile)) FCE.FileExists(OutputFile);

            using (FileStream fs = new FileStream(InputFile, FileMode.Open))
            {
                byte[] Salt = new byte[SizeSalt];
                fs.Read(Salt, 0, Salt.Length);

                byte[] iv = new byte[SizeSalt];
                fs.Read(iv, 0, iv.Length);

                byte[] key;
                using (var keyDerivation = new Rfc2898DeriveBytes(Password, Salt, 100000, HashAlgorithmName.SHA256)) key = keyDerivation.GetBytes(32);

                using (Aes aes = Aes.Create())
                {
                    aes.Key = key;
                    aes.IV = iv;

                    using (CryptoStream cryptoStream = new CryptoStream(fs, aes.CreateDecryptor(), CryptoStreamMode.Read))
                    {
                        File.Delete(OutputFile);
                        using (FileStream OutputFileStream = new FileStream(OutputFile, FileMode.Create)) cryptoStream.CopyTo(OutputFileStream);
                    }
                }
            }
        }
        #endregion

        #region METHOD-STRING | HashPassword
        /// <summary>
        /// Хеширование пароля
        /// </summary>
        /// <param name="Password">Пароль</param>
        /// <param name="Salt">Соль (Для генерации используйте метод GenerateSalt)</param>
        /// <returns>Хэш пароля</returns>
        /// <exception cref="Exceptions.NullField">Нулевое поле</exception>
        public static string HashPassword(string Password, byte[] Salt)
        {
            if (string.IsNullOrEmpty(Password) || Salt == null) throw new Exceptions.NullField("Cryptography.HashPassword -> (string Password || byte[] Salt) == null");

            var pbkdf2 = new Rfc2898DeriveBytes(Password, Salt, 10000, HashAlgorithmName.SHA256);
            byte[] Hash = pbkdf2.GetBytes(20);

            byte[] HashBytes = new byte[36];
            Array.Copy(Salt, 0, HashBytes, 0, 16);
            Array.Copy(Hash, 0, HashBytes, 16, 20);

            return Convert.ToBase64String(HashBytes);
        }
        #endregion

        #region METHOD-BOOL | VerifyPassword
        /// <summary>
        /// Проверка пароля по хэшу
        /// </summary>
        /// <param name="InputPassword">Пароль</param>
        /// <param name="InputHash">Хэш</param>
        /// <param name="SizeSalt">Размер соли (По умолчанию: 16)</param>
        /// <returns>true - Если пароль верен, иначе false</returns>
        /// <exception cref="Exceptions.NullField">Нулевое поле</exception>
        public static bool VerifyPassword(string InputPassword, string InputHash, int SizeSalt = 16)
        {
            if (string.IsNullOrEmpty(InputPassword) || string.IsNullOrEmpty(InputHash)) throw new Exceptions.NullField("Cryptography.VerifyPassword -> (string InputPassword || string InputHash) == null");

            byte[] HashBytes = Convert.FromBase64String(InputHash);
            byte[] Salt = new byte[SizeSalt];
            Array.Copy(HashBytes, 0, Salt, 0, 16);

            var pbkdf2 = new Rfc2898DeriveBytes(InputPassword, Salt, 10000, HashAlgorithmName.SHA256);
            byte[] hash = pbkdf2.GetBytes(20);

            for (int i = 0; i < 20; i++)
            {
                if (HashBytes[i + 16] != hash[i])
                {
                    return false;
                }
            }

            return true;
        }
        #endregion

        #region METHOD-BYTE[] | GenerateSalt
        /// <summary>
        /// Генерация соли
        /// </summary>
        /// <param name="SizeSalt">Размер соли (По умолчанию: 16)</param>
        /// <returns>Соль (В байтах) (Можно использовать для шифровки)</returns>
        /// <exception cref="Exceptions.OutOfBounds">Выход за рамки границ</exception>
        public static byte[] GenerateSalt(int SizeSalt = 16)
        {
            if (SizeSalt < 16) throw new Exceptions.OutOfBounds("Cryptography.GenerateSalt -> SizeSalt < 16");
            byte[] Salt = new byte[SizeSalt];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(Salt);
            }
            return Salt;
        }
        #endregion

        #region CLASS | CustomEncode
        /// <summary>
        /// Класс для создания файла кодировки
        /// </summary>
        public class CustomEncode
        {
            internal string File;

            #region METHOD-CustomEncode | CustomEncode
            /// <summary>
            /// Загрузка файла
            /// </summary>
            /// <param name="keyFile">Файл ключа (Если не существует, то он будет создан)</param>
            public CustomEncode(string keyFile) => File = keyFile;
            #endregion

            #region METHOD-VOID | Create
            /// <summary>
            /// Создать файл кодировки
            /// </summary>
            /// <param name="CustomSymbols">Использовать свои символы для кодировки? (null - Не использовать)</param>
            public void Create(string? CustomSymbols = null)
            {
                if (FileManager.File.Exists(File)) FileManager.File.Delete(File);
                var Encoding = new Dictionary<char, string>();
                var UsedCodes = new HashSet<string>();
                string Symbols;

                if (string.IsNullOrEmpty(CustomSymbols))
                    Symbols = "АаБбВвГгДдЕеЁёЖжЗзИиЙйКкЛлМмНнОоПпРрСсТтУуФфХхЦцЧчШшЩщЪъЫыЬьЭэЮюЯя"
                                      + "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                      + "0123456789 "
                                      + @""""
                                      + @"@#№$;%`~^:&?*()-_=+[]{}\|'/.,<>"
                                      + "\n";
                else Symbols = CustomSymbols;

                foreach (char c in Symbols)
                {
                    while (true)
                    {
                        Encoding[c] = " ";
                        UsedCodes.Add(" ");
                        break;
                    }
                }

                FileManager.File.WriteAllText(File, JsonConvert.SerializeObject(Encoding, Formatting.Indented));
            }
            #endregion

            #region METHOD-VOID | CreateAuto
            /// <summary>
            /// Автоматически сгенерировать файл кодировки
            /// </summary>
            /// <param name="LengthCode">Размер каждого ключа для символа (По умолчанию: 8)</param>
            /// <param name="CustomSymbols">Использовать свои символы для кодировки? (null - Не использовать)</param>
            /// <param name="CustomSymbolsCode">Использовать свои символы для генератора пароля? (null - Не использовать)</param>
            public void CreateAuto(int LengthCode = 8, string? CustomSymbols = null, string? CustomSymbolsCode = null)
            {
                if (FileManager.File.Exists(File)) FileManager.File.Delete(File);
                var Encoding = new Dictionary<char, string>();
                var UsedCodes = new HashSet<string>();
                string Symbols;
                string SymbolsCodes;

                if (string.IsNullOrEmpty(CustomSymbols)) Symbols = "АаБбВвГгДдЕеЁёЖжЗзИиЙйКкЛлМмНнОоПпРрСсТтУуФфХхЦцЧчШшЩщЪъЫыЬьЭэЮюЯя"
                                  + "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                  + "0123456789 "
                                  + @""""
                                  + @"@#№$;%`~^:&?*()-_=+[]{}\|'/.,<>"
                                  + "\n";
                else Symbols = CustomSymbols;

                if (string.IsNullOrEmpty(CustomSymbolsCode)) SymbolsCodes = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                else SymbolsCodes = CustomSymbolsCode;

                foreach (char c in Symbols)
                {
                    while (true)
                    {
                        string rnd = Generator.GenPassword(LengthCode, SymbolsCodes);

                        if (!UsedCodes.Contains(rnd))
                        {
                            Encoding[c] = rnd;
                            UsedCodes.Add(rnd);
                            break;
                        }
                    }
                }

                FileManager.File.WriteAllText(File, JsonConvert.SerializeObject(Encoding, Formatting.Indented));
            }
            #endregion

            #region INTERNAL METHOD-DICTIONARY<STRING,CHAR> | getReverse
            /// <summary>
            /// ЛОКАЛЬНО: Получить кодировку формата char,string и преобразовать её string,char
            /// </summary>
            /// <returns>Словарь формата string,char</returns>
            internal Dictionary<string, char>? GetReverse()
            {
                if (FileManager.File.Exists(File))
                {
                    string Json = FileManager.File.ReadAllText(File);
                    var Dictionary = JsonConvert.DeserializeObject<Dictionary<char, string>>(Json);
                    var ReverseDictionary = new Dictionary<string, char>();
                    if (Dictionary != null)
                        foreach (var kvp in Dictionary) ReverseDictionary[kvp.Value] = kvp.Key;
                    return ReverseDictionary;
                }
                else
                {
                    Create();
                    return null;
                }
            }
            #endregion

            #region INTERNAL METHOD-DICTIONARY<CHAR,STRING> | get
            /// <summary>
            /// ЛОКАЛЬНО: Получить кодировку формата char,string
            /// </summary>
            /// <returns>Словарь формата char,string</returns>
            internal Dictionary<char, string>? Get()
            {
                if (FileManager.File.Exists(File)) return JsonConvert.DeserializeObject<Dictionary<char, string>>(FileManager.File.ReadAllText(File));
                else
                {
                    Create();
                    return null;
                }
            }
            #endregion

            #region METHOD-STRING | GetFile
            /// <summary>
            /// Получить файл
            /// </summary>
            /// <returns>Путь до файла</returns>
            public string GetFile() => File;
            #endregion

        }
        #endregion

        #region CLASS | ExampleFCE
        internal class ExampleFCE : IFileException
        {
            public void FileExists(string File)
            {
                throw new Exceptions.FileExists("Cryptography.File.* -> ?File", File);
            }

            public void FilesExists(string[] Files){
                throw new Exceptions.FileExists("Cryptography.File.* -> ?Files", string.Join("; ", Files));
            }
        }
        #endregion

    }
    #endregion

}
