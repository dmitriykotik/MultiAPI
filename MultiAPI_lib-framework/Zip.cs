using System;
using System.IO.Compression;
using System.IO;
using System.Security.Cryptography;
using System.Text;

/* 
  =================- INFO -===================
 * File:         | Zip.cs
 * Class:        | Zip
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
    #region CLASS | Zip
    /// <summary>
    /// Действия с файлами и архивами
    /// </summary>
    public static class Zip
    {

        #region METHOD-VOID | EncryptFile
        /// <summary>
        /// Шифрование файла
        /// </summary>
        /// <param name="inputFile">Входной файл</param>
        /// <param name="outputFile">Выходной файл</param>
        /// <param name="password">Пароль на файл</param>
        /// <param name="BufferSize">Размер буфера (При дешифровке файла, размер буфера должен совпадать с размеров буфера при шифровке!!!) (Стандартное значение: 104576)</param>
        public static void EncryptFile(string inputFile, string outputFile, string password, int BufferSize = 104576)
        {
            if (string.IsNullOrEmpty(inputFile) || string.IsNullOrEmpty(outputFile) || string.IsNullOrEmpty(password)) throw new Exception("inputFile, outputFile или password не могут быть пустыми!");
            if (!File.Exists(inputFile)) throw new Exception("Входной файла не существует!");
            if (password.Length < 4) throw new Exception("Пароль должен содержать не менее 4-х символов!");
            if (BufferSize < 256) throw new Exception("Размер буфера должен быть не менее 256!");
            UnicodeEncoding UE = new UnicodeEncoding();
            byte[] key = UE.GetBytes(password);

            RijndaelManaged RMCrypto = new RijndaelManaged();
            RMCrypto.Mode = CipherMode.CBC;

            byte[] iv = RMCrypto.IV;

            using (FileStream fsCrypt = new FileStream(outputFile, FileMode.Create))
            {
                fsCrypt.Write(iv, 0, iv.Length);

                using (CryptoStream cs = new CryptoStream(fsCrypt, RMCrypto.CreateEncryptor(key, iv), CryptoStreamMode.Write))
                {
                    using (FileStream fsIn = new FileStream(inputFile, FileMode.Open))
                    {
                        byte[] buffer = new byte[BufferSize];
                        int read;

                        while ((read = fsIn.Read(buffer, 0, buffer.Length)) > 0) cs.Write(buffer, 0, read);
                    }
                }
            }
        }
        #endregion

        #region METHOD-VOID | DecryptFile
        /// <summary>
        /// Дешифровка файла
        /// </summary>
        /// <param name="inputFile">Входной файл</param>
        /// <param name="outputFile">Выходной файл</param>
        /// <param name="password">Пароль</param>
        /// <param name="BufferSize">Размер буфера (При дешифровке файла, размер буфера должен совпадать с размеров буфера при шифровке!!!) (Стандартное значение: 104576)</param>
        public static void DecryptFile(string inputFile, string outputFile, string password, int BufferSize = 104576)
        {
            if (string.IsNullOrEmpty(inputFile) || string.IsNullOrEmpty(outputFile) || string.IsNullOrEmpty(password)) throw new Exception("inputFile, outputFile или password не могут быть пустыми!");
            if (!File.Exists(inputFile)) throw new Exception("Входной файла не существует!");
            if (password.Length < 4) throw new Exception("Пароль должен содержать не менее 4-х символов!");
            if (BufferSize < 256) throw new Exception("Размер буфера должен быть не менее 256!");
            UnicodeEncoding UE = new UnicodeEncoding();
            byte[] key = UE.GetBytes(password);

            RijndaelManaged RMCrypto = new RijndaelManaged();
            RMCrypto.Mode = CipherMode.CBC;

            byte[] iv = new byte[16];

            using (FileStream fsCrypt = new FileStream(inputFile, FileMode.Open))
            {
                fsCrypt.Read(iv, 0, iv.Length);

                using (CryptoStream cs = new CryptoStream(fsCrypt, RMCrypto.CreateDecryptor(key, iv), CryptoStreamMode.Read))
                {
                    using (FileStream fsOut = new FileStream(outputFile, FileMode.Create))
                    {
                        byte[] buffer = new byte[BufferSize];
                        int read;

                        while ((read = cs.Read(buffer, 0, buffer.Length)) > 0) fsOut.Write(buffer, 0, read);
                    }
                }
            }
        }
        #endregion

        #region METHOD-VOID | create
        /// <summary>
        /// Создание архива из содержимого папки
        /// </summary>
        /// <param name="pathFoler">Путь до папки с содержимым</param>
        /// <param name="outputArchive">Выходной файл</param>
        public static void create(string pathFoler, string outputArchive)
        {
            if (Directory.Exists(pathFoler)) ZipFile.CreateFromDirectory(pathFoler, outputArchive);
            else throw new Exception("Папка с содержимым не существует!");

        }
        #endregion

        #region METHOD-VOID | unpacking
        /// <summary>
        /// Распаковка архива в папку
        /// </summary>
        /// <param name="pathArchive">Архив для распаковки</param>
        /// <param name="outputFolder">Папка в которую распакуется архив</param>
        public static void unpacking(string pathArchive, string outputFolder)
        {
            if (File.Exists(pathArchive))
            {
                if (Directory.Exists(outputFolder)) System.IO.Compression.ZipFile.ExtractToDirectory(pathArchive, outputFolder);
                else throw new Exception("Папка для распаковки не существует!");
            }
            else throw new Exception("Архив не существует!");
        }
        #endregion

    }
    #endregion
}
