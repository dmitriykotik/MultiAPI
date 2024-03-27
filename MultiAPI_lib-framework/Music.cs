using System;
using WMPLib;

/* 
  =================- INFO -===================
 * File:         | Music.cs
 * Class:        | Music
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
        public Music(string pathFile, bool autoStart = false)
        {
            if (string.IsNullOrEmpty(pathFile)) throw new Exception("0x00003");
            musicPlayer.URL = pathFile;
            musicPlayer.settings.autoStart = autoStart;
        }
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
        public void setVolume(int volume) 
        { 
            if (volume < 0 || volume > 100) throw new Exception("0x00006");
            if (string.IsNullOrEmpty(Convert.ToString(volume))) throw new Exception("0x00003");
            musicPlayer.settings.volume = volume; 
        }
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
        public void setPosition(double position)
        {
            if (position < 0.0 || position > 1.0) throw new Exception("0x00006");
            if (string.IsNullOrEmpty(Convert.ToString(position))) throw new Exception("0x00003");
            musicPlayer.controls.currentPosition = position;
        }
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
        public void updatePath(string pathFile)
        {
            if (string.IsNullOrEmpty(pathFile)) throw new Exception("0x00003");
            musicPlayer.URL = pathFile;
        }
        #endregion

        #region METHOD-STRING | getPath
        /// <summary>
        /// Получение текущего музыкального файла (Путь)
        /// </summary>
        /// <returns>Путь до музыкального файла</returns>
        public string getPath() => musicPlayer.URL;
        #endregion

        #region METHOD-VOID | repeat
        /// <summary>
        /// Повтор песни
        /// </summary>
        /// <param name="turn">true или false. true - включить повтор, false - выключить повтор</param>
        public void repeat(bool turn) => musicPlayer.settings.setMode("loop", turn);
        #endregion

    }
    #endregion
}