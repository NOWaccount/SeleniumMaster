using NOWAccountUITests.Common;
using OpenQA.Selenium;

namespace NOWAccountUITests.Pages
{
    public class BasePageElement
    {
        protected IWebDriver driver;
       
        public BasePageElement()
        {
            this.driver = DriverManager.Driver;
        }
    }
}
