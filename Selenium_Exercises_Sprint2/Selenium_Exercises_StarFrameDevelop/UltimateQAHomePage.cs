using OpenQA.Selenium;

namespace Selenium_Exercises_StarFrameDevelop
{
    internal class UltimateQAHomePage : BaseSampleApplicationPage
    {
        //# Changning that into property, why it cannot be like previous? 
        private IWebDriver Driver { get; set; }

        //#Constructor which takes an instance of the base driver 
        public UltimateQAHomePage(IWebDriver driver) : base(driver){}
        //# We're checking wheter element (link text value) can be found/seen and displayed 

        //#We're refactorring method to get/ trycatch exception 
        public bool IsVisible
        {
            get
            {
                try
                {
                    //# returning whether startherebutton is displayed 
                    return StartHereButton.Displayed;
                }
                //# Changing pure message into smooth one 
                catch (NoSuchElementException)
                {
                    return false;
                }
            }
        }
        public IWebElement StartHereButton => Driver.FindElement(By.LinkText("Start here"));
    }
}