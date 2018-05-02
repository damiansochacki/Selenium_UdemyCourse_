using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Reflection;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Safari;
using UdemyFinalExam;


namespace UdemyFinalExam.WebDriverFactory
{
    public class WebDriverFactory
    {
        public IWebDriver Create(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.Chrome:
                    return GetChromeDriver();
                default:
                    throw new ArgumentOutOfRangeException("No such browser exists");
            }
        }
        private IWebDriver GetChromeDriver()
        {
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return new ChromeDriver(outPutDirectory);
        }
    }  
}
