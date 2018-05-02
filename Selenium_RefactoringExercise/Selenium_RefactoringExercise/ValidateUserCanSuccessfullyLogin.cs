using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Selenium_RefactoringExercise
{
    [TestClass]
    public class ValidateUserCanSuccessfullyLogin
    {
        [TestMethod]
        public void RunTest()
        {
         //Creating new instance of the Chrome driver - goal will be to change it to WebFactor
           var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.qtptutorial.net/wp-login.php");

            var user = driver.FindElement(By.Id("user_login"));
            user.SendKeys("seleniumTestUser");

            var pass = driver.FindElement(By.Id("user_pass"));
            pass.SendKeys("Test12233");

            driver.FindElement(By.Id("wp-submit")).Click();

            var loggedInHeader = driver.FindElement(By.XPath("//h1[text() ='My membership']"));
            Assert.IsTrue(loggedInHeader.Displayed, "The user was not able to successfully login.");
        }


    }
}
