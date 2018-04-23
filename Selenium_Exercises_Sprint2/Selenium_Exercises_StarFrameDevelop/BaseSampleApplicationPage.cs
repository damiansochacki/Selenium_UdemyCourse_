using OpenQA.Selenium;

namespace Selenium_Exercises_StarFrameDevelop
{
    internal class BaseSampleApplicationPage
    {
        //# It's procteced so child classes can access it
    protected IWebDriver Driver { get; set; }

    //# Constructor creation 
    public BaseSampleApplicationPage(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}