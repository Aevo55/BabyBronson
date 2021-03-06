﻿using OpenQA.Selenium;
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

            //options.AddArgument("--start-maximized");
            /*
            

            options.AddArgument("--headless");
            options.AddArgument("window-size=1920,1080");
            options.AddArgument("--disable-gpu");
            //*/

            const String loginaddress = "DaveTestSe";
            const String loginpassword = "TestPass";

            SqlLookup lookup = new SqlLookup();
            string connectionString = lookup.GetConnectionString();
            Console.WriteLine("Enter a destination address");
            String destinationaddress = Console.ReadLine();
            IWebDriver driver = new ChromeDriver(
                        AppDomain.CurrentDomain.BaseDirectory, options);
            //"C:\\Users\\Sean\\Source\\Repos\\BabyBronson\\BabyBronson\\POMRun\\Resources"
            Actions action = new Actions(driver);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            Email email = new Email();
            User user;
            GoogleHomePage homepage = new GoogleHomePage(driver, action, wait);
            homepage.Init();
            LoginPage loginpage = homepage.gotoLogin();
            GoogleHomePage LoggedInHomepage = loginpage.Login(loginaddress, loginpassword);

            GmailHomePage gmailhome = LoggedInHomepage.gotoGmail();
            EmailPage currentemail;

            while (true) { 
                while (gmailhome.getNumUnread() > 0) {
                    if (gmailhome.GetUnreadEmails().Count > 0) {
                        currentemail = gmailhome.clickUnreadEmail(1);
                        user = lookup.GetUser(connectionString, currentemail.getAlias());
                        email.forwardMail(destinationaddress, loginpassword, user, currentemail);
                        gmailhome = currentemail.returnToInbox();
                    } else {
                        Console.WriteLine("Clicking older");
                        gmailhome.clickOlder();
                       
                    }
                    Thread.Sleep(500);
                }
                Console.WriteLine("refreshing");
                gmailhome.RefreshInbox();
                Thread.Sleep(TimeSpan.FromSeconds(15));    
            }
        }
    }
}
