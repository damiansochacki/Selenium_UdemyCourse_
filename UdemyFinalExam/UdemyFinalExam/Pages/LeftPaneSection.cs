using OpenQA.Selenium;

namespace UdemyFinalExam.Pages
{
    public class LeftPaneSection : BaseApplicationPage
    {
        public LeftPaneSection(IWebDriver driver) : base(driver)
        { }
        public IWebElement SearchForm => Driver.FindElements(By.XPath("//form[@role='search']"))[1];
        public IWebElement SearchBox => Driver.FindElements(By.XPath("//form[@role='search']//input[@id='s']"))[0];
        public IWebElement SearchButton => Driver.FindElement(By.Id("searchsubmit"));

        public SearchResultsPage Search(string searchString)
        {
            SearchBox.SendKeys(searchString);
            SearchButton.Click();
            return new SearchResultsPage(Driver);
        }
    }
}