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
        private IWavePlayer? _OutputDevice;
        private MediaFoundationReader? _AudioFile;
        private string? _CurrentFile;
        private float? _Speed = 1.0f;

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
        /// <param name="PathFile">Полный путь до музыкального файла</param>
        /// <param name="AutoStart">Автоматически запустить файл?</param>
        public Music(string PathFile, bool AutoStart = false)
        {
            if (string.IsNullOrEmpty(PathFile)) throw new Exceptions.NullField("Music -> string PathFile");
            if (!File.Exists(PathFile)) throw new Exceptions.FileNotExists("Music -> PathFile", PathFile);
            Load(PathFile);
            if (AutoStart)
            {
                Play();
            }
        }
        #endregion

        #region METHOD-VOID | Load
        /// <summary>
        /// Загрузка музыкального файла
        /// </summary>
        /// <param name="PathFile">Полный путь до музыкального файла</param>
        /// <exception cref="Exceptions.NullField">Нулевое поле</exception>
        /// <exception cref="Exceptions.FileNotExists">Файл не существует</exception>
        public void Load(string PathFile)
        {
            if (string.IsNullOrEmpty(PathFile)) throw new Exceptions.NullField("Music.Load -> string PathFile");
            if (!FileManager.File.Exists(PathFile)) throw new Exceptions.FileNotExists("Music.Load -> PathFile", PathFile);

            _OutputDevice?.Stop();
            _OutputDevice?.Dispose();
            _AudioFile?.Dispose();

            _CurrentFile = PathFile;
            _AudioFile = new MediaFoundationReader(PathFile);
            _OutputDevice = new WaveOutEvent();
            _OutputDevice.Init(_AudioFile);

            _OutputDevice.PlaybackStopped += (sender, e) => MusicFinished?.Invoke();
        }
        #endregion

        #region METHOD-VOID | Play
        /// <summary>
        /// Воспроизведение музыкального файла из конструкции
        /// </summary>
        public void Play()
        {
            _OutputDevice?.Play();
            MusicStarted?.Invoke();
        }
        #endregion

        #region METHOD-VOID | Stop
        /// <summary>
        /// Остановка музыкального файла из конструкции
        /// </summary>
        public void Stop()
        {
            _OutputDevice?.Stop();
            MusicStopped?.Invoke();
        }
        #endregion

        #region METHOD-VOID | Pause
        /// <summary>
        /// Приостановка музыкального файла из конструкции
        /// </summary>
        public void Pause()
        {
            _OutputDevice?.Pause();
            MusicPaused?.Invoke();
        }
        #endregion

        #region METHOD-VOID | SetVolume
        /// <summary>
        /// Установка громкости музыкальной конструкции
        /// </summary>
        /// <param name="Volume">Громкость от 0 до 100</param>
        /// <exception cref="Exceptions.NullField">Нулевое поле</exception>
        /// <exception cref="Exceptions.OutOfBounds">Выход за рамки границ</exception>
        public void SetVolume(int Volume)
        {
            if (_AudioFile == null || _OutputDevice == null) throw new Exceptions.NullField("Music.SetVolume -> (MediaFoundationReader? _AudioFile || IWavePlayer? _OutputDevice)");
            if (Volume < 0 || Volume > 100) throw new Exceptions.OutOfBounds("Music.SetVolume -> (Volume < 0 || Volume > 100)");
            _OutputDevice.Volume = Volume / 100.0f;
            VolumeChanged?.Invoke(_OutputDevice.Volume);
        }
        #endregion

        #region METHOD-FLOAT | GetVolume
        /// <summary>
        /// Получение текущей громкости музыкальной конструкции
        /// </summary>
        /// <returns>Громкость от 0 до 1</returns>
        public float? GetVolume() => _OutputDevice?.Volume ?? 0.0f;
        #endregion

        #region METHOD-VOID | SetSpeed
        /// <summary>
        /// Установка скорости воспроизведения музыкальной конструкции
        /// </summary>
        /// <param name="Speed">Скорость от 0.5 до 2.0</param>
        /// <exception cref="Exceptions.NullField">Нулевое поле</exception>
        /// <exception cref="Exceptions.OutOfBounds">Выход за рамки границ</exception>
        public void SetSpeed(float Speed)
        {
            if (_AudioFile == null) throw new Exceptions.NullField("Music.SetSpeed -> MediaFoundationReader? _AudioFile");
            if (Speed < 0.5f || Speed > 2.0f) throw new Exceptions.OutOfBounds("Music.SetSpeed -> (Speed < 0.5f || Speed > 2.0f)");
            _Speed = Speed;
            _AudioFile.Seek(0, SeekOrigin.Begin);
            SpeedChanged?.Invoke(Speed);
        }
        #endregion

        #region METHOD-FLOAT | GetSpeed
        /// <summary>
        /// Получение текущей скорости воспроизведения музыкальной конструкции
        /// </summary>
        /// <returns>Скорость воспроизведения</returns>
        public float? GetSpeed() => _Speed;
        #endregion

        #region METHOD-TIMESPAN | GetDuration
        /// <summary>
        /// Получение длительности музыкального файла из конструкции
        /// </summary>
        /// <returns>Длительность музыкального файла</returns>
        public TimeSpan? GetDuration() => _AudioFile?.TotalTime ?? TimeSpan.Zero;
        #endregion

        #region METHOD-VOID | Seek
        /// <summary>
        /// Установка позиции в музыкальной конструкции
        /// </summary>
        /// <param name="Position">Позиция</param>
        public void Seek(TimeSpan Position)
        {
            if (_AudioFile == null) throw new Exceptions.NullField("Music.Seek -> MediaFoundationReader? _AudioFile");
            if (Position < TimeSpan.Zero || Position > _AudioFile.TotalTime) throw new Exceptions.OutOfBounds("Music.Seek -> (Position < TimeSpan.Zero || Position > _AudioFile.TotalTime)");
            _AudioFile.CurrentTime = Position;
        }
        #endregion

        #region METHOD-TIMESPAN | GetPosition
        /// <summary>
        /// Получение текущей позиции в музыкальной конструкции
        /// </summary>
        /// <returns>Позиция в музыкальной конструкции</returns>
        public TimeSpan? GetPosition() => _AudioFile?.CurrentTime ?? TimeSpan.Zero;
        #endregion

        #region METHOD-VOID | Repeat
        /// <summary>
        /// Повтор песни
        /// </summary>
        /// <param name="Turn">true или false. true - включить повтор, false - выключить повтор</param>
        public void Repeat(bool Turn)
        {
            if (_OutputDevice == null) return;
            if (_AudioFile == null) return;
            if (Turn)
            {
                _AudioFile.Position = 0;
                _OutputDevice.PlaybackStopped += (s, e) => { _AudioFile.Position = 0; _OutputDevice.Play(); };
            }
            else
            {
                _OutputDevice.PlaybackStopped -= (s, e) => { _AudioFile.Position = 0; _OutputDevice.Play(); };
            }
        }
        #endregion

        #region METHOD-STRING | GetPath
        /// <summary>
        /// Получение текущего музыкального файла (Путь)
        /// </summary>
        /// <returns>Путь до музыкального файла</returns>
        public string? GetPath() => _CurrentFile;
        #endregion
    }
    #endregion
}
