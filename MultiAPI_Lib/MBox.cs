using System.Runtime.InteropServices;

/* 
  =================- INFO -===================
 * File:         | MBox.cs
 * Class:        | MBox
 * Project:      | MultiAPI
 * Author:       | dmitriykotik
 * [OPEN SOURCE] | +True
 * [CONSTRUCTOR] | -False
  ============================================
 */

namespace MultiAPI
{
    #region CLASS | MBox
    /// <summary>
    /// Класс для создания всплывающих окон*
    /// * - Поддерживается ТОЛЬКО на Windows
    /// </summary>
    public static class MBox
    {
        #region DllImport - MessageBox
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int MessageBox(IntPtr hWnd, string lpText, string lpCaption, uint uType);
        #endregion

        #region  METHOD-RESULT | Show
        /// <summary>
        /// Создать всплывающее окно
        /// </summary>
        /// <param name="Content">Содержимое</param>
        /// <param name="Title">Заголовок</param>
        /// <param name="Button">Кнопки</param>
        /// <param name="Icon">Иконка</param>
        /// <param name="Modal">Модальность</param>
        /// <param name="Default">Фокус кнопки</param>
        /// <param name="hWnd">Окно</param>
        /// <returns>Результат (При закрытии окна возвращает: Cancel)</returns>
        public static Result Show(
            string Content,
            string Title,
            Buttons Button = Buttons.Ok,
            Icons Icon = Icons.Information,
            Modals Modal = Modals.Application,
            DefaultSelect Default = DefaultSelect.Button1,
            IntPtr? hWnd = null)
        {
            if (!OS.isSupported([OS.OSTypes.Windows])) throw new Exceptions.OSNotSupported("MBox.Show -> OS.isSupported", [OS.OSTypes.Windows]);
            uint flags = (uint)Button | (uint)Icon | (uint)Modal | (uint)Default;
            return (Result)MessageBox(hWnd ?? IntPtr.Zero, Content, Title, flags);
        }
        #endregion

        #region ENUM | Buttons
        /// <summary>
        /// Кнопки для всплывающего окна
        /// </summary>
        public enum Buttons
        {
            /// <summary>
            /// Ok
            /// </summary>
            Ok = 0x00000000,
            /// <summary>
            /// Ok, Cancel
            /// </summary>
            OkCancel = 0x00000001,
            /// <summary>
            /// Abort, Retry, Ignore
            /// </summary>
            AbortRetryIgnore = 0x00000002,
            /// <summary>
            /// Yes, No, Cancel
            /// </summary>
            YesNoCancel = 0x00000003,
            /// <summary>
            /// Yes, No
            /// </summary>
            YesNo = 0x00000004,
            /// <summary>
            /// Retry, Cancel
            /// </summary>
            RetryCancel = 0x00000005,
            /// <summary>
            /// Cancel, Try, Continue
            /// </summary>
            CancelTryContinue = 0x00000006
        }
        #endregion

        #region ENUM | Icons
        /// <summary>
        /// Иконки для всплывающего окна
        /// </summary>
        public enum Icons
        {
            /// <summary>
            /// Ошибка
            /// </summary>
            Error = 0x00000010,
            /// <summary>
            /// Вопрос
            /// </summary>
            Question = 0x00000020,
            /// <summary>
            /// Предупреждение
            /// </summary>
            Warning = 0x00000030,
            /// <summary>
            /// Информация
            /// </summary>
            Information = 0x00000040
        }
        #endregion

        #region ENUM | DefaultSelect
        /// <summary>
        /// Фокус на определённую кнопку
        /// </summary>
        public enum DefaultSelect
        {
            /// <summary>
            /// Фокус на первую кнопку
            /// </summary>
            Button1 = 0x00000000,
            /// <summary>
            /// Фокус на вторую кнопку (Если есть)
            /// </summary>
            Button2 = 0x00000100,
            /// <summary>
            /// Фокус на третью кнопку (Если есть)
            /// </summary>
            Button3 = 0x00000200
        }
        #endregion

        #region ENUM | Modals
        /// <summary>
        /// Модальность
        /// </summary>
        public enum Modals
        {
            /// <summary>
            /// Блокировка окна приложения
            /// </summary>
            Application = 0x00000000,
            /// <summary>
            /// Поверх всех окон
            /// </summary>
            System = 0x00001000,
            /// <summary>
            /// Блокирует все окна процесса приложения
            /// </summary>
            Task = 0x00002000
        }
        #endregion

        #region ENUM | Result
        /// <summary>
        /// Результат всплывающего окна
        /// </summary>
        public enum Result
        {
            /// <summary>
            /// Ok
            /// </summary>
            Ok = 1,
            /// <summary>
            /// Cancel
            /// </summary>
            Cancel = 2,
            /// <summary>
            /// Abort
            /// </summary>
            Abort = 3,
            /// <summary>
            /// Retry
            /// </summary>
            Retry = 4,
            /// <summary>
            /// Ignore
            /// </summary>
            Ignore = 5,
            /// <summary>
            /// Yes
            /// </summary>
            Yes = 6,
            /// <summary>
            /// No
            /// </summary>
            No = 7,
            /// <summary>
            /// Try
            /// </summary>
            Try = 10,
            /// <summary>
            /// Continue
            /// </summary>
            Continue = 11
        }
        #endregion
    }
    #endregion
}