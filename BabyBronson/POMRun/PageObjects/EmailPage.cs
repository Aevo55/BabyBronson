using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Mail;
using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading;
namespace POMTest.PageObjects
{
   public class EmailPage
    {

        IWebDriver driver;
        Actions action;

        public EmailPage(IWebDriver _driver, Actions _action)
        {
            this.driver = _driver;
            this.action = _action;
        }

    }
}
