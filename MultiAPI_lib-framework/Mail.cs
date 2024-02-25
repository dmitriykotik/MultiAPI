using System;
using System.Net.Mail;
using System.Net;

/* 
  =================- INFO -===================
 * File:         | Mail.cs
 * Class:        | Mail
 * Project:      | MultiAPI
 * Author:       | Plufik
 * Version:      | 0.1.1.32
 * VerType:      | major_version.minor_version.patch_version.builds
 * Main file:    | Main.cs
 * [OPEN SOURCE] | +True
 * [CONSTRUCTOR] | -False
  ============================================
 */

namespace MultiAPI
{

    #region CLASS | Mail
    /// <summary>
    /// Действия с почтой
    /// </summary>
    public static class Mail
    {

        #region METHOD-VOID | send
        /// <summary>
        /// Отправка письма на почту
        /// </summary>
        /// <param name="fromEmail">Почта отправителя</param>
        /// <param name="fromName">Имя отправителя</param>
        /// <param name="toEmail">Почта получателя</param>
        /// <param name="subject">Тема письма</param>
        /// <param name="textOrHtml">Текст или html код для письма</param>
        /// <param name="smtpServer">SMTP сервер (например: mail.gmail.com)</param>
        /// <param name="smtpPort">SMTP порт сервера (например для mail.gmail.com: 587)</param>
        /// <param name="smtpPasswordMail">SMTP пароль (для mail.gmail.com нужно выполнить некоторые действия для создания пароля (не вашего стандартного пароля) от вашей почты (документация по получению: https://multiplayercorporation.mya5.ru/doc/smtp))</param>
        public static void send(string fromEmail, string fromName, string toEmail, string subject, string textOrHtml, string smtpServer, int smtpPort, string smtpPasswordMail)
        {
            if (Internet.TestConnection())
            {
                MailAddress from = new MailAddress(fromEmail, fromName);
                MailAddress to = new MailAddress(toEmail);
                MailMessage m = new MailMessage(from, to);
                m.Subject = subject;
                m.Body = textOrHtml;
                m.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient(smtpServer, smtpPort);
                smtp.Credentials = new NetworkCredential(fromEmail, smtpPasswordMail);
                smtp.EnableSsl = true;
                smtp.Send(m);
            }
            else throw new Exception("Не удалось подключится к интернету!");
        }
        #endregion

    }
    #endregion

}
