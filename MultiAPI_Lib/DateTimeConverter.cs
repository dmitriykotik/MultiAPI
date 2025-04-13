using System.Globalization;

/* 
  =================- INFO -===================
 * File:         | DateTimeConverter.cs
 * Class:        | DateTimeConverter
 * Project:      | MultiAPI
 * Author:       | dmitriykotik
 * [OPEN SOURCE] | +True
 * [CONSTRUCTOR] | -False
  ============================================
 */

namespace MultiAPI
{
    #region  CLASS | DateTimeConvert
    /// <summary>
    /// Класс для перевода даты
    /// </summary>
    public static class DateTimeConvert
    { 
        #region METHOD-LONG | ToUnixTimestamp
        /// <summary>
        /// Перевести дату в Unix дату
        /// </summary>
        /// <param name="DTime">Дата</param>
        /// <returns>Дата формата Unix</returns>
        public static long ToUnixTimestamp(DateTime DTime)
        {
            var utcDateTime = DTime.ToUniversalTime();
            var unixTime = (long)(utcDateTime - new DateTime(1970, 1, 1)).TotalSeconds;
            return unixTime;
        }
        #endregion

        #region METHOD-DATETIME | FromUnixTimestamp
        /// <summary>
        /// Перевести Unix дату в обычную
        /// </summary>
        /// <param name="UnixTimestamp">Unix дата</param>
        /// <returns>Дата</returns>
        public static DateTime FromUnixTimestamp(long UnixTimestamp)
        {
            var dateTime = new DateTime(1970, 1, 1).AddSeconds(UnixTimestamp);
            return DateTime.SpecifyKind(dateTime, DateTimeKind.Utc).ToLocalTime();
        }
        #endregion

        #region METHOD-STRING | ToIso8601
        /// <summary>
        /// Перевести дату в формат Iso8601
        /// </summary>
        /// <param name="DTime">Дата</param>
        /// <returns>Дата формата Iso8601</returns>
        public static string ToIso8601(DateTime DTime) => DTime.ToString("O", CultureInfo.InvariantCulture);
        #endregion

        #region METHOD-DATETIME | FromIso8601
        /// <summary>
        /// Перевести из даты формата Iso8601 в обычную
        /// </summary>
        /// <param name="IsoString">Дата формата Iso8601</param>
        /// <returns>Дата</returns>
        public static DateTime FromIso8601(string IsoString) => DateTime.Parse(IsoString, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind);
        #endregion

        #region METHOD-TIMESPAN | TimeAgo
        /// <summary>
        /// Расчёт времени от даты то текущей даты
        /// </summary>
        /// <param name="DTime">Дата</param>
        /// <returns>Прошедшее время</returns>
        public static TimeSpan TimeAgo(DateTime DTime) => DateTime.Now - DTime;
        #endregion
    }
    #endregion
}