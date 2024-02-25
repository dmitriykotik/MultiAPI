﻿using WMPLib;

/* 
  =================- INFO -===================
 * File:         | Music.cs
 * Class:        | Music
 * Project:      | MultiAPI
 * Author:       | Plufik
 * Version:      | 0.1.1.32
 * VerType:      | major_version.minor_version.patch_version.builds
 * Main file:    | Main.cs
 * [OPEN SOURCE] | +True
 * [CONSTRUCTOR] | +True
  ============================================
 */

namespace MultiAPI
{
    #region CLASS | Music
    /// <summary>
    /// Действия с музыкальными файлами
    /// </summary>
    public class Music
    {
        #region WindowsMediaPlayer | musicPlayer
        /// <summary>
        /// Музыкальная конструкция
        /// </summary>
        private static WindowsMediaPlayer musicPlayer = new WindowsMediaPlayer();
        #endregion

        #region METHOD-Music | Music
        /// <summary>
        /// Определение конструкции. ( Music nameVar = new Music("C:\\Path\\To\\Music.mp3") )
        /// </summary>
        /// <param name="pathFile">Полный путь до музыкального файла</param>
        public Music(string pathFile) => musicPlayer.URL = pathFile;
        #endregion

        #region METHOD-VOID | play
        /// <summary>
        /// Воспроизведение музыкального файла из конструкции
        /// </summary>
        public void play() => musicPlayer.controls.play();
        #endregion

        #region METHOD-VOID | stop
        /// <summary>
        /// Остановка музыкального файла из конструкции
        /// </summary>
        public void stop() => musicPlayer.controls.stop();
        #endregion

        #region METHOD-VOID | pause
        /// <summary>
        /// Приостановка музыкального файла из конструкции
        /// </summary>
        public void pause() => musicPlayer.controls.pause();
        #endregion 

        #region METHOD-VOID | setVolume
        /// <summary>
        /// Установка громкости музыкальной конструкции
        /// </summary>
        /// <param name="volume">Громкость</param>
        public void setVolume(int volume) => musicPlayer.settings.volume = volume;
        #endregion

        #region METHOD-INT | getVolume
        /// <summary>
        /// Получение текущей громкости музыкальной конструкции
        /// </summary>
        /// <returns></returns>
        public int getVolume() => musicPlayer.settings.volume;
        #endregion

        #region METHOD-DOUBLE | getDuration
        /// <summary>
        /// Получение длительности музыкального файла из конструкции
        /// </summary>
        /// <returns>Длительность музыкального файла</returns>
        public double getDuration() => musicPlayer.currentMedia.duration;
        #endregion

        #region METHOD-VOID | setPosition
        /// <summary>
        /// Установка позиции в музыкальной конструкции
        /// </summary>
        /// <param name="position">Позиция</param>
        public void setPosition(double position) => musicPlayer.controls.currentPosition = position;
        #endregion

        #region METHOD-DOUBLE | getPosition
        /// <summary>
        /// Получение текущей позиции в музыкальной конструкции
        /// </summary>
        /// <returns>Позиция в музыкальной конструкции</returns>
        public double getPosition() => musicPlayer.controls.currentPosition;
        #endregion

        #region METHOD-VOID | updatePath
        /// <summary>
        /// Изменение музыкального файла в конструкции
        /// </summary>
        /// <param name="pathFile">Полный путь до музыкального файла</param>
        public void updatePath(string pathFile) => musicPlayer.URL = pathFile;
        #endregion

    }
    #endregion
}
