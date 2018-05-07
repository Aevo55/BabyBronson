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


        public LoginPage(IWebDriver _driver, Actions _action)
        {
            this.driver = _driver;
            this.action = _action;


        }
        public GoogleHomePage login(String username, String password) {

            EnterUsername(username);
            EnterPassword(password);
            return new GoogleHomePage(driver, action);

        }
        

        public void EnterUsername(String username) {
            IWebElement UsernameField = driver.FindElement(By.Id("identifierId"));
            UsernameField.SendKeys(username);
            IWebElement NextButton = driver.FindElement(By.Id("identifierNext"));
            NextButton.Click();
        }
        public void EnterPassword(String password) {
            Thread.Sleep(500);
            IWebElement PasswordField = driver.FindElement(By.XPath("//*[@id='password']")).FindElement(By.XPath(".//input"));
            PasswordField.SendKeys(password);
            IWebElement NextButton = driver.FindElement(By.Id("passwordNext"));
            NextButton.Click();

        }
    }
}
