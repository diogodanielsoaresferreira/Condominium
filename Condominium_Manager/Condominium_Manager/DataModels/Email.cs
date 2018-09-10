using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Mail;

/// <summary>
/// UA Network does not allow to send e-mails. It works on local networks, but database is in UA network...
/// </summary>
namespace Condominium_Manager.DataModels
{
    class Email
    {
        public static void sendEmail(string inputEmail, string subject, string body)
        {
            // from: http://stackoverflow.com/questions/29465096/how-to-send-an-e-mail-with-c-sharp-through-gmail

            MailMessage msg = new MailMessage();

            msg.From = new MailAddress("dominiumua@gmail.com");
            msg.To.Add(inputEmail);
            msg.Subject = subject;
            msg.Body = body;
            SmtpClient client = new SmtpClient();
            client.UseDefaultCredentials = true;
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Credentials = new NetworkCredential("dominiumua@gmail.com", "batadase");
            client.Timeout = 1000;
            try
            {
                //client.Send(msg);
                //return "Mail has been successfully sent!";
            }
            catch (Exception ex)
            {
                //return "Fail Has error" + ex.Message;
            }
            finally
            {
                msg.Dispose();
            }
        }
    }
}
