using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading;
using POMTest.PageObjects;
using POMRun.Util;

namespace POMRun
{
    class Program
    {


        static void Main(string[] args)
        {
            Console.WriteLine("Working");

            ChromeOptions options = new ChromeOptions();
            //*
            options.AddArgument("--start-maximized");
            /*/
            options.AddArgument("--headless");
            options.AddArgument("--disable-gpu");
            /**/
            const String loginaddress = "DaveTestSe";
            const String loginpassword = "TestPass";

            SqlLookup lookup = new SqlLookup();
            string connectionString = lookup.GetConnectionString();
            String destinationaddress = Console.ReadLine();
            IWebDriver driver = new ChromeDriver(options);
            Actions action = new Actions(driver);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            Email email = new Email();
            User user;
            GoogleHomePage homepage = new GoogleHomePage(driver, action,wait);
            homepage.Init();
            
            LoginPage loginpage = homepage.gotoLogin();
            GoogleHomePage LoggedInHomepage = loginpage.Login(loginaddress, loginpassword);
            GmailHomePage gmailhome = LoggedInHomepage.gotoGmail();
            EmailPage currentemail;
            
            
            while (gmailhome.GetUnreadEmails().Count > 0) {
             currentemail = gmailhome.clickUnreadEmail(1);
            user = lookup.GetUser(connectionString, currentemail.getAlias());
            email.sendMail("s.dunlop@socyinc.com", "Forwarding Service", "TestPass", "FWD:" + currentemail.getSubject(), user.MakeString() + currentemail.getInnerHTML());
            gmailhome = currentemail.returnToInbox();   
            }
            

            //driver.Close();
        }


    }
}
