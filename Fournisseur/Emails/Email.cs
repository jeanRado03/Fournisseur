using System.Net;
using System.Net.Mail;

namespace Fournisseur.Emails
{
    public class Email
    {
        public static void NewHeadlessEmail(string fromEmail, string password, string toAddress, string subject, string body)
        {
            using (var myMail = new MailMessage())
            {
                myMail.From = new MailAddress(fromEmail);
                myMail.To.Add(toAddress);
                myMail.Subject = subject;
                myMail.IsBodyHtml = true;
                myMail.Body = body;
                using (var s = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587))
                {
                    s.DeliveryMethod = SmtpDeliveryMethod.Network;
                    s.UseDefaultCredentials = false;
                    s.Credentials = new System.Net.NetworkCredential(myMail.From.ToString(), password);
                    s.EnableSsl = true;
                    s.Send(myMail);
                }
            }
        }

        public static void SendEmailWithAttachment(string fromEmail, string password, string toAddress, string subject, string body, string pathToAttachment)
        {
            using (var myMail = new System.Net.Mail.MailMessage())
            {
                myMail.From = new MailAddress(fromEmail);
                myMail.To.Add(toAddress);
                myMail.Subject = subject;
                myMail.IsBodyHtml = true;
                myMail.Body = body;
                using (var s = new SmtpClient("smtp.gmail.com", 587))
                {
                    s.DeliveryMethod = SmtpDeliveryMethod.Network;
                    s.UseDefaultCredentials = false;
                    s.Credentials = new NetworkCredential(myMail.From.ToString(), password);
                    s.EnableSsl = true;

                    var attachment = new Attachment(pathToAttachment);
                    myMail.Attachments.Add(attachment);

                    s.Send(myMail);
                }
            }
        }
    }
}
