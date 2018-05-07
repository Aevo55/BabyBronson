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
using POMTest.Activities;

namespace POMRun
{
    class Program
    {


        static void Main(string[] args)
        {
            Console.WriteLine("Working");

            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            IWebDriver driver = new ChromeDriver(options);
            Actions action = new Actions(driver);


            GoogleHomePage homepage = new GoogleHomePage(driver, action);
            homepage.Init();
            Email email = new Email();
            LoginPage loginpage = homepage.gotoLogin();
            GoogleHomePage LoggedInHomepage = loginpage.login("DaveTestSe", "TestPass");
            GmailHomePage gmailhome = LoggedInHomepage.gotoGmail();
            gmailhome.SelectEmail(0);
            gmailhome.SelectEmail(1);
            gmailhome.DeleteSelected();
            //email.respond(0,gmailhome);
            //driver.Close();

        }


    }
}
