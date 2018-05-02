using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_RefactoringExercise
{
    class ValidateUserCanSuccessfullyLogin3
    {
        static IWebDriver driver = new ChromeDriver();

        [TestMethod]
        public void RunTest()
        {
            //Future implementation ideas 
            //Creating new instance of the Chrome driver - goal will be to change it to WebFactor
            //GoTo inside base class (which inherits)
            GoTo();
            Login("seleniumTestUser", "Test1234567");
            var loggedInHeader = driver.FindElement(By.XPath("//h1[text() ='My membership']"));
            Assert.IsTrue(loggedInHeader.Displayed, "The user was not able to successfully login.");
        }

        public void Login(string username, string password)
        {
            SendKeys("user_login", username);
            SendKeys("user_pass", password);
            ClickButton("wp-submit");
        }

        public void SendKeys(string id, string value)
        {
            var user = driver.FindElement(By.Id(id));
            user.SendKeys(value);
        }
        public void ClickButton(string id)
        {
            driver.FindElement(By.Id(id)).Click();
        }
        public void GoTo()
        {
            driver.Navigate().GoToUrl("https://www.qtptutorial.net/wp-login.php");
        }

    }
}
