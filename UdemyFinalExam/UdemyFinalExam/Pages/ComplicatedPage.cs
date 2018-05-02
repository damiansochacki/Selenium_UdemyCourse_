using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyFinalExam.Pages
{
    public class ComplicatedPage : BaseApplicationPage
    {
        public ComplicatedPage(IWebDriver driver) : base(driver)
        {
        }
        public void GoTo()
        {
            Driver.Navigate().GoToUrl("http://www.ultimateqa.com/complicated-page/");
        }
        public bool IsLoaded
        {
            get
            {
                var isLoaded = Driver.Url.Contains("complicated-page");
                return isLoaded;
            }
        }
        // Propert that returns the class 
        public RandomStuffSection RandomStuffSection => new RandomStuffSection(Driver);
        public LeftPaneSection LeftPane => new LeftPaneSection(Driver);
    }
}
