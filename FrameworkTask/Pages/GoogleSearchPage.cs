using FrameworkTask.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkTask.Pages
{
    public class GoogleSearchPage : BasePage
    {
        public GoogleSearchPage(IWebDriver driver) : base(driver)
        {
            LoggerWrapper.LogInfo("Google Cloud Search Results page opened!");
        }

        private List<IWebElement> searchResultTitles => driver.FindElements(By.XPath("//a[@class='gs-title']")).ToList();


        public GoogleCalculatorPage ClickResult(string text)
        {
            wait.Until(d => searchResultTitles.Any());
            var p = searchResultTitles.FirstOrDefault(e => e.Text == text);
            p.Click();
            return new GoogleCalculatorPage(driver);
        }
    }
}
