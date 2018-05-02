﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyFinalExam.Pages
{
    internal class ContactUsPage : BaseApplicationPage
    {
        public ContactUsPage(IWebDriver driver) : base(driver)
        {
        }

        public bool IsLoaded
        {
            get
            {
                try
                {
                    return CenterColumn.Displayed;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            }
        }

        public IWebElement CenterColumn => Driver.FindElement(By.Id("center_column"));

        internal void GoTo()
        {
            Driver.Navigate().
                GoToUrl("http://automationpractice.com/index.php?controller=contact");
        }
    }
}
