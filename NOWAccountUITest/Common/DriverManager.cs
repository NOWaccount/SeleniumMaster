using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using static NOWAccountUITests.Common.BrowserTypes;

namespace NOWAccountUITests.Common
{
    public static class DriverManager
    {
        private static IWebDriver driver;
        private static WebDriverWait driverWait;
        public static IWebDriver Driver
        {
            get
            {
                if (driver == null) throw new NullReferenceException("Web driver not initalized. You should start the browser");
                return driver;
            }
            set
            {
                driver = value;
            }
        }

        public static void StartBrowser(BrowserType browserType)
        {
            switch (browserType.ToString())
            {
                case "CHROME":
                    DriverManager.Driver = new ChromeDriver();
                    break;

                case "FIREFOX":
                    break;

                case "IE":
                    break;

                default:
                    break;

            }
        }
        public static void StopBrowser()
        {
            Driver.Quit();
            Driver = null;
        }

        public static WebDriverWait DriverWait
        {
            get
            {
                if (driverWait == null || driver == null)
                {
                    throw new NullReferenceException("The WebDriver browser wait instance was not initialized. You should first call the method Start.");
                }
                return driverWait;
            }
            private set
            {
                driverWait = value;
            }
        }

        public static void WaitElementIsVisible(int timeout, string locator, string locatorValue)
        {
            DriverManager.DriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            switch (locator)
            {
                case "Id":
                    DriverManager.DriverWait.Until(SeleniumExtras.WaitHelpers.
                        ExpectedConditions.ElementIsVisible(By.Id(locatorValue)));
                    break;

                case "XPath":
                    DriverManager.DriverWait.Until(SeleniumExtras.WaitHelpers.
                        ExpectedConditions.ElementIsVisible(By.XPath(locatorValue)));
                    break;

                case "ClassName":
                    DriverManager.DriverWait.Until(SeleniumExtras.WaitHelpers.
                        ExpectedConditions.ElementIsVisible(By.ClassName(locatorValue)));

                    break;
            }

        }

        public static void WaitElementIsClickable(int timeout, string locator, string locatorValue)
        {
            DriverManager.DriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            switch (locator)
            {
                case "Id":
                    DriverManager.DriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id(locatorValue)));
                    break;

                case "XPath":
                    DriverManager.DriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(locatorValue)));
                    break;
            }

        }




    }
}
