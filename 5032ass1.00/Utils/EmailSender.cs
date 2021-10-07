using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading.Tasks;
using System.Web;

namespace _5032ass1._00.Utils
{
    public class EmailSender
    {
        public void Send(String toEmail) //, String subject, String contents
        {

            var smtpClient = new SmtpClient("smtp.mailtrap.io")
            {
                Port = 587,
                Credentials = new NetworkCredential("d93b02cc045bd7", "6d257a76decd00"),
                EnableSsl = true,
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress("404576058@qq.com"),
                Subject = "test",
                Body = "test",
                IsBodyHtml = true,
            };
            //var attachment = new System.Net.Mail.Attachment("profile.jpg", MediaTypeNames.Image.Jpeg);
            //mailMessage.Attachments.Add(attachment);
            mailMessage.To.Add(toEmail);

            smtpClient.Send(mailMessage);
            //smtpClient.Send("email", "recipient", "subject", "body");
        }
    }
}