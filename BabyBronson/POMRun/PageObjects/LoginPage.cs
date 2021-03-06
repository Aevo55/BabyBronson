﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Waitcon = SeleniumExtras.WaitHelpers;
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
            return wait.Until(Waitcon.ExpectedConditions.ElementToBeClickable(By.CssSelector("input[type='email']")));
            //return driver.FindElement(By.CssSelector("input[type='email']"));
            
        }
        public IWebElement getUsernameNextButton() {
            return driver.FindElement(By.CssSelector("span[class='RveJvd snByac']")); ;
        }
        public IWebElement getPasswordField() {
            //wait.Until(Waitcon.ExpectedConditions.ElementToBeClickable(By.CssSelector("input[name='password']")));
            //Console.WriteLine(driver.FindElement(By.CssSelector("input[type='password']")).GetAttribute("outerHTML"));
            return wait.Until(Waitcon.ExpectedConditions.ElementToBeClickable(By.CssSelector("input[type='password']")));
        }
        public IWebElement getPasswordNextButton() {
            return wait.Until(Waitcon.ExpectedConditions.ElementToBeClickable(By.Id("passwordNext")));
        }
        public void EnterUsername(String username) {
            getUsernameField().SendKeys(username);
            getUsernameField().SendKeys(Keys.Return);
            //getUsernameNextButton().Click();
        }
        public void EnterPassword(String password) {
            //wait.Until(Waitcon.ExpectedConditions.ElementIsVisible(By.CssSelector("input[type='password']")));
            getPasswordField().SendKeys(password);
            getPasswordField().SendKeys(Keys.Enter);
        }
    }
}
