using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;

namespace engmercedes.UI.Models
{
    public class SendMailModel
    {
        public bool Message(MailModel model)
         {
            if (model != null)
            {
                var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress("info@engmercedes.com")); //replace with valid value
                message.Subject = model.Subject;
                message.Body = string.Format(body, model.Name, model.Email, model.Message);
                message.IsBodyHtml = true;
                using (var smtp = new SmtpClient())
                {
                    smtp.Send(message);
                }

                return true;
            }

            return false;
        }
    }
}