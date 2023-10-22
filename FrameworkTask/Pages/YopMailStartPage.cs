using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkTask.Pages
{
    public class YopMailStartPage : BasePage
    {

        private const string PAGE_URL = "https://yopmail.com/";

        public YopMailStartPage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement? necessaryCookiesButton => driver.FindElements(By.Id("necesary")).FirstOrDefault();

        private IWebElement randomEmailGeneratorLink => driver.FindElement(By.CssSelector("a[href='email-generator']"));





        public YopMailStartPage OpenPage()
        {
            driver.Navigate().GoToUrl(PAGE_URL);
            return this;
        }

        public YopMailStartPage ClickAllowCookies()
        {
            if (necessaryCookiesButton != null)
            {
                necessaryCookiesButton.Click();
            }
            return this;
        }

        public YopMailGeneratorPage ClickRandomEmailGeneratorLink()
        {

            wait.Until(d => randomEmailGeneratorLink.Displayed);
            randomEmailGeneratorLink.Click();
            return new YopMailGeneratorPage(driver);
        }

    }
}
