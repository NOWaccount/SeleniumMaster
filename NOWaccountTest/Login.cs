using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace NOWaccountTest
{
    class Login
    {
        // This makes the driver static VS putting it inside the Main method
        static IWebDriver driver = new ChromeDriver(".");
        //static IWebElement textBox;

        // Login Page Elements
        static IWebElement textBoxEmail;
        static IWebElement textBoxPass;
        static IWebElement loginButton;

        // Security page Elements
        static IWebElement securityQuestion;
        static IWebElement securityAnswer;
        static IWebElement submitButton;

        // Phone number skip element
        static IWebElement skipButton;

        static void Main()
        {
           
            string url = "https://app.nowaccount.com";

            driver.Navigate().GoToUrl(url);

            //textBoxEmail = driver.FindElement(By.Id("Email"));
            textBoxPass = driver.FindElement(By.Id("Password"));

            // Try to find the Email Input Element
            try
            {
                textBoxEmail = driver.FindElement(By.Id("Email"));

                if (textBoxEmail.Displayed)
                {
                    textBoxEmail.SendKeys("tabibone@gmail.com");
                    GreenMessage("I see Email input field and filled out my email");
                }
            }
            catch (NoSuchElementException)
            {
                RedMessage("I do not see the Email input field");
            }

            // Try to find the Password Input Element
            try
            {
                textBoxPass = driver.FindElement(By.Id("Password"));

                if (textBoxPass.Displayed)
                {
                    textBoxPass.SendKeys("NowPass123!");
                    GreenMessage("I see the Password input field and filled out my password");
                }
            }
            catch (NoSuchElementException)
            {
                RedMessage("I do not see the Password input field");
            }

            // What to put inside text box after finding it
            //textBoxEmail.SendKeys("tabish.akhtar@nowcorp.com");
            //textBoxPass.SendKeys("NowPass123!");

            try
            {
                loginButton = driver.FindElement(By.CssSelector("body > div.container-fluid > div > div > div.panel > div > form > div > div:nth-child(2) > input"));

                if (textBoxEmail.GetAttribute("value") != "" && textBoxPass.GetAttribute("value") != "")
                {
                    loginButton.Click();
                    Console.WriteLine("I see the Login Button and have clicked it");
                }
            }
            catch (NoSuchElementException)
            {
                RedMessage("I do not see the Login button");
            }



            Thread.Sleep(3000);

            // Second page of registration is to read the question and answer it

            // X path Selector for text 
            // /html/body/div[1]/div/div/div/div/form/div/div/div/div[1]/label


            // Submit button
            // name = submitAction

            // Input field for answer
            // name = AnswerText OR ID = AnswerText

            // Skip phone number
            // ID = skipRequirePhoneNumber

            string securityText1 = "What is the name of your favorite pet?";
            string securityText2 = "What is the make (such as Ford) of your first car?";
            string securityText3 = "What is the name of your favorite Superhero?";

            //new WebDriverWait(driver, TimeSpan.FromSeconds(20)).Until(ExpectedConditions.ElementIsVisible(By.CssSelector("label[for='AnswerText']"))).GetAttribute("innerHTML"); ;

            try
            {
                securityQuestion = driver.FindElement(By.TagName("label"));
                securityAnswer = driver.FindElement(By.XPath("//*[@id='AnswerText']"));
                submitButton = driver.FindElement(By.Name("submitAction"));

                Console.WriteLine("question is ", securityQuestion);

                if (securityAnswer.Displayed)
                {
                    GreenMessage("I see the security answer input field");
                    securityAnswer.SendKeys("saad");
                    //submitButton.Click();
                    //GreenMessage("I have clicked the submit button after answering the security question.");
                }
            }
            catch (NoSuchElementException)
            {
                RedMessage("I do not see the Security question");
            }



            Thread.Sleep(3000);


            //securityQuestion = driver.FindElement(By.TagName("label"));
            //securityAnswer = driver.FindElement(By.XPath("//*[@id="AnswerText"]"));

            //securityQuestion = driver.

            //securityQuestion = securityQuestion.GetAttribute("value");

            //Console.WriteLine("question is ", securityQuestion.GetAttribute("innerHTML").Length);


            //if(securityQuestion = securityText1)
            //{
            //    securityAnswer = driver.FindElement(By.Name("AnswerText"));
            //    securityAnswer.SendKeys("Saad");
            //}
            //else if (securityQuestion = securityText2)
            //{
            //    securityAnswer = driver.FindElement(By.Name("AnswerText"));
            //    securityAnswer.SendKeys("Nissan");
            //}
            //else if (securityQuestion = securityText3)
            //{
            //    securityAnswer = driver.FindElement(By.Name("AnswerText"));
            //    securityAnswer.SendKeys("Green lantern");
            //}




            //driver.Quit();


        }

        private static void RedMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.Black;
        }

        private static void GreenMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.Black;
        }

    }
}
