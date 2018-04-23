using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;

namespace Selenium_Exercises_StarFrameDevelop
{
    internal class SampleApplicationPage : BaseSampleApplicationPage
    {

        //# Constructor 
        public SampleApplicationPage(IWebDriver driver) : base(driver){}

        //# Possiblity to determine function as a bool version with yes/no answer 
        //# Single locator 
        public bool IsVisible {
            //# Get always needs to return something 
            get {
                return Driver.Title.Contains(PageTitle);
                }
            internal set
            { }
                               }
        public IWebElement FirstNameField => Driver.FindElement(By.Name("firstname"));
        public IWebElement SubmitButton => Driver.FindElement(By.XPath("//*[@type='submit']"));
        public IWebElement LastNameField => Driver.FindElement(By.Name("lastname"));

        private string PageTitle => "Sample Application Lifecycle - Sprint 3 - Ultimate QA";

        //# Another class with field to fill in
        //# There is a possiblity to change firstname/lastname to another class - Test User 
        internal UltimateQAHomePage FillOutFormAndSubmit(TestUser user)
        {
        //# We're looking for two elements by: class and xpath 
        //# We're "promising" returning to UltiateQAHomePage 
        //# Creation of property: FirstNameField/ SubmitButton 
        //$ We're changing inner values into user.FirstName/ user.LastName
           FirstNameField.SendKeys(user.FirstName);
           LastNameField.SendKeys(user.LastName);
           SubmitButton.Submit();
        //# We need to return class which is UltimateQAHomePage
        //# We need to also create a constructor with the returning value 
            return new UltimateQAHomePage(Driver);
        }

        //# GoTo method which 
        internal void GoTo()
        {
            Driver.Navigate().GoToUrl("http://www.ultimateqa.com/sample-application-lifecycle-sprint-3");
            // #Assert is put into GoTo method 
            Assert.IsTrue(IsVisible, 
                $"Page was not loaded correctly! Expected => {PageTitle}.)"
                + $"Actual => {Driver.Title}");
        }
    }
}