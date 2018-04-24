using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;

namespace Selenium_Exercises_StarFrameDevelop
{
    internal class SampleApplicationPage : BaseSampleApplicationPage
    {
        public SampleApplicationPage(IWebDriver driver) : base(driver){}
        public bool IsVisible {
            get {
                  return Driver.Title.Contains(PageTitle);
                }
            internal set
                { 
                }
                }
        private string PageTitle => "Sample Application Lifecycle - Sprint 4 - Ultimate QA";

        public IWebElement FirstNameField => Driver.FindElement(By.Name("firstname"));
        public IWebElement SubmitButton => Driver.FindElement(By.XPath("//*[@type='submit']"));
        public IWebElement LastNameField => Driver.FindElement(By.Name("lastname"));
        public IWebElement FemaleGenderRadioButton => Driver.FindElement(By.XPath("//input[@name='gender' and @value='female']"));
        public IWebElement OtherGenderRadioButton => Driver.FindElement(By.XPath("//input[@name='gender' and @value='other']"));
        public IWebElement FemaleGenderRadioButtonForEmeregencyContact => Driver.FindElement(By.Id("radio2-f"));
        public IWebElement FirstNameFieldForEmergencyContact =>  Driver.FindElement(By.Id("f2"));
        public IWebElement LastNameFieldForEmergencyContact => Driver.FindElement(By.Id("l2"));

        private void SetGender(TestUser user)
        {
            switch (user.GenderType)
            {
                case Gender.Male:
                    break;
                case Gender.Female:
                    FemaleGenderRadioButton.Click();
                    break;
                case Gender.Other:
                    OtherGenderRadioButton.Click();
                    break;
                default:
                    break;
            }
        }
        internal void FillOutEmergencyContactForm(TestUser emergencyContactUser)
        {
            SetGenderForEmergencyContact(emergencyContactUser);
            FirstNameFieldForEmergencyContact.SendKeys(emergencyContactUser.FirstName);
            LastNameFieldForEmergencyContact.SendKeys(emergencyContactUser.LastName);
        }
        private void SetGenderForEmergencyContact(TestUser user)
        {
            switch (user.GenderType)
            {
                case Gender.Male:
                    break;
                case Gender.Female:
                    FemaleGenderRadioButtonForEmeregencyContact.Click();
                    break;
                case Gender.Other:
                    OtherGenderRadioButton.Click();
                    break;
                default:
                    break;
            }
        }
        internal UltimateQAHomePage FillOutPrimaryFormAndSubmit(TestUser user)
        {
            SetGender(user);
            FirstNameField.SendKeys(user.FirstName);
            LastNameField.SendKeys(user.LastName);
            SubmitButton.Submit();
            return new UltimateQAHomePage(Driver);
        }
        internal void GoTo()
        {
            Driver.Navigate().GoToUrl("http://www.ultimateqa.com/sample-application-lifecycle-sprint-4");
            Assert.IsTrue(IsVisible, 
                $"Page was not loaded correctly! Expected => {PageTitle}.)"
                + $"Actual => {Driver.Title}");
        }
    }
}