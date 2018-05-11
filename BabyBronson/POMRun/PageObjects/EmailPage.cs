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
namespace POMTest.PageObjects {
   public class EmailPage {
        IWebDriver driver;
        Actions action;
        WebDriverWait wait;
        public EmailPage(IWebDriver _driver, Actions _action, WebDriverWait _wait) {
            this.driver = _driver;
            this.action = _action;
            this.wait = _wait;
        }
        public IWebElement GetInboxButton() {
            return driver.FindElement(By.CssSelector("div[class='ar6 T-I-J3 J-J5-Ji']"));
        }
        public IWebElement GetBodyElement() {
            return driver.FindElement(By.CssSelector("div[class='ii gt ']"));
        }
        public IWebElement GetSubjectElement() {
            return driver.FindElement(By.CssSelector("h2[class='hP']"));
        }
        public string getRecip() {
            var outElem = wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("hb")));
            var dataElement = outElem.FindElement(By.CssSelector("span[dir='ltr']"));
            return dataElement.GetAttribute("email");
        }
        public string getAlias() {
            var fullRecip = getRecip();
            fullRecip = fullRecip.Split('+')[1];
            fullRecip = fullRecip.Split('@')[0];
            return fullRecip;
        }
        public string getInnerHTML() {
            return GetBodyElement().GetAttribute("innerHTML");
        }
        public string getSubject() { 
            return GetSubjectElement().GetAttribute("value");
        }
        public GmailHomePage returnToInbox() {
            GetInboxButton().Click();
            return new GmailHomePage(driver, action, wait);
        }
   }
}
