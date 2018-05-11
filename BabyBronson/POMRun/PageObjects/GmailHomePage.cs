using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Collections.ObjectModel;
using System.IO;
using System.Net;
using System.Threading;

namespace POMTest.PageObjects
{
   public class GmailHomePage
    {
        IWebDriver driver;
        Actions action;
        WebDriverWait wait;
   
   
   public GmailHomePage(IWebDriver _driver, Actions _action, WebDriverWait _wait)
        {
            this.driver = _driver;
            this.action = _action;
            this.wait = _wait;
        }
        public IWebElement getSenderMeta(int count) {

            IWebElement selectedEmail = getEmail(count);
            IWebElement emailmeta = selectedEmail.FindElement(By.CssSelector("span[class='zF']"));
            return emailmeta;
        }
        public IWebElement getTimeMeta(int count) {
            IWebElement selectedEmail = getEmail(count);
            IWebElement timedata = selectedEmail.FindElement(By.CssSelector("td[class='xW xY ']"));
            IWebElement timemeta = timedata.FindElement(By.XPath("child::*"));
            return timemeta;
        }
        public IWebElement getDeleteButton() {
            return driver.FindElement(By.CssSelector("[act='10']"));
        }
        public void SelectEmail(int count) {
            IWebElement SelectedEmail = getEmails()[count];
            SelectedEmail.FindElement(By.CssSelector("td[class='oZ-x3 xY']")).Click();
        }
        public IWebElement GetComposeButton() {
            return driver.FindElement(By.CssSelector("[class='z0']")).FindElement(By.XPath("child::*"));
        }
        public IWebElement getEmail(int count) {
            return wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(String.Format("//tr[contains(@class,'zA')][{0}]",count))));
        }
        public IWebElement getUnreadEmail(int count)
        {
            return wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(String.Format("//tr[contains(@class,'zA zE')][{0}]", count))));
        }
        public ReadOnlyCollection<IWebElement> getEmails() {
            return driver.FindElements(By.XPath("//tr[contains(@class,'zA')]"));
        }
        public ReadOnlyCollection<IWebElement> GetUnreadEmails() {
            /*
            return driver.FindElements(By.XPath("//tr[contains(@class,'zA zE')]"));
            /*/
            return driver.FindElements(By.CssSelector("tr[class='zA zE']"));
            /**/
        }
        public ComposeWindow ClickCompose() {
            GetComposeButton().Click();
            return new ComposeWindow(driver, action, wait);
        }
        public void DeleteSelected() {
            getDeleteButton().Click();
        }
        public EmailPage clickEmail(int count) {
            getEmail(count).Click();
            return new EmailPage(driver, action, wait);
        }
        public EmailPage clickUnreadEmail(int count)
        {
            getUnreadEmail(count).Click();
            return new EmailPage(driver, action, wait);
        }
        public String getSenderName(int count) {
            return getSenderMeta(count).GetAttribute("name");
        }
        public int getNumUnread() {
            String totalEmails = driver.FindElement(By.CssSelector("a[class='J-Ke n0'")).GetAttribute("innerHTML");
            if (totalEmails.Contains("(")) {
                String totalEmailsFormatted = totalEmails.Split('(')[1].Split(')')[0];
                return int.Parse(totalEmailsFormatted);
            } else {
                return 0;
            }
        }
        public IWebElement getOlderButton() {
            try {
                return wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("div[aria-label='Older']")));
            } catch (NoSuchElementException){
                    driver.Navigate().Refresh();
                    return null;
            }
        }
        public void clickOlder() {
            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("div[aria-label='Older']"))).Click();
            }
            catch (NoSuchElementException)
            {
                driver.Navigate().Refresh();
            }
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
