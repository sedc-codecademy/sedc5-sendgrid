using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using MailKit.Net.Smtp;
using MimeKit;
using System.Net;

namespace SedcSendGridDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            
               var client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587,false);
            ICredentials credentials = new System.Net.NetworkCredential("username", "password");
            client.Authenticate(credentials);
            client.Authenticate("sedccodecademy@gmail.com", "Kikiriki123.");
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("sedccodecademy@gmail.com"));
            message.To.Add(new MailboxAddress("stojanco.jefremov@gmail.com"));
            var builder = new MimeKit.BodyBuilder(); 
            builder.HtmlBody = @"<html><head></head><body><p><b>bold</b>,
            i>italic</i> and <u>underlined</u></p></body></html>";
            message.Body = builder.ToMessageBody();
            client.Send(message);
            Console.ReadLine();
        }



        //const string API_KEYSendgrid = "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";



        //static void Main(string[] args)
        //{
        //    var sendGridClient = new SendGridClient(API_KEY);

        //    var fromMail = new EmailAddress("stojancho.jefremov@seavus.com");
        //    var toMail = new EmailAddress("stojanco.jefremov@gmail.com");
        //    var subject = "Mail sent using SendGrid";
        //    var plainText = "Plain text example";
        //    var htmlText = "";
        //    var message = MailHelper.CreateSingleEmail(fromMail, toMail, subject, plainText, htmlText);

        //    var bytesContent = File.ReadAllBytes(@"Files\azure.pdf");
        //    var stringContent = Convert.ToBase64String(bytesContent);
        //    message.AddAttachment("attachment.pdf", stringContent);

        //    var response = sendGridClient.SendEmailAsync(message).GetAwaiter().GetResult();

        //    Console.WriteLine("response.Headers: "+ response.Headers);
        //    Console.WriteLine("response.StatusCode: " + response.StatusCode);
        //}
    }
}
