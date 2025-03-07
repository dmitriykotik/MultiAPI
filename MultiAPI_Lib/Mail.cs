using System.Net.Mail;
using System.Net;

/* 
  =================- INFO -===================
 * File:         | Mail.cs
 * Class:        | Mail
 * Project:      | MultiAPI
 * Author:       | dmitriykotik
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
            if (string.IsNullOrEmpty(fromEmail) || string.IsNullOrEmpty(fromName) || string.IsNullOrEmpty(toEmail) || string.IsNullOrEmpty(subject) || string.IsNullOrEmpty(textOrHtml) || string.IsNullOrEmpty(smtpServer) || string.IsNullOrEmpty(Convert.ToString(smtpPort)) || string.IsNullOrEmpty(smtpPasswordMail)) throw new Exception("0x00003");
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
            else throw new Exception("0x00005");
        }
        #endregion

    }
    #endregion

}
