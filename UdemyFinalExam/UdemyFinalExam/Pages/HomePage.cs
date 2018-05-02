using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyFinalExam.Pages
{
    internal class HomePage : BaseApplicationPage
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
            Slider = new Slider(driver);
        }

        public Slider Slider { get; internal set; }

        public bool IsPageLoaded
        {
            get
            {
                try
                {
                    return Driver.Title.Contains(PageTitle);
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            }
        }
        public string PageTitle => "My Store";
        public HeaderSection Header => new HeaderSection(Driver);

        internal void GoTo()
        {
            Driver.Navigate().GoToUrl("http://automationpractice.com");
        //    Assert.IsTrue(IsLoaded,
          //      $"Application page was not visible. Page which is expected => {PageTitle}." +
          //      $"Loaded page is => {Driver.Title}."
            //    );
        }
        internal SearchPage Search(string itemToSearchFor)
        {
            Driver.FindElement(By.Id("search_query_top")).SendKeys(itemToSearchFor);
            Driver.FindElement(By.Name("submit_search")).Click();
            return new SearchPage(Driver);
        }
    }
}
