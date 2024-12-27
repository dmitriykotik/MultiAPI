using System;
using System.IO;
using NAudio.Wave;
using TagLib;

namespace MultiAPI
{
    #region CLASS | Music
    /// <summary>
    /// Действия с музыкальными файлами
    /// </summary>
    public class Music
    {
        private IWavePlayer _outputDevice;
        private MediaFoundationReader _audioFile;
        private string _currentFile;

        #region METHOD-Music | Music
        /// <summary>
        /// Определение конструкции. ( Music nameVar = new Music("C:\\Path\\To\\Music.mp3") )
        /// </summary>
        /// <param name="pathFile">Полный путь до музыкального файла</param>
        /// <param name="autoStart">Автоматически запустить файл?</param>
        public Music(string pathFile, bool autoStart = false)
        {
            Load(pathFile);
            if (autoStart)
            {
                Play();
            }
        }
        #endregion

        #region METHOD-VOID | Load
        /// <summary>
        /// Загрузка музыкального файла
        /// </summary>
        /// <param name="pathFile">Полный путь до музыкального файла</param>
        public void Load(string pathFile)
        {
            if (string.IsNullOrEmpty(pathFile)) throw new Exception("0x00003");
            if (!System.IO.File.Exists(pathFile)) throw new FileNotFoundException("File not found.", pathFile);

            _outputDevice?.Stop();
            _outputDevice?.Dispose();
            _audioFile?.Dispose();

            _currentFile = pathFile;
            _audioFile = new MediaFoundationReader(pathFile);
            _outputDevice = new WaveOutEvent();
            _outputDevice.Init(_audioFile);
        }
        #endregion

        #region METHOD-VOID | Play
        /// <summary>
        /// Воспроизведение музыкального файла из конструкции
        /// </summary>
        public void Play() => _outputDevice?.Play();
        #endregion

        #region METHOD-VOID | Stop
        /// <summary>
        /// Остановка музыкального файла из конструкции
        /// </summary>
        public void Stop() => _outputDevice?.Stop();
        #endregion

        #region METHOD-VOID | Pause
        /// <summary>
        /// Приостановка музыкального файла из конструкции
        /// </summary>
        public void Pause() => _outputDevice?.Pause();
        #endregion

        #region METHOD-VOID | SetVolume
        /// <summary>
        /// Установка громкости музыкальной конструкции
        /// </summary>
        /// <param name="volume">Громкость</param>
        public void SetVolume(float volume)
        {
            if (_audioFile == null || _outputDevice == null) throw new Exception("Audio not loaded.");
            if (volume < 0.0f || volume > 1.0f) throw new ArgumentOutOfRangeException(nameof(volume), "Volume must be between 0.0 and 1.0.");
            _outputDevice.Volume = volume;
        }
        #endregion

        #region METHOD-FLOAT | GetVolume
        /// <summary>
        /// Получение текущей громкости музыкальной конструкции
        /// </summary>
        /// <returns></returns>
        public float GetVolume() => _outputDevice?.Volume ?? 0.0f;
        #endregion

        #region METHOD-TIMESPAN | GetDuration
        /// <summary>
        /// Получение длительности музыкального файла из конструкции
        /// </summary>
        /// <returns>Длительность музыкального файла</returns>
        public TimeSpan GetDuration() => _audioFile?.TotalTime ?? TimeSpan.Zero;
        #endregion

        #region METHOD-VOID | Seek
        /// <summary>
        /// Установка позиции в музыкальной конструкции
        /// </summary>
        /// <param name="position">Позиция</param>
        public void Seek(TimeSpan position)
        {
            if (_audioFile == null) throw new Exception("Audio not loaded.");
            if (position < TimeSpan.Zero || position > _audioFile.TotalTime)
                throw new ArgumentOutOfRangeException(nameof(position), "Position is out of range.");
            _audioFile.CurrentTime = position;
        }
        #endregion

        #region METHOD-TIMESPAN | GetPosition
        /// <summary>
        /// Получение текущей позиции в музыкальной конструкции
        /// </summary>
        /// <returns>Позиция в музыкальной конструкции</returns>
        public TimeSpan GetPosition() => _audioFile?.CurrentTime ?? TimeSpan.Zero;
        #endregion

        #region METHOD-VOID | Repeat
        /// <summary>
        /// Повтор песни
        /// </summary>
        /// <param name="turn">true или false. true - включить повтор, false - выключить повтор</param>
        public void Repeat(bool turn)
        {
            if (_audioFile == null) return;
            if (turn)
            {
                _audioFile.Position = 0;
                _outputDevice.PlaybackStopped += (s, e) => { _audioFile.Position = 0; _outputDevice.Play(); };
            }
            else
            {
                _outputDevice.PlaybackStopped -= (s, e) => { _audioFile.Position = 0; _outputDevice.Play(); };
            }
        }
        #endregion

        #region METHOD-STRING | GetPath
        /// <summary>
        /// Получение текущего музыкального файла (Путь)
        /// </summary>
        /// <returns>Путь до музыкального файла</returns>
        public string GetPath() => _currentFile;
        #endregion
    }
    #endregion
}
