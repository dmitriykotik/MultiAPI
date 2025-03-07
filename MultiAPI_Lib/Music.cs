using NAudio.Wave;

/* 
  =================- INFO -===================
 * File:         | Music.cs
 * Class:        | Music
 * Project:      | MultiAPI
 * Author:       | dmitriykotik
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
        #region FIELD-Music | Music
        private IWavePlayer? _outputDevice;
        private MediaFoundationReader? _audioFile;
        private string? _currentFile;
        private float? _speed = 1.0f;

        /// <summary>
        /// Если громкость была изменена
        /// </summary>
        public event Action<float>? VolumeChanged;
        /// <summary>
        /// Если скорость была изменена
        /// </summary>
        public event Action<float>? SpeedChanged;
        /// <summary>
        /// Если музыкальный файл был воспроизведен
        /// </summary>
        public event Action? MusicStarted;
        /// <summary>
        /// Если музыкальный файл был приостановлен
        /// </summary>
        public event Action? MusicPaused;
        /// <summary>
        /// Если музыкальный файл был остановлен
        /// </summary>
        public event Action? MusicStopped;
        /// <summary>
        /// Если музыкальный файл закончил воспроизведение
        /// </summary>
        public event Action? MusicFinished;
        #endregion

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
            if (!File.Exists(pathFile)) throw new Exception("0x00004");

            _outputDevice?.Stop();
            _outputDevice?.Dispose();
            _audioFile?.Dispose();

            _currentFile = pathFile;
            _audioFile = new MediaFoundationReader(pathFile);
            _outputDevice = new WaveOutEvent();
            _outputDevice.Init(_audioFile);

            _outputDevice.PlaybackStopped += (sender, e) =>
            {
                MusicFinished?.Invoke();
            };
        }
        #endregion

        #region METHOD-VOID | Play
        /// <summary>
        /// Воспроизведение музыкального файла из конструкции
        /// </summary>
        public void Play()
        {
            _outputDevice?.Play();
            MusicStarted?.Invoke();
        }
        #endregion

        #region METHOD-VOID | Stop
        /// <summary>
        /// Остановка музыкального файла из конструкции
        /// </summary>
        public void Stop()
        {
            _outputDevice?.Stop();
            MusicStopped?.Invoke();
        }
        #endregion

        #region METHOD-VOID | Pause
        /// <summary>
        /// Приостановка музыкального файла из конструкции
        /// </summary>
        public void Pause()
        {
            _outputDevice?.Pause();
            MusicPaused?.Invoke();
        }
        #endregion

        #region METHOD-VOID | SetVolume
        /// <summary>
        /// Установка громкости музыкальной конструкции
        /// </summary>
        /// <param name="volume">Громкость от 0 до 100</param>
        public void SetVolume(int volume)
        {
            if (_audioFile == null || _outputDevice == null) throw new Exception("Поле или значение не может быть пустым");
            if (volume < 0 || volume > 100) throw new Exception("0x00006");
            _outputDevice.Volume = volume / 100.0f;
            VolumeChanged?.Invoke(_outputDevice.Volume);
        }
        #endregion

        #region METHOD-FLOAT | GetVolume
        /// <summary>
        /// Получение текущей громкости музыкальной конструкции
        /// </summary>
        /// <returns>Громкость от 0 до 1</returns>
        public float? GetVolume() => _outputDevice?.Volume ?? 0.0f;
        #endregion

        #region METHOD-VOID | SetSpeed
        /// <summary>
        /// Установка скорости воспроизведения музыкальной конструкции
        /// </summary>
        /// <param name="speed">Скорость от 0.5 до 2.0</param>
        public void SetSpeed(float speed)
        {
            if (_audioFile == null) throw new Exception("Поле или значение не может быть пустым");
            if (speed < 0.5f || speed > 2.0f) throw new Exception("0x00006");
            _speed = speed;
            _audioFile.Seek(0, SeekOrigin.Begin);
            SpeedChanged?.Invoke(speed);
        }
        #endregion

        #region METHOD-FLOAT | GetSpeed
        /// <summary>
        /// Получение текущей скорости воспроизведения музыкальной конструкции
        /// </summary>
        /// <returns>Скорость воспроизведения</returns>
        public float? GetSpeed() => _speed;
        #endregion

        #region METHOD-TIMESPAN | GetDuration
        /// <summary>
        /// Получение длительности музыкального файла из конструкции
        /// </summary>
        /// <returns>Длительность музыкального файла</returns>
        public TimeSpan? GetDuration() => _audioFile?.TotalTime ?? TimeSpan.Zero;
        #endregion

        #region METHOD-VOID | Seek
        /// <summary>
        /// Установка позиции в музыкальной конструкции
        /// </summary>
        /// <param name="position">Позиция</param>
        public void Seek(TimeSpan position)
        {
            if (_audioFile == null) throw new Exception("0x00003");
            if (position < TimeSpan.Zero || position > _audioFile.TotalTime) throw new Exception("0x00006");
            _audioFile.CurrentTime = position;
        }
        #endregion

        #region METHOD-TIMESPAN | GetPosition
        /// <summary>
        /// Получение текущей позиции в музыкальной конструкции
        /// </summary>
        /// <returns>Позиция в музыкальной конструкции</returns>
        public TimeSpan? GetPosition() => _audioFile?.CurrentTime ?? TimeSpan.Zero;
        #endregion

        #region METHOD-VOID | Repeat
        /// <summary>
        /// Повтор песни
        /// </summary>
        /// <param name="turn">true или false. true - включить повтор, false - выключить повтор</param>
        public void Repeat(bool turn)
        {
            if (_outputDevice == null) return;
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
        public string? GetPath() => _currentFile;
        #endregion
    }
    #endregion
}
