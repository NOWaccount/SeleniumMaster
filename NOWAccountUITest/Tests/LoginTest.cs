using Microsoft.VisualStudio.TestTools.UnitTesting;
using NOWAccountUITests.Common;
using NOWAccountUITests.Pages;
using static NOWAccountUITests.Common.BrowserTypes;
using System.Configuration;
using NOWAccountUITest.Common;
using NUnit.Framework;

namespace NOWAccountUITests.Tests
{
    [TestClass]
    [TestFixture]
    public class LoginTest
    {
        SeleniumHelper seleniumHelper;
        LoginPage loginPage;

        [TestInitialize]
        public void Start()
        {
            DriverManager.StartBrowser(BrowserType.CHROME);
            seleniumHelper = new SeleniumHelper();
            loginPage = new LoginPage();
        }

        [TestMethod]
        [TestCategory(TestCategories.REGRESSION)]
        [TestCategory(TestCategories.SMOKE)]
        [TestCategory(TestCategories.LOGIN)]
        public void Login()
        {
            seleniumHelper
                .NavigateToUrl(ConfigurationManager.AppSettings["appURL"]);
            loginPage
                .EnterEmail(ConfigurationManager.AppSettings["userEmail"])
                .EnterPassword(ConfigurationManager.AppSettings["userPassword"])
                .ClickLoginButton();
            //seleniumHelper.
            // ValidateCurrentUrl("");
        }

        [TestMethod]
        [TestCategory(TestCategories.REGRESSION)]
        [TestCategory(TestCategories.LOGIN)]
        public void LoginWithIncorrectPassword()
        {
            seleniumHelper
                .NavigateToUrl(ConfigurationManager.AppSettings["appURL"]);
            loginPage
                .EnterEmail(ConfigurationManager.AppSettings["userEmail"])
                .EnterPassword("incorrectPassword")
                .ClickLoginButton();
        }


        [TestCleanup]
        public void Stop()
        {
            DriverManager.StopBrowser();
        }

    }
}
