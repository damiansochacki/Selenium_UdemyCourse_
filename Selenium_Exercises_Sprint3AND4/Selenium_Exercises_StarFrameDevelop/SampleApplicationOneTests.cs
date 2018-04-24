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
        private IWebDriver Driver { get; set; } 
        internal SampleApplicationPage SampleAppPage { get; private set; }
        internal TestUser TheTestUser { get; private set; }
        internal TestUser EmergencyContactUser { get; private set; }

        [TestMethod]
        [Description("Validate that the user is able to full out the form successfully using valid data")]
        public void TestMethod1()
        {
            SetGenderTypes(Gender.Female, Gender.Female);
            SampleAppPage.GoTo();
            SampleAppPage.FillOutEmergencyContactForm(EmergencyContactUser);
            var ultimateQAHomePage = SampleAppPage.FillOutPrimaryFormAndSubmit(TheTestUser);
            AssertPageVisible(ultimateQAHomePage);
        }

        [TestMethod]
        public void TestMethod2()
        {
            SampleAppPage.GoTo();
            var ultimateQAHomePage = SampleAppPage.FillOutPrimaryFormAndSubmit(TheTestUser);
            AssertPageVisible2(ultimateQAHomePage);
        }

        [TestMethod]
        public void TestMethod3()
        {
            TheTestUser.GenderType = Gender.Other;
            EmergencyContactUser.GenderType = Gender.Other;
            SampleAppPage.GoTo();
            var ultimateQAHomePage = SampleAppPage.FillOutPrimaryFormAndSubmit(TheTestUser);
            Assert.IsFalse(!ultimateQAHomePage.IsVisible, "Page was not found");

        }
        [TestCleanup]
        public void CleanUpAfterEveryTestMethod()
        {
            Driver.Close();
            Driver.Quit();
        }
        [TestInitialize]
        public void SetupForEverySingleTestMethod()
        {

           Driver = GetChromeDriver();
           SampleAppPage = new SampleApplicationPage(Driver);
           TheTestUser = new TestUser();
           TheTestUser.FirstName = "Damian";
           TheTestUser.LastName = "Sochacki";

            EmergencyContactUser = new TestUser();
            EmergencyContactUser.FirstName = "Emergency First Name";
            EmergencyContactUser.LastName = "Emergency Last Name";
        }
        private IWebDriver GetChromeDriver()
        {
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return new ChromeDriver(outPutDirectory);
        }
        private static void AssertPageVisible(UltimateQAHomePage ultimateQAHomePage)
        {
            Assert.IsTrue(ultimateQAHomePage.IsVisible, "UltimateqQA home page was not visible");
        }
        private static void AssertPageVisible2(UltimateQAHomePage ultimateQAHomePage)
        {
            Assert.IsFalse(!ultimateQAHomePage.IsVisible, "Page was not found");
        }
        private void SetGenderTypes(Gender primaryContact,  Gender emergencyContact)
        {
            TheTestUser.GenderType = primaryContact;
            EmergencyContactUser.GenderType = primaryContact;
        }
    }

}
