using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyFinalExam.Pages
{
        public class HeaderSection : BaseApplicationPage
        {

            public HeaderSection(IWebDriver driver) : base(driver)
            {
            }
            public IWebElement ContactUsButton => Driver.FindElement(By.Id("contact-link"));
            public IWebElement SignInButton => Driver.FindElement(By.ClassName("login"));

            internal ContactUsPage ClickContactUsButton()
            {
                ContactUsButton.Click();
                return new ContactUsPage(Driver);
            }

            internal SignInPage ClickSignInButton()
            {
                SignInButton.Click();
                return new SignInPage(Driver);
            }
        }   
}
