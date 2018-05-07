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
    public class LoginPage
    {
        
        IWebDriver driver;
        Actions action;
        WebDriverWait wait;

        public LoginPage(IWebDriver _driver, Actions _action, WebDriverWait _wait)
        {
            this.driver = _driver;
            this.action = _action;
            this.wait = _wait;

        }
        public GoogleHomePage Login(String username, String password) {
            EnterUsername(username);
            EnterPassword(password);
            return new GoogleHomePage(driver, action,wait);

        }
        public IWebElement GetUsernameField() {
            return driver.FindElement(By.Id("identifierId"));
        }
        public IWebElement GetUsernameNextButton() {
            return driver.FindElement(By.Id("identifierNext")); ;
        }
        public IWebElement GetPasswordField() {
            return driver.FindElement(By.XPath("//*[@id='password']//input"));
        }
        public IWebElement GetPasswordNextButton() {
            return driver.FindElement(By.Id("passwordNext"));
        }
        public void EnterUsername(String username) {
            GetUsernameField().SendKeys(username);
            GetUsernameNextButton().Click();
        }
        public void EnterPassword(String password) {
            
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='password']//input")));
            
            //Thread.Sleep(500);
            GetPasswordField().SendKeys(password);
            GetPasswordNextButton().Click();

        }
    }
}
