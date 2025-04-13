using System.Security.Principal;

/* 
  =================- INFO -===================
 * File:         | OS.cs
 * Class:        | OS
 * Project:      | MultiAPI
 * Author:       | dmitriykotik
 * [OPEN SOURCE] | +True
 * [CONSTRUCTOR] | -False
  ============================================
 */

namespace MultiAPI
{
    #region CLASS | OS
    /// <summary>
    /// Действия с операционной системой
    /// </summary>
    public static class OS
    {
        #region ENUM | OSTypes
        /// <summary>
        /// Типы операционных систем
        /// </summary>
        public enum OSTypes
        {
            /// <summary>
            /// Windows
            /// </summary>
            Windows,
            /// <summary>
            /// Linux
            /// </summary>
            Linux,
            /// <summary>
            /// MacOS
            /// </summary>
            MacOS,
            /// <summary>
            /// Android
            /// </summary>
            Android,
            /// <summary>
            /// Browser
            /// </summary>
            Browser,
            /// <summary>
            /// FreeBSD
            /// </summary>
            FreeBSD,
            /// <summary>
            /// IOS
            /// </summary>
            IOS,
            /// <summary>
            /// TvOS
            /// </summary>
            TvOS,
            /// <summary>
            /// WatchOS
            /// </summary>
            WatchOS,
            /// <summary>
            /// Other
            /// </summary>
            Other
        }
        #endregion

        #region METHOD-OSTYPES | Get
        /// <summary>
        /// Получить тип операционной системы
        /// </summary>
        /// <returns>Тип операционной системы</returns>
        public static OSTypes Get() => OperatingSystem.IsAndroid() ? OSTypes.Android : OperatingSystem.IsBrowser() ? OSTypes.Browser : OperatingSystem.IsFreeBSD() ? OSTypes.FreeBSD : 
            OperatingSystem.IsIOS() ? OSTypes.IOS : OperatingSystem.IsLinux() ? OSTypes.Linux : OperatingSystem.IsMacOS() ? OSTypes.MacOS : OperatingSystem.IsTvOS() ? OSTypes.TvOS :
            OperatingSystem.IsWatchOS() ? OSTypes.WatchOS : OperatingSystem.IsWindows() ? OSTypes.Windows : OSTypes.Other;
        #endregion

        #region METHOD-BOOL | isSupported
        /// <summary>
        /// Проверка поддержки операционной системы по установленному списку
        /// </summary>
        /// <param name="SupportedOS">Список поддерживаемых ОС</param>
        /// <returns>true - Если текущая система входит в указанный список, иначе false</returns>
        public static bool isSupported(OSTypes[] SupportedOS) => SupportedOS.Contains(Get());
        #endregion

        #region METHOD-STRING | GetUser
        /// <summary>
        /// Получить имя пользователя (Поддержка только Windows, Linux, MacOS)
        /// </summary>
        /// <returns>Имя пользователя</returns>
        public static string? GetUser()
        {
            if (Get() == OSTypes.Windows || Get() == OSTypes.Linux || Get() == OSTypes.MacOS) return Environment.UserName;
            else return null;
        }
        #endregion

        #region METHOD-STRING | GetHost
        /// <summary>
        /// Получить имя хоста (Поддержка только Windows, Linux, MacOS)
        /// </summary>
        /// <returns>Имя хоста</returns>
        public static string? GetHost()
        {
            if (Get() == OSTypes.Windows || Get() == OSTypes.Linux || Get() == OSTypes.MacOS) return Environment.MachineName;
            else return null;
        }
        #endregion

        #region METHOD-BOOL | IsSuperUser
        /// <summary>
        /// Проверить является ли пользователь администратором
        /// </summary>
        /// <returns>true - Если пользователь администратор, иначе false</returns>
        internal static bool? isSuperUser()
        {
            if (Get() == OSTypes.Windows)
            {
#pragma warning disable CA1416
                using (var identity = WindowsIdentity.GetCurrent())
                {
                    var principal = new WindowsPrincipal(identity);
                    return principal.IsInRole(WindowsBuiltInRole.Administrator);
                }
#pragma warning restore CA1416
            }
            else return Environment.UserName == "root";
        }
        #endregion
    }
    #endregion
}
