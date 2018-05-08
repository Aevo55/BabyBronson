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
        public IWebElement getUsernameField() {
            return driver.FindElement(By.Id("identifierId"));
        }
        public IWebElement getUsernameNextButton() {
            return driver.FindElement(By.Id("identifierNext")); ;
        }
        public IWebElement getPasswordField() {
            return wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='password']//input")));
            //return driver.FindElement(By.XPath("//*[@id='password']//input"));
        }
        public IWebElement getPasswordNextButton() {
            return driver.FindElement(By.Id("passwordNext"));
        }
        public void EnterUsername(String username) {
            getUsernameField().SendKeys(username);
            getUsernameNextButton().Click();
        }
        public void EnterPassword(String password) {
            
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='password']//input")));
            
            //Thread.Sleep(500);
            getPasswordField().SendKeys(password);
            getPasswordNextButton().Click();

        }
    }
}
