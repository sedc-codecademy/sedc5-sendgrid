using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sendgrid.ConsoleDemo
{
    class Program
    {
        const string ApiKey = "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";

        static void Main(string[] args)
        {
            SendEmailAsync().Wait();
        }

        static async Task MainAsync()
        {
            await SendEmailAsync();
        }

        static async Task SendEmailAsync()
        {
            EmailAddress to = new EmailAddress("dzevat.ibraimi@seavus.com", "dzevowork");
            EmailAddress from = new EmailAddress("djevat.ibraimi@outlook.com", "dzevosedc");
            string subject = "About the tutorial you asked";

            var sendGrid = new SendGridClient(ApiKey);

            var attachmentName = "offline.pdf";
            var attachmentPath = $@"SampleFiles\{attachmentName}";

            var fileBytes = File.ReadAllBytes(attachmentPath);
            var attachmentContentAsBase64String= Convert.ToBase64String(fileBytes);

            var attachment = new Attachment
            {
                Content = attachmentContentAsBase64String,
                Filename = attachmentName,
                Type = "application/pdf"
            };

            var attachments = new List<Attachment> { attachment };

            var plainTextContent = "plain text content";

            var htmlContent = "HTML <b>bold</b>, <u>underlined</u> and <i>italic</i> content";

            var message = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);

            message.AddAttachment(attachmentName, attachmentContentAsBase64String, "application/pdf");

            Response response = await sendGrid.SendEmailAsync(message);
            var body = await response.Body.ReadAsStringAsync();

            Console.WriteLine(body);
        }
    }
}
