using NOWAccountUITests.Common;
using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace NOWAccountUITests.Pages
{
    public class LoginPage : BasePageElement
    {

        public LoginPage()
        {

        }

        #region Login page elements
        private IWebElement Email()
        {
            string idValue = "Email";
            DriverManager.WaitElementIsVisible(60, "Id", idValue);
            return driver.FindElement(By.Id(idValue));
        }
        private IWebElement Password()
        {
            string idValue = "Password";
            DriverManager.WaitElementIsVisible(60, "Id", idValue);
            return driver.FindElement(By.Id(idValue));
        }

        private IWebElement LoginButton()
        {
            string xpathValue = "//*[contains(@value,'Login')]";
            DriverManager.WaitElementIsVisible(60, "XPath", xpathValue);
            return driver.FindElement(By.XPath(xpathValue));
        }

        private IWebElement ErrorMessage()
        {
            string classNameValue = "validation-summary-errors";
            DriverManager.WaitElementIsVisible(60, "ClassName", classNameValue);
            return driver.FindElement(By.ClassName(classNameValue));
        }


        #endregion

        #region Login page actions
        public LoginPage EnterEmail(string _email)
        {
            Email().SendKeys(_email);
            return this;
        }

        public LoginPage EnterPassword(string _password)
        {
            Password().SendKeys(_password);
            return this;
        }

        public LoginPage ClickLoginButton()
        {
            LoginButton().Click();
            return this;
        }

        public LoginPage ValidateErrorMessage()
        {
            Console.WriteLine(ErrorMessage().GetAttribute("text"));
            Assert.True(!string.IsNullOrEmpty(ErrorMessage().GetAttribute("text")));
            return this;
        }

        #endregion

    }
}
