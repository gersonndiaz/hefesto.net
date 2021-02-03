using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace Hefesto.Email
{
    /// <summary>
    /// Esta clase contiene funciones que permiten operar con el protocolo SMTP
    /// </summary>
    public class SmtpUtil
    {

        public string host { get; set; }
        public int port { get; set; }
        public bool? ssl { get; set; }
        public string user { get; set; }
        public string password { get; set; }
        public string subject { get; set; }
        public string body { get; set; }
        public List<string> recipients { get; set; }
        public List<string> cc { get; set; }
        public List<string> bcc { get; set; }
        public int priority { get; set; }
        public List<FileStream> attach_file { get; set; }
        public bool? isBodyHtml { get; set; }
        public bool? useDefaultCredentials { get; set; }

        //============================================

        /// <summary>
        /// Función que permite enviar un correo electrónico
        /// </summary>
        /// <returns>true || false</returns>
        public bool sendSmtpEmail()
        {
            bool success = false;

            try
            {
                // Accedemos a la casilla de correo
                SmtpClient smtp_client = new SmtpClient();
                smtp_client.Port = port;
                smtp_client.Host = host;
                smtp_client.EnableSsl = (ssl.HasValue) ? ssl.Value : false;

                smtp_client.Timeout = 20000;
                smtp_client.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp_client.UseDefaultCredentials = (useDefaultCredentials.HasValue) ? useDefaultCredentials.Value : true;
                smtp_client.Credentials = new NetworkCredential(user, password);
                // Fin Acceso a la casilla

                // Definir Prioridad
                MailPriority mPriority = new MailPriority();

                if (priority < 0)
                {
                    priority = 0;
                }
                else if (priority > 2)
                {
                    priority = 0;
                }

                switch (priority)
                {
                    case 0:
                        mPriority = MailPriority.Normal;
                        break;
                    case 1:
                        mPriority = MailPriority.Low;
                        break;
                    case 2:
                        mPriority = MailPriority.High;
                        break;

                }
                // Fin Prioridad

                MailMessage mail = new MailMessage();

                mail.From = new MailAddress(user);
                mail.Subject = subject;
                mail.Body = body;
                mail.Priority = mPriority;
                mail.IsBodyHtml = (isBodyHtml.HasValue) ? isBodyHtml.Value : true;

                // Agregar Destinatarios
                foreach (string email in recipients)
                {
                    //mail.To.Add(email);
                    mail.To.Add(new MailAddress(email));
                }

                // Agregamos Destinatarios Copiados en Email
                if (cc != null)
                {
                    foreach (string email in cc)
                    {
                        //mail.CC.Add(email);
                        mail.CC.Add(new MailAddress(email));
                    }
                }

                // Agregamos Copias ocultas
                if (bcc != null)
                {
                    foreach (string email in bcc)
                    {
                        //mail.Bcc.Add(email);
                        mail.Bcc.Add(new MailAddress(email));
                    }
                }

                // Agregamos los archivos Adjuntos
                if (attach_file != null)
                {
                    foreach (FileStream file in attach_file)
                    {
                        mail.Attachments.Add(new Attachment(file, file.Name));
                    }
                }

                smtp_client.Send(mail);

                success = true;

            }
            catch (Exception e)
            {
                success = false;
                throw new Exception("Error", e);
            }

            return success;
        }

    }
}
