using System.Net.NetworkInformation;

/* 
  =================- INFO -===================
 * File:         | Internet.cs
 * Class:        | Internet
 * Project:      | MultiAPI
 * Author:       | Plufik
 * Version:      | 0.0.0.0
 * VerType:      | major_version.minor_version.patch_version.builds
 * Main file:    | Main.cs
 * [OPEN SOURCE] | +True
 * [CONSTRUCTOR] | -False
  ============================================
 */

namespace MultiAPI
{
    /// <summary>
    /// Проверки в интернете
    /// </summary>
    public static class Internet
    {

        #region METHOD-BOOL | TestConnection
        /// <summary>
        /// Проверка наличия интернета
        /// </summary>
        /// <returns>true - если интернет есть, false - если интернета нету</returns>
        public static bool TestConnection()
        {
            try
            {
                using (var ping = new Ping())
                {
                    var result = ping.Send("google.com", 1000);
                    return result.Status == IPStatus.Success;
                }
            }
            catch { return false; }
        }
        #endregion

        #region METHOD-BOOL | ping
        /// <summary>
        /// Проверка доступности сервера или сайта (Может быть не точным, если у пользователя нет интернета)
        /// </summary>
        /// <param name="url">Адрес сервера/сайта</param>
        /// <returns>true - если сервер или сайт доступен, false - если сервер или сайт не доступен</returns>
        public static bool ping(string url)
        {
            try
            {
                using (var ping = new Ping())
                {
                    var result = ping.Send(url, 1000);
                    return result.Status == IPStatus.Success;
                }
            }
            catch { return false; }
        }
        #endregion

    }
}
