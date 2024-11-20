using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using Newtonsoft.Json;

/* 
  =================- INFO -===================
 * File:         | Cryptography.cs
 * Class:        | Cryptography
 * Project:      | MultiAPI
 * Author:       | dmitriykotik
 * Version:      | 0.0.0.0
 * VerType:      | major_version.minor_version.patch_version.builds
 * Main file:    | Main.cs
 * [OPEN SOURCE] | +True
 * [CONSTRUCTOR] | +True
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
        /// <param name="inputFile">Входной файл (Например: input.txt)</param>
        /// <param name="outputFile">Выходной файл (Например: output.txt)</param>
        /// <param name="inputKeyFile">Входной класс CustomEncode (Например: CustomEncode encode = new CustomEncode("key.import");). Для подробной информации посмотрите документацию.</param>
        public static void EncryptEncode(string inputFile, string outputFile, CustomEncode inputKeyFile)
        {
            if (string.IsNullOrEmpty(inputFile) || string.IsNullOrEmpty(outputFile) || inputKeyFile == null) throw new Exception("0x00003");
            if (!File.Exists(inputFile)) throw new Exception("0x00004");
            if (File.Exists(outputFile)) File.Delete(outputFile);

            string content = File.ReadAllText(inputFile);
            string encContent = "";
            foreach (char c in content) 
            { 
                if (inputKeyFile.get().ContainsKey(c)) encContent += inputKeyFile.get()[c] + " "; 
            }

            File.WriteAllText(outputFile, encContent);
        }
        #endregion

        #region METHOD-VOID | DecryptEncode
        /// <summary>
        /// Расшифровка УНИКАЛЬНОЙ кодировки с помощью файла кодировки. Работает только с текстовыми файлами.
        /// </summary>
        /// <param name="inputFile">Входной файл (Например: input.txt)</param>
        /// <param name="outputFile">Выходной файл (Например: output.txt)</param>
        /// <param name="inputKeyFile">Входной класс CustomEncode (Например: CustomEncode encode = new CustomEncode("key.import");). Для подробной информации посмотрите документацию.</param>
        public static void DecryptEncode(string inputFile, string outputFile, CustomEncode inputKeyFile)
        {
            if (string.IsNullOrEmpty(inputFile) || string.IsNullOrEmpty(outputFile) || inputKeyFile == null) throw new Exception("0x00003");
            if (!File.Exists(inputFile)) throw new Exception("0x00004");
            if (File.Exists(outputFile)) File.Delete(outputFile);

            string[] content = File.ReadAllText(inputFile).Split(' ');
            string decContent = "";
            foreach (string code in content)
            {
                if (inputKeyFile.getReverse().ContainsKey(code)) decContent += inputKeyFile.getReverse()[code];
            }

            File.WriteAllText(outputFile, decContent);
        }
        #endregion

        #region METHOD-VOID | EncryptFile
        /// <summary>
        /// Шифровка файла
        /// </summary>
        /// <param name="inputFile">Входной файл (Например: input.zip)</param>
        /// <param name="outputFile">Выходной файл (Например: output.zip.enc)</param>
        /// <param name="password">Пароль для шифровки (Например: qwerty123)</param>
        /// <param name="salt">Соль. Для генерации соли используйте метод GenerateSalt();</param>
        /// <param name="replaceExistsOutputFile">Заменять выходной файл если он уже существует?</param>>
        public static void EncryptFile(string inputFile, string outputFile, string password, byte[] salt, bool replaceExistsOutputFile)
        {
            if (string.IsNullOrEmpty(inputFile) || string.IsNullOrEmpty(outputFile) || string.IsNullOrEmpty(password) || salt == null) throw new Exception("0x00003");
            if (!File.Exists(inputFile)) throw new Exception("0x00004");
            if (File.Exists(outputFile)) { if (!replaceExistsOutputFile) throw new Exception("0x00007"); }

            byte[] key;
            using (var keyDerivation = new Rfc2898DeriveBytes(password, salt, 100000)) key = keyDerivation.GetBytes(32);

            File.Delete(outputFile);

            using (FileStream fs = new FileStream(outputFile, FileMode.Create))
            {
                fs.Write(salt, 0, salt.Length);

                using (Aes aes = Aes.Create())
                {
                    aes.Key = key;
                    aes.IV = aes.IV;

                    fs.Write(aes.IV, 0, aes.IV.Length);

                    using (CryptoStream cryptoStream = new CryptoStream(fs, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        using (FileStream inputFileStream = new FileStream(inputFile, FileMode.Open)) inputFileStream.CopyTo(cryptoStream);
                    }
                }
            }
        }
        #endregion

        #region METHOD-VOID | DecryptFile
        /// <summary>
        /// Дешифровка файла
        /// </summary>
        /// <param name="inputFile">Входной файл (Например: output.zip.enc)</param>
        /// <param name="outputFile">Выходной файл (Например: input.zip)</param>
        /// <param name="password">Пароль для дешифровки (Например: qwerty123)</param>
        /// <param name="replaceExistsOutputFile">Заменять выходной файл если он уже существует?</param>>
        /// <param name="sizeSalt">Размер соли (Размер должен совпадать с солью зашифрованного файла, по умолчанию 16)</param>
        static void DecryptFile(string inputFile, string outputFile, string password, bool replaceExistsOutputFile, int sizeSalt = 16)
        {
            if (string.IsNullOrEmpty(inputFile) || string.IsNullOrEmpty(outputFile) || string.IsNullOrEmpty(password)) throw new Exception("0x00003");
            if (sizeSalt < 16) throw new Exception("0x00006");
            if (!File.Exists(inputFile)) throw new Exception("0x00004");
            if (File.Exists(outputFile)) { if (!replaceExistsOutputFile) throw new Exception("0x00007"); }

            using (FileStream fs = new FileStream(inputFile, FileMode.Open))
            {
                byte[] salt = new byte[sizeSalt];
                fs.Read(salt, 0, salt.Length);

                byte[] iv = new byte[sizeSalt];
                fs.Read(iv, 0, iv.Length);

                byte[] key;
                using (var keyDerivation = new Rfc2898DeriveBytes(password, salt, 100000)) key = keyDerivation.GetBytes(32);

                using (Aes aes = Aes.Create())
                {
                    aes.Key = key;
                    aes.IV = iv;

                    using (CryptoStream cryptoStream = new CryptoStream(fs, aes.CreateDecryptor(), CryptoStreamMode.Read))
                    {
                        File.Delete(outputFile);
                        using (FileStream outputFileStream = new FileStream(outputFile, FileMode.Create)) cryptoStream.CopyTo(outputFileStream);
                    }
                }
            }
        }
        #endregion

        #region METHOD-BYTE[] | GenerateSalt
        /// <summary>
        /// Генерация соли
        /// </summary>
        /// <param name="byteSalt">Размер соли (По умолчанию: 16)</param>
        /// <returns>Соль (В байтах) (Можно использовать для шифровки)</returns>
        public static byte[] GenerateSalt(int sizeSalt = 16)
        {
            if (sizeSalt < 16) throw new Exception("0x00006");
            byte[] salt = new byte[sizeSalt];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }
        #endregion

        #region CLASS | CustomEncode
        /// <summary>
        /// Класс для создания файла кодировки
        /// </summary>
        public class CustomEncode
        {
            internal string file;

            #region METHOD-CustomEncode | CustomEncode
            /// <summary>
            /// Загрузка файла
            /// </summary>
            /// <param name="keyFile">Файл ключа (Если не существует, то он будет создан)</param>
            public CustomEncode(string keyFile) => file = keyFile;
            #endregion

            #region METHOD-VOID | Create
            /// <summary>
            /// Создать файл кодировки
            /// </summary>
            /// <param name="customSymbols">Использовать свои символы для кодировки? (null - Не использовать)</param>
            public void Create(string customSymbols = null)
            {
                if (File.Exists(file)) File.Delete(file);
                var encoding = new Dictionary<char, string>();
                var usedCodes = new HashSet<string>();
                string symbols;

                if (string.IsNullOrEmpty(customSymbols))
                    symbols = "АаБбВвГгДдЕеЁёЖжЗзИиЙйКкЛлМмНнОоПпРрСсТтУуФфХхЦцЧчШшЩщЪъЫыЬьЭэЮюЯя"
                                      + "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                      + "0123456789 "
                                      + @""""
                                      + @"@#№$;%`~^:&?*()-_=+[]{}\|'/.,<>"
                                      + "\n";
                else symbols = customSymbols;

                foreach (char c in symbols)
                {
                    while (true)
                    {
                        encoding[c] = " ";
                        usedCodes.Add(" ");
                        break;
                    }
                }

                File.WriteAllText(file, JsonConvert.SerializeObject(encoding, Formatting.Indented));
            }
            #endregion

            #region METHOD-VOID | CreateAuto
            /// <summary>
            /// Автоматически сгенерировать файл кодировки
            /// </summary>
            /// <param name="lengthCode">Размер каждого ключа для символа (По умолчанию: 8)</param>
            /// <param name="customSymbols">Использовать свои символы для кодировки? (null - Не использовать)</param>
            public void CreateAuto(int lengthCode = 8, string customSymbols = null, string customSymbolsCode = null)
            {
                if (File.Exists(file)) File.Delete(file);
                var encoding = new Dictionary<char, string>();
                var usedCodes = new HashSet<string>();
                string symbols;
                string symbolsCodes;
                
                if (string.IsNullOrEmpty(customSymbols)) symbols = "АаБбВвГгДдЕеЁёЖжЗзИиЙйКкЛлМмНнОоПпРрСсТтУуФфХхЦцЧчШшЩщЪъЫыЬьЭэЮюЯя"
                                  + "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                                  + "0123456789 "
                                  + @""""
                                  + @"@#№$;%`~^:&?*()-_=+[]{}\|'/.,<>"
                                  + "\n";
                else symbols = customSymbols;

                if (string.IsNullOrEmpty(customSymbolsCode)) symbolsCodes = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                else symbolsCodes = customSymbolsCode;

                foreach (char c in symbols)
                {
                    while (true)
                    {
                        string rnd = Generator.GenPassword(8, symbolsCodes);

                        if (!usedCodes.Contains(rnd))
                        {
                            encoding[c] = rnd;
                            usedCodes.Add(rnd);
                            break;
                        }
                    }
                }

                File.WriteAllText(file, JsonConvert.SerializeObject(encoding, Formatting.Indented));
            }
            #endregion

            #region INTERNAL METHOD-DICTIONARY<STRING,CHAR> | getReverse
            /// <summary>
            /// ЛОКАЛЬНО: Получить кодировку формата <char,string> и преобразовать её <string,char>
            /// </summary>
            /// <returns>Словарь формата <string,char></returns>
            internal Dictionary<string, char> getReverse()
            {
                if (File.Exists(file))
                {
                    string json = File.ReadAllText(file);
                    var dictionary = JsonConvert.DeserializeObject<Dictionary<char, string>>(json);
                    var reverseDictionary = new Dictionary<string, char>();
                    foreach (var kvp in dictionary) reverseDictionary[kvp.Value] = kvp.Key;
                    return reverseDictionary;
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
            /// ЛОКАЛЬНО: Получить кодировку формата <char,string>
            /// </summary>
            /// <returns>Словарь формата <char,string></returns>
            internal Dictionary<char, string> get()
            {
                if (File.Exists(file)) return JsonConvert.DeserializeObject<Dictionary<char, string>>(File.ReadAllText(file));
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
            public string GetFile() => file;
            #endregion

        }
        #endregion

    }
    #endregion

}