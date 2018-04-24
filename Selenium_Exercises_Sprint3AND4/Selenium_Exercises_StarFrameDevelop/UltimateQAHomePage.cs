using OpenQA.Selenium;

namespace Selenium_Exercises_StarFrameDevelop
{
    internal class UltimateQAHomePage : BaseSampleApplicationPage
    {
        private IWebDriver Driver { get; set; }
        public UltimateQAHomePage(IWebDriver driver) : base(driver){}
        public bool IsVisible
        {
            get
            {
                try
                {
                    return StartHereButton.Displayed;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            }
        }
        public IWebElement StartHereButton => Driver.FindElement(By.LinkText("Start here"));
    }
}