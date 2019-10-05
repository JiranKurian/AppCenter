using AppCenterBL.ServiceModels;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace AppCenterBL.SharedServices
{
    public class EmailService
    {
        public bool SendEmail(EmailServiceModel emailServiceModel)
        {
            MailMessage mailMessage = new MailMessage();

            mailMessage.From = new MailAddress("customerrelations.appcenter@gmail.com");
            mailMessage.To.Add(new MailAddress(emailServiceModel.ToAddress));
            mailMessage.Subject = emailServiceModel.Subject;
            mailMessage.IsBodyHtml = emailServiceModel.HtmlBody;
            mailMessage.Body = emailServiceModel.Body;

            SmtpClient smtpClient = new SmtpClient();

            smtpClient.Port = 587;
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential("customerrelations.appcenter@gmail.com", "winstonJIRAN");
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.Send(mailMessage);

            return true;
        }
    }
}
