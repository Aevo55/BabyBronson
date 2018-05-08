using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Threading;
using POMTest.PageObjects;
namespace POMTest.Activities

{
     class Email
    {
        public void sendMailManual(String address, String subject, String body, GmailHomePage page) {

            ComposeWindow email = page.ClickCompose();
            email.InputAddress(address);
            email.InputSubject(subject);
            email.InputContent(body);
            email.SendEmail();

        }

        public void Respond(int count, GmailHomePage page)
        {

            String subject = String.Format("Response to {0}", page.getSenderName(count));
            String body = String.Format("Hi {0},\nI recieved your email at {1}", page.getSenderName(count), page.getSenderTime(count));
            sendMail(page.getSenderEmail(count), page.getSenderName(count), "TestPass", subject, body);

        }
        public void sendMail(String address, String name, String fromPassword, String subject, String body)
        {

            MailAddress fromAddress = new MailAddress("DaveTestSe@gmail.com", "Dave Test");
            MailAddress toAddress = new MailAddress(address, name);

            SmtpClient client = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };

            using (MailMessage message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })

            { client.Send(message); }

        }

    }
}
