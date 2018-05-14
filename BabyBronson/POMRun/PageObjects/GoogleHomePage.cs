using OpenQA.Selenium;
using Waitcon = SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading;
namespace POMTest.PageObjects
{
    public class GoogleHomePage
    {
        IWebDriver driver;
        Actions action;
        WebDriverWait wait;
        public GoogleHomePage(IWebDriver _driver, Actions _action, WebDriverWait _wait) {
            this.driver = _driver;
            this.action = _action;
            this.wait = _wait;
            //driver.Url = "https://www.google.ca/";
        }

         public LoginPage gotoLogin() {
            IWebElement loginButton = driver.FindElement(By.LinkText("Sign in"));
            loginButton.Click();
            return new LoginPage(driver, action,wait);
        }
        public void Init() {
            driver.Url = "https://www.google.ca/";
        }
        public GmailHomePage gotoGmail() {
            WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(5));
            IWebElement gmailLink = wait.Until(Waitcon.ExpectedConditions.ElementToBeClickable(
                                    By.CssSelector("[href='https://mail.google.com/mail/?tab=wm']")));
            gmailLink.Click();
            return new GmailHomePage(driver, action,wait);
        }
        
    }

}
