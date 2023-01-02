using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;
using System;
using AGILEDataPortal.Constants;

namespace AGILEDataPortal.HelperClasses
{
    public class MailHelper : IMailHelper
    {
        private readonly IConfiguration _configuration;
        IOptions<ReadSMTPSettings> _smtpSettings;

        public MailHelper(IOptions<ReadSMTPSettings> smtpSettings, IConfiguration configuration)
        {
            _smtpSettings = smtpSettings;
            _configuration = configuration;
        }


        public async Task SendEmailNotificationEmailAsync(List<string> email, string subject, string message)
        {
            try
            {
                using (var client = new SmtpClient())
                {
                    client.UseDefaultCredentials = false;
                    var credential = new NetworkCredential
                    {
                        UserName = _configuration["SmtpServer:Email"],
                        Password = _configuration["SmtpServer:Password"]
                    };

                    client.Credentials = credential;
                    client.Host = _configuration["SmtpServer:Host"];
                    client.EnableSsl = false;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;

                    using (var emailMessage = new MailMessage())
                    {
                        //List<MailAddress> listofEmails = new List<MailAddress>();
                        //foreach (var item in email.Split(';'))
                        //{
                        //    if(string.IsNullOrWhiteSpace(item))
                        //        emailMessage.To.Add(email);
                        //    else
                        //        emailMessage.To.Add(item);

                        //}

                        foreach (var item in email)
                        {
                            emailMessage.To.Add(item);
                        }
                        emailMessage.From = new MailAddress("Bizkit<noreply@bizkit.com.ng>"); //new MailAddress("Bizkit<noreply@bizkit.com.ng>");//new MailAddress(_configuration["SmtpServer:Email"]);
                        emailMessage.Subject = subject;
                        emailMessage.Body = message;
                        emailMessage.IsBodyHtml = true;
                        client.Send(emailMessage);

                    }
                }
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
            }


        }

        public async Task sendMailAsync(string email, string subject, string message)
        {
            try
            {
                //using (var client = new SmtpClient())
                //{
                //    client.UseDefaultCredentials = false;
                //    var credential = new NetworkCredential
                //    {
                //        UserName = _configuration["SmtpServer:Email"],
                //        Password = _configuration["SmtpServer:Password"]
                //    };

                //    client.Host = _configuration["SmtpServer:Host"];
                //    client.EnableSsl = false;
                //    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                //    client.Credentials = credential;
                //    // System.Net.ServicePointManager.Expect100Continue = false;




                //    using (var emailMessage = new MailMessage())
                //    {
                //        emailMessage.To.Add(email);
                //        emailMessage.From = new MailAddress("Bizkit<noreply@bizkit.com.ng>"); //new MailAddress("Bizkit<noreply@bizkit.com.ng>");//new MailAddress(_configuration["SmtpServer:Email"]);
                //        emailMessage.Subject = subject;
                //        emailMessage.Body = message;
                //        emailMessage.IsBodyHtml = true;
                //        client.Send(emailMessage);

                //    }

                //}



                string smtpAddress = "outlook.office365.com";//"smtp.gmail.com";
                int portNumber = 25; //587;
                bool enableSSL = true;
                string emailFromAddress = "agilesupport@sidmach.com";  //"sidmachocr@gmail.com"; //Sender Email Address  
                string password = "Knowbot@@1"; //Sender Password  
                ServicePointManager.SecurityProtocol = ServicePointManager.SecurityProtocol | System.Net.SecurityProtocolType.Tls12;
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(emailFromAddress, "A.G.I.L.E Portal Support");
                    mail.To.Add(email);
                    mail.Subject = subject;
                    mail.Body = message;
                    mail.IsBodyHtml = true;
                    //mail.Attachments.Add(new Attachment("D:\\TestFile.txt"));//--Uncomment this to send any attachment  
                    using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                    {
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new NetworkCredential(emailFromAddress, password);
                        smtp.EnableSsl = enableSSL;
                        smtp.Send(mail);
                    }
                }

                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
            }


        }
    }
}
