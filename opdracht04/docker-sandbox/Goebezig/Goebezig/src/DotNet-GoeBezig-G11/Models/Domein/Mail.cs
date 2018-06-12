

using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using MailKit;
using MailKit.Net.Smtp;
using MimeKit;

namespace DotNet_GoeBezig_G11.Models.Domein
{
    public class Mail
    {
        public const string EmailFrom = "goebezig.noreply@gmail.com";
        public static async Task StuurMail(string emailTo, string inhoud, string subject)
        {
            try
            {
                
                //Smtp Server 
                string SmtpServer = "smtp.gmail.com";
                //Smtp Port Number 
                int SmtpPortNumber = 587;


                var mimeMessage = new MimeMessage();
                mimeMessage.From.Add(new MailboxAddress(EmailFrom));
                mimeMessage.To.Add(new MailboxAddress(emailTo));
                mimeMessage.Subject = subject;
                mimeMessage.Body = new TextPart("plain")
                {
                    Text = inhoud 
                };



                var smtpClient = new SmtpClient();
                //smtpClient.Connect(SmtpServer, SmtpPortNumber, false);
                await smtpClient.ConnectAsync(SmtpServer, SmtpPortNumber, false);
                // Note: only needed if the SMTP server requires authentication 
                // Error 5.5.1 Authentication  
                //smtpClient.Authenticate(EmailFrom, "P@sswoord1");
                await smtpClient.AuthenticateAsync(EmailFrom, "P@sswoord1");
                await smtpClient.SendAsync(mimeMessage);

                
                Console.WriteLine("The mail has been sent successfully !!");
                Console.ReadLine();
                //smtpClient.Disconnect(true);
                await smtpClient.DisconnectAsync(true);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    
    }
}
