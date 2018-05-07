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
   public class GmailHomePage
    {
        IWebDriver driver;
        Actions action;
        
   
   
   public GmailHomePage(IWebDriver _driver, Actions _action)
        {
            this.driver = _driver;
            this.action = _action;
        }

        public IWebElement GetSenderMeta(int count) {

            IWebElement selectedEmail = driver.FindElements(By.CssSelector("tr[class='zA zE']"))[count];
            IWebElement emailmeta = selectedEmail.FindElement(By.CssSelector("span[class='zF']"));
            return emailmeta;

        }

        public IWebElement GetTimeMeta(int count) {
            IWebElement selectedEmail = driver.FindElements(By.CssSelector("tr[class='zA zE']"))[count];
            IWebElement timedata = selectedEmail.FindElement(By.CssSelector("td[class='xW xY ']"));
            IWebElement timemeta = timedata.FindElement(By.XPath("child::*"));
            return timemeta;

        }
        public IWebElement GetDeleteButton() {
            return driver.FindElement(By.CssSelector("[act='10']"));
        }
        public void DeleteSelected() {
            GetDeleteButton().Click();
        }
        public EmailPage ClickEmail(int count) {
            
            GetEmails()[count].Click();
            return new EmailPage(driver, action);
        }
        public void SelectEmail(int count) {
            IWebElement SelectedEmail = GetEmails()[count];
            SelectedEmail.FindElement(By.CssSelector("td[class='oZ-x3 xY']")).Click();
        }

        public ReadOnlyCollection<IWebElement> GetEmails() {
            return driver.FindElements(By.XPath("//tr[contains(@class,'zA')]"));
        }
        public String GetSenderName(int count) {
            return GetSenderMeta(count).GetAttribute("name");

        }
        public String GetSenderEmail(int count)
        {
            return GetSenderMeta(count).GetAttribute("email");

        }
        public String GetSenderTime(int count) {
            return GetTimeMeta(count).GetAttribute("title");
        }
 
    
    }
}
