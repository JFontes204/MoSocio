using MoSocioAPI.Email.Configuration;
using System;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace MoSocioAPI.Email
{
    public class EmailService
    {
        public static bool SendMail(string subject, string to, string msg, string pdfPath)
        {
            bool res = false;

            MailMessage mm = new MailMessage();

            mm.From = new MailAddress(EmailConfiguration.EmailFrom);
            mm.To.Add(new MailAddress(to));
            mm.Subject = subject;
            mm.Attachments.Add(new Attachment(pdfPath));
            mm.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(msg, null, MediaTypeNames.Text.Html));

            try
            {
                SmtpClient smtpClient = new SmtpClient(EmailConfiguration.SmtpClient, Convert.ToInt32(25));
                NetworkCredential credentials = new System.Net.NetworkCredential(EmailConfiguration.NetworkCredentialUsername, EmailConfiguration.NetworkCredentialPassword);
                smtpClient.Credentials = credentials;
                smtpClient.EnableSsl = true;

                ServicePointManager.ServerCertificateValidationCallback = delegate (object s,
                X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                {
                    return true;
                };

                smtpClient.Send(mm);

                res = true;

                mm.Dispose();
            }
            catch (Exception exp)
            {
                Console.WriteLine("Ocorreu um erro no envio:" + exp.Message);
            }
            return res;
        }

        public static bool SendMail2(string subject, string to, string msg)
        {
            bool res = false;

            MailMessage mm = new MailMessage();

            mm.From = new MailAddress(EmailConfiguration.EmailFrom);
            mm.To.Add(new MailAddress(to));
            mm.Subject = subject;
            mm.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(msg, null, MediaTypeNames.Text.Html));

            try
            {
                SmtpClient smtpClient = new SmtpClient(EmailConfiguration.SmtpClient, Convert.ToInt32(25));
                NetworkCredential credentials = new System.Net.NetworkCredential(EmailConfiguration.NetworkCredentialUsername, EmailConfiguration.NetworkCredentialPassword);
                smtpClient.Credentials = credentials;
                smtpClient.EnableSsl = true;

                ServicePointManager.ServerCertificateValidationCallback = delegate (object s,
                X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                {
                    return true;
                };

                smtpClient.Send(mm);

                res = true;

                mm.Dispose();
            }
            catch (Exception exp)
            {
                Console.WriteLine("Ocorreu um erro no envio:" + exp.Message);
            }
            return res;
        }
    }
}
