using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyFinalExam.WebDriverFactory;
using UdemyFinalExam;

namespace UdemyFinalExam.Tests
{
    public class BaseTest
    {
        public IWebDriver Driver { get; private set; }

        [TestInitialize]
        public void SetupForEverySingleTestMethod()
        {
            var factory = new WebDriverFactory.WebDriverFactory();
            Driver = factory.Create(BrowserType.Chrome);
        }
        [TestCleanup]
        public void CleanUpAfterEveryTestMethod()
        {
          //  Driver.Close();
          //  Driver.Quit();
        }
    }
}
