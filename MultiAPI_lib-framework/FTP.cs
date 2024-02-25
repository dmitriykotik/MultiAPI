using System.IO;
using System.Net;

/* 
  =================- INFO -===================
 * File:         | FTP.cs
 * Class:        | FTP
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

    #region CLASS | FTP
    /// <summary>
    /// Действия с FTP с помощью конструктора ( FTP nameVar = new FTP("ftp://0.0.0.0:21//file.exmp", "login", "password") )
    /// </summary>
    public class FTP
    {

        #region METHOD-STRING | host, userName, password
        private string _host;
        private string _userName;
        private string _password;
        #endregion

        #region METHOD-FTP | FTP
        /// <summary>
        /// Создание конструкции для управления FTP
        /// </summary>
        /// <param name="host">Полная ссылка до удалённого файла на FTP сервере (например: ftp://0.0.0.0:21//file.exmp)</param>
        /// <param name="userName">Вход: Имя пользователя (например: exampleName)</param>
        /// <param name="password">Вход: Пароль пользователя (например: Ex@mpleP@3w0rd)</param>
        public FTP(string host, string userName, string password)
        {
            _host = host;
            _userName = userName;
            _password = password;
        }
        #endregion

        #region METHOD-VOID | upload
        /// <summary>
        /// Загрузка локального файла на FTP сервер
        /// </summary>
        /// <param name="localFullPath">Путь до файла на локальном компьютере (например: C:\path\to\file.exmp или: file.exmp)</param>
        public void upload(string localFullPath)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(_host);

            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = new NetworkCredential(_userName, _password);
            request.UsePassive = true;
            request.UseBinary = true;
            request.KeepAlive = false;

            using (Stream inputStream = File.OpenRead(localFullPath))
            using (Stream outputStream = request.GetRequestStream())
            {
                byte[] buffer = new byte[1024];
                int bytesRead = 0;
                while ((bytesRead = inputStream.Read(buffer, 0, buffer.Length)) > 0) outputStream.Write(buffer, 0, bytesRead);
            }
        }
        #endregion

        #region METHOD-VOID | download
        /// <summary>
        /// Загрузка файла с FTP сервера в локальный файл
        /// </summary>
        /// <param name="localPath">Полный путь до файла который будет сохранён на локальном компьютере (например: C:\path\to\file.exmp; или: file.exmp)</param>
        public void download(string localPath)
        {
            using (WebClient client = new WebClient())
            {
                client.Credentials = new NetworkCredential(_userName, _password);
                client.DownloadFile(_host, localPath);
            }
        }
        #endregion

        #region METHOD-VOID | delete
        /// <summary>
        /// Удаление файла на FTP сервере
        /// </summary>
        public void delete()
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(_host);
            request.Method = WebRequestMethods.Ftp.DeleteFile;
            request.Credentials = new NetworkCredential(_userName, _password);
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            response.Close();
        }
        #endregion

        #region METHOD-BOOL | exists
        /// <summary>
        /// Проверка наличия файла на FTP сервере
        /// </summary>
        /// <returns>true - если файл существует, false - если файл отсутствует.</returns>
        public bool exists()
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(_host);
            request.Credentials = new NetworkCredential(_userName, _password);
            request.Method = WebRequestMethods.Ftp.GetDateTimestamp;

            try { using (FtpWebResponse response = (FtpWebResponse)request.GetResponse()) return true; }
            catch (WebException ex) when (((FtpWebResponse)ex.Response).StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable) { return false; }
        }
        #endregion

    }
    #endregion

}
