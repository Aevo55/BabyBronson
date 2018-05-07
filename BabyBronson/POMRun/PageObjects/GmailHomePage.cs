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
   public class GmailHomePage
    {
        IWebDriver driver;
        Actions action;
        
   
   
   public GmailHomePage(IWebDriver _driver, Actions _action)
        {
            this.driver = _driver;
            this.action = _action;
        }

        public IWebElement getSenderMeta(int count) {

            IWebElement selectedEmail = getEmails(count);
            IWebElement emailmeta = selectedEmail.FindElement(By.CssSelector("span[class='zF']"));
            return emailmeta;

        }

        public IWebElement getTimeMeta(int count) {
            IWebElement selectedEmail = getEmails(count);
            IWebElement timedata = selectedEmail.FindElement(By.CssSelector("td[class='xW xY ']"));
            IWebElement timemeta = timedata.FindElement(By.XPath("child::*"));
            return timemeta;

        }
        public IWebElement getDeleteButton() {
            return driver.FindElement(By.CssSelector("[act='10']"));
        }
        public void DeleteSelected() {
            getDeleteButton().Click();
        }
        public EmailPage clickEmail(int count) {
            
            getEmails()[count].Click();
            return new EmailPage(driver, action);
        }
        public void SelectEmail(int count) {
            IWebElement SelectedEmail = getEmails()[count];
            SelectedEmail.FindElement(By.CssSelector("td[class='oZ-x3 xY']")).Click();
        }

        public ReadOnlyCollection<IWebElement> getEmails() {
            return driver.FindElements(By.XPath("//tr[contains(@class,'zA')]"));
        }
        public IWebElement getEmails(int count) {
            return driver.FindElements(By.XPath("//tr[contains(@class,'zA')]"))[count];
        }
        public String getSenderName(int count) {
            return getSenderMeta(count).GetAttribute("name");

        }
        public String getSenderEmail(int count)
        {
            return getSenderMeta(count).GetAttribute("email");

        }
        public String getSenderTime(int count) {
            return getTimeMeta(count).GetAttribute("title");
        }
 
    
    }
}
