using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyFinalExam.Pages;
using UdemyFinalExam;
using OpenQA.Selenium;

namespace UdemyFinalExam.Tests
{
    [TestClass]
    [TestCategory("SearchingFeature"), TestCategory("SampleApp2")]
    public class SearchFunctionality : BaseTest
    {
        //***************************************
        public bool IsLoaded
        {
            get
            {
                try
                {
                    return CenterColumn.Displayed;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            }
        }
        public IWebElement CenterColumn => Driver.FindElement(By.Id("center_column"));

        public bool IsLoadedSignInPage
        {
            get
            {
                try
                {
                    return Driver.Title.Contains(SignInColumn);
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            }
        }
        public string SignInColumn => "Login - My Storeeee";

   
        //***************************************

        [TestMethod]
        [TestProperty("Author", "NikolayAdvolodkin")]
        public void TCID1()
        {
            string stringToSearch = "blouse";
            HomePage homePage = new HomePage(Driver);
            homePage.GoTo();
            SearchPage searchPage = homePage.Search(stringToSearch);
            Assert.IsTrue(searchPage.Contains(Item.Blouse),
                $"When searching for the string=>{stringToSearch}, " +
                $"we did not find it in the search results.");
        }
        [TestMethod]
        [NUnit.Framework.Description("Zadanie numer 4")]
        [TestProperty("Author", "DamianSochacki")]
        public void TCID4()
        {
            //#Open automation practice page
            //#Click the Contact us button
            //#Validate that page was opened
            HomePage homePage = new HomePage(Driver);
            homePage.GoTo();
            Assert.IsTrue(homePage.IsPageLoaded, "Home page did not open successfully");
            var contactUsPage = homePage.Header.ClickContactUsButton();
            Assert.IsTrue(contactUsPage.IsLoaded, "The contact us page did not open succesfully");
        }
        [TestMethod]
        [NUnit.Framework.Description("Zadanie numer 5, Sign in button")]
        [TestProperty("Author", "DamianSochacki")]
        public void TCID5()
        {
            //#Open automation practice page
            //#Click the "Sign In" button
            //#Validate that page was opened
            //Opening driver/homepage by creating new object
            HomePage homePage = new HomePage(Driver);
            homePage.GoTo();
            Assert.IsTrue(homePage.IsPageLoaded, "Home page did not open successfully");
            var singInPage = homePage.Header.ClickSignInButton();
            Assert.IsTrue(singInPage.IsLoaded, "Sign in page did not open succesfully");
        }
        [TestMethod]
        [NUnit.Framework.Description("Zadanie numer 6, Sign in button")]
        [TestProperty("Author", "DamianSochacki")]
        public void TCID6()
        {
            ComplicatedPage complicatedPage = new ComplicatedPage(Driver);
            complicatedPage.GoTo();
            Assert.IsTrue(complicatedPage.IsLoaded, "The complicated page did not opened successfully");
            complicatedPage.RandomStuffSection.FillOutFormAndSubmit("Moje Imie", "MAIL@O2.PL", "Moja wiadomość");
            Assert.IsTrue(complicatedPage.RandomStuffSection.IsFormSubmitted, "Form was not submitted successfully");
        }
        [TestMethod]
        [NUnit.Framework.Description("Zadanie numer 7, Sign in button")]
        [TestProperty("Author", "DamianSochacki")]
        public void TCID7()
        {
            ComplicatedPage complicatedPage = new ComplicatedPage(Driver);
            complicatedPage.GoTo();
            Assert.IsTrue(complicatedPage.IsLoaded, "The complicated page did not opened successfully");
            var searchResults = complicatedPage.RandomStuffSection.LeftPane.Search("selenium errors");
            Assert.IsTrue(searchResults.IsLoaded, "Form was not loaded succesfully");

        }
    }
}
