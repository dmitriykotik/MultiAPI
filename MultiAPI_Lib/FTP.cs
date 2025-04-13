using System.Net;

/* 
  =================- INFO -===================
 * File:         | FTP.cs
 * Class:        | FTP
 * Project:      | MultiAPI
 * Author:       | dmitriykotik
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
    [Obsolete("Данный метод устарел. Используйте другую библиотеку, например: FluentFTP")]
    public class FTP
    {

        #region METHOD-STRING | host, userName, password
        private string _Host;
        private string _UserName;
        private string _Password;
        #endregion

        #region METHOD-FTP | FTP
        /// <summary>
        /// Создание конструкции для управления FTP
        /// </summary>
        /// <param name="Host">Полная ссылка до удалённого файла на FTP сервере (например: ftp://0.0.0.0:21/file.exmp)</param>
        /// <param name="UserName">Вход: Имя пользователя (например: exampleName)</param>
        /// <param name="Password">Вход: Пароль пользователя (например: Ex@mpleP@3w0rd)</param>
        /// <exception cref="Exceptions.NullField">Нулевое поле</exception>
        public FTP(string Host, string UserName, string Password)
        {
            if (string.IsNullOrEmpty(Host) || string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(Password)) throw new Exceptions.NullField("FTP -> (string Host || string UserNmae || string Passowrd)");
            _Host = Host;
            _UserName = UserName;
            _Password = Password;
        }
        #endregion

        #region METHOD-VOID | Upload
        /// <summary>
        /// Загрузка локального файла на FTP сервер
        /// </summary>
        /// <param name="LocalFullPath">Путь до файла на локальном компьютере (например: C:\path\to\file.exmp или: file.exmp)</param>
        /// <exception cref="Exceptions.NullField">Нулевое поле</exception>
        /// <exception cref="Exceptions.FileNotExists">Файл не существует</exception>
        public void Upload(string LocalFullPath)
        {
            if (string.IsNullOrEmpty(LocalFullPath)) throw new Exceptions.NullField("FTP.Upload -> string LocalFullPath");
            if (!FileManager.File.Exists(LocalFullPath)) throw new Exceptions.FileNotExists("FTP.Upload -> LocalFullPath", LocalFullPath);

            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(_Host);

            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = new NetworkCredential(_UserName, _Password);
            request.UsePassive = true;
            request.UseBinary = true;
            request.KeepAlive = false;

            using (Stream inputStream = File.OpenRead(LocalFullPath))
            using (Stream outputStream = request.GetRequestStream())
            {
                byte[] buffer = new byte[1024];
                int bytesRead = 0;
                while ((bytesRead = inputStream.Read(buffer, 0, buffer.Length)) > 0) outputStream.Write(buffer, 0, bytesRead);
            }
        }
        #endregion

        #region METHOD-VOID | Download
        /// <summary>
        /// Загрузка файла с FTP сервера в локальный файл
        /// </summary>
        /// <param name="LocalPath">Полный путь до файла который будет сохранён на локальном компьютере (например: C:\path\to\file.exmp; или: file.exmp)</param>
        /// <exception cref="Exceptions.NullField">Нулевое поле</exception>
        public void Download(string LocalPath)
        {
            if (string.IsNullOrEmpty(LocalPath)) throw new Exceptions.NullField("FTP.Download -> string LocalPath");
            using (WebClient client = new WebClient())
            {
                client.Credentials = new NetworkCredential(_UserName, _Password);
                client.DownloadFile(_Host, LocalPath);
            }
        }
        #endregion

        #region METHOD-VOID | Delete
        /// <summary>
        /// Удаление файла на FTP сервере
        /// </summary>
        public void Delete()
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(_Host);
            request.Method = WebRequestMethods.Ftp.DeleteFile;
            request.Credentials = new NetworkCredential(_UserName, _Password);
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            response.Close();
        }
        #endregion

        #region METHOD-BOOL | Exists
        /// <summary>
        /// Проверка наличия файла на FTP сервере
        /// </summary>
        /// <returns>true - если файл существует, false - если файл отсутствует.</returns>
        public bool Exists()
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(_Host);
            request.Credentials = new NetworkCredential(_UserName, _Password);
            request.Method = WebRequestMethods.Ftp.GetDateTimestamp;

#pragma warning disable CS8600,CS8602
            try { using (FtpWebResponse response = (FtpWebResponse)request.GetResponse()) return true; }
            catch (WebException ex) when (((FtpWebResponse)ex.Response).StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable) { return false; }
#pragma warning restore CS8600,CS8602
        }
        #endregion

    }
    #endregion

}
