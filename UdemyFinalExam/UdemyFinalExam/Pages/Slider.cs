using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyFinalExam.Pages
{
    public class Slider : BaseApplicationPage
    {
        public Slider(IWebDriver driver) : base(driver)
        {
        }

        public string CurrentImage => MainSliderImage.GetAttribute("style");

        private IWebElement MainSliderImage => Driver.FindElement(By.Id("homeslider"));

        internal void ClickNextButton()
        {
            Driver.FindElement(By.ClassName("bx-next")).Click();
        }
    }
}
