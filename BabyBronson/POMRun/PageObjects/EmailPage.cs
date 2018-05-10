﻿using OpenQA.Selenium;
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
        WebDriverWait wait;
        public EmailPage(IWebDriver _driver, Actions _action, WebDriverWait _wait) {
            this.driver = _driver;
            this.action = _action;
            this.wait = _wait;
        }
        public string getRecip() {
            var outElem = driver.FindElement(By.ClassName("hb"));
            var dataElement = outElem.FindElement(By.CssSelector("span[dir='ltr']"));
            return dataElement.GetAttribute("email");
        }
        public string getAlias() {
            var fullRecip = getRecip();
            fullRecip = fullRecip.Split('+')[1];
            fullRecip = fullRecip.Split('@')[0];
            return fullRecip;
        }
        public GmailHomePage returnToInbox() {
            driver.FindElement(By.XPath("//*[@id=':5']/div[2]/div[1]/div/div[1]/div")).Click();
            return new GmailHomePage(driver, action, wait);
        }
   }
}
