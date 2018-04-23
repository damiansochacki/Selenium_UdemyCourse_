using System;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Selenium_Exercises_StarFrameDevelop
{
    [TestClass]
    [TestCategory("Sample Application One")]
    public class SampleApplicationOneTests
    {
        //#Generated field, property, there is a need to change object type to IWebDriver
        //# Next we're changing field into property by adding get/set
        //# Name of the property should start with Big letter 
        private IWebDriver Driver { get; set; }
        //Why this was generated?
        internal TestUser TheTestUser { get; private set; }
        `
        [TestMethod]
        public void TestMethod1()
        {
            //$We're creating TestUser (based on the class)
            //# We're declaring/ creating new GetChromeDriver
            //# Creating new variable which will be holding IwebDriver 
            var sampleApplicationPage = new SampleApplicationPage(Driver);
            //# Creating referance to "GoTo" method 
            sampleApplicationPage.GoTo();
            //# Creating an asssert to check whether page is visible (?) --- > Validate if we get to this page
            //# Creating new variable with parametr which will be typed into the field
            var ultimateQAHomePage = sampleApplicationPage.FillOutFormAndSubmit(TheTestUser);
            //# Checking if page locates any specific element (determines whether browser is on good page)
            Assert.IsTrue(ultimateQAHomePage.IsVisible, "UltimateqQA home page was not visible");
            //# Closing broweser after test 

        }

        [TestMethod]
        public void TestMethod2()
        {
            //$We're creating TestUser (based on the class)
            //$What shall ve 
            //# We're declaring/ creating new GetChromeDriver
            //# Creating new variable which will be holding IwebDriver 
            var sampleApplicationPage = new SampleApplicationPage(Driver);
            //# Creating referance to "GoTo" method 
            sampleApplicationPage.GoTo();
            //# Creating an asssert to check whether page is visible --- > Validate if we get to this page
            //# Creating new variable with parametr which will be typed into the field
            var ultimateQAHomePage = sampleApplicationPage.FillOutFormAndSubmit(TheTestUser);
            //# Checking if page locates any specific element (determines whether browser is on good page)
            Assert.IsFalse(!ultimateQAHomePage.IsVisible, "Page was not found");
            //# Closing broweser after test 

        }
        //# Automatically cleans before each test
        [TestCleanup]
        public void CleanUpAfterEveryTestMethod()
        {
            Driver.Close();
            Driver.Quit();
        }
        //# Creating TestInitialize to automatically create a chromedriver/ new user before each test  
        //# Changing variable to property, why is done like this?
        [TestInitialize]
        private void SetupForEverySingleTestMethod()
        {
           Driver = GetChromeDriver();
           TheTestUser = new TestUser();
           TheTestUser.FirstName = "Damiannnnn";
           TheTestUser.LastName = "Sochackiiiii";
        }

        //# Method which will open ChromeDriver
        private IWebDriver GetChromeDriver()
        {
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return new ChromeDriver(outPutDirectory);
        }
    }
}
