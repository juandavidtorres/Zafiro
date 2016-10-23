
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Net.Http;
using System.Net.Mail;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace ZF_Core.Models
{
    public class EmailService  {

        public static  void SendMail(string Message, string Emailorigin, string Subject, string EmailDestiny,string ApiKey)
        {
            try
            {                
                dynamic sg = new SendGridAPIClient(ApiKey);
                Email from = new Email(Emailorigin);
                string subject = Subject;
                Email to = new Email(EmailDestiny);
                SendGrid.Helpers.Mail.Content content = new SendGrid.Helpers.Mail.Content("text/plain", Message);
                Mail mail = new Mail(from, subject, to, content);
                dynamic response =  sg.client.mail.send.post(requestBody: mail.Get());
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
