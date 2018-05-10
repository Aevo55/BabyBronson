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
            //*
            options.AddArgument("--start-maximized");
            /*/
            options.AddArgument("--headless");
            options.AddArgument("--disable-gpu");
            /**/
            
            IWebDriver driver = new ChromeDriver(options);
            Actions action = new Actions(driver);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));

            GoogleHomePage homepage = new GoogleHomePage(driver, action,wait);
            homepage.Init();
            Email email = new Email();
            LoginPage loginpage = homepage.gotoLogin();
            GoogleHomePage LoggedInHomepage = loginpage.Login("DaveTestSe", "TestPass");
            GmailHomePage gmailhome = LoggedInHomepage.gotoGmail();
            
            EmailPage currentemail = gmailhome.clickEmail(1);
            Console.WriteLine(currentemail.getAlias());
            SqlLookup lookup = new SqlLookup();
            string connectionString = lookup.GetConnectionString();
            User user = lookup.GetUser(connectionString,currentemail.getAlias());
            Console.WriteLine(user.GetFirstName() + " " + user.GetLastName());
            email.sendMail("s.dunlop@socyinc.com", "Forwarding Service", "TestPass", "Forwarded Email", user.MakeString());
            //email.sendMailManual("SeTest@mailinator.com", "This is a real email", "Body text", gmailhome);
            //Thread.Sleep(1000);
            //driver.Close();


        }


    }
}
