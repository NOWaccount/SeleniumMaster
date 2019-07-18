using NOWAccountUITests.Pages;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using System;

namespace NOWAccountUITests.Common
{
    public class SeleniumHelper : BasePageElement
    {
        public void NavigateToUrl(string url)
        {
            DriverManager.Driver.Navigate().GoToUrl(url);
        }

        public void ValidateCurrentUrl(string url)
        {
            Assert.True(DriverManager.Driver.Url.Contains(url));
        }
    }
}
