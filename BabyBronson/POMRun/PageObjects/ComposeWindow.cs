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
    public class ComposeWindow
    {
        IWebDriver driver;
        Actions action;
        WebDriverWait wait;
        public ComposeWindow(IWebDriver _driver, Actions _action, WebDriverWait _wait)
        {
            this.driver = _driver;
            this.action = _action;
            this.wait = _wait;
        }
        public IWebElement GetSubjectField() {
            return driver.FindElement(By.XPath("//*[@role= 'combobox']"));
        }
        public IWebElement GetAddressField() {
            Thread.Sleep(500);
            return driver.FindElement(By.CssSelector("input[name='subjectbox']"));
        }
        public void InputSubject(String subject) {
            wait.Until(ExpectedConditions.ElementToBeClickable(GetSubjectField())).Click();
            GetSubjectField().SendKeys(subject);
        }
        public void InputAddress(String address) {
            wait.Until(ExpectedConditions.ElementToBeClickable(GetAddressField())).Click();
            GetAddressField().SendKeys(address);
        }

    }
}
