using FrameworkTask.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkTask.Pages
{
    public class GoogleStartPage : BasePage
    {
        private const string PAGE_URL = "https://cloud.google.com/";

        IWebElement searchInput => driver.FindElement(By.CssSelector("input[name='q']"));

        public GoogleStartPage(IWebDriver driver) : base(driver)
        {
        }

        public GoogleStartPage OpenPage()
        {
            driver.Navigate().GoToUrl(PAGE_URL);
            LoggerWrapper.LogInfo("Google Cloud starting page opened!");
            return this;
        }

        public GoogleSearchPage Search(string text)
        {
            searchInput.Click();
            searchInput.SendKeys($"{text}{Keys.Enter}");
            return new GoogleSearchPage(driver);
        }

    }
}
