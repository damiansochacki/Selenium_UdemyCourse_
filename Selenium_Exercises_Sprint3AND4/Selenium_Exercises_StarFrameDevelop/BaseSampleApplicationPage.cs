using OpenQA.Selenium;

namespace Selenium_Exercises_StarFrameDevelop
{
    internal class BaseSampleApplicationPage
    {
    protected IWebDriver Driver { get; set; }
    public BaseSampleApplicationPage(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}