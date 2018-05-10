using OpenQA.Selenium;
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
            IWebElement gmailLink = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='gbw']/div/div/div[1]/div[2]/a")));
            gmailLink.Click();
            return new GmailHomePage(driver, action,wait);
        }
        
    }

}
