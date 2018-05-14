using OpenQA.Selenium;
using Waitcon = SeleniumExtras.WaitHelpers;
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
            return wait.Until(Waitcon.ExpectedConditions.ElementExists(By.XPath("//*[@name='subjectbox']")));
        }
        public IWebElement GetAddressField() {
            return wait.Until(Waitcon.ExpectedConditions.ElementExists(By.XPath("//*[@role='combobox']")));
        }
        public IWebElement GetContentField() {
            return wait.Until(Waitcon.ExpectedConditions.ElementExists(By.XPath("//*[@role='textbox']")));
        }
        public IWebElement GetSendButton() {
            return wait.Until(Waitcon.ExpectedConditions.ElementExists(By.XPath("//*[contains(@data-tooltip, 'Send')]")));
        }
        public void SendEmail() {
            wait.Until(Waitcon.ExpectedConditions.ElementToBeClickable(GetSendButton())).Click();
        }
        public void InputSubject(String subject) {
            wait.Until(Waitcon.ExpectedConditions.ElementToBeClickable(GetSubjectField())).Click();
            GetSubjectField().SendKeys(subject);
        }
        public void InputAddress(String address) {
            wait.Until(Waitcon.ExpectedConditions.ElementToBeClickable(GetAddressField())).Click();
            GetAddressField().SendKeys(address);
            GetAddressField().SendKeys(Keys.Enter);
        }
        public void InputContent(String content)
        {
            wait.Until(Waitcon.ExpectedConditions.ElementToBeClickable(GetContentField())).Click();
            GetContentField().SendKeys(content);
        }

    }
}
