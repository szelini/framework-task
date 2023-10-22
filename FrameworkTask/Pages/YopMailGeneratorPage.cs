using FrameworkTask.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkTask.Pages
{
    public class YopMailGeneratorPage : BasePage
    {
        public YopMailGeneratorPage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement copyRandomMailToClipboard => driver.FindElement(By.Id("cprnd"));

        private IWebElement inboxButton => driver.FindElement(By.XPath("//div[@class='nw']/button[2]"));

        public YopMailGeneratorPage CopyRandomEmail()
        {
            try
            {
                wait.Until(d => copyRandomMailToClipboard.Displayed);
                copyRandomMailToClipboard.Click();
            }
            catch (Exception)
            {
                LoggerWrapper.LogError("copyRandomMailToClipboard was not found, or click problem occured");
                throw;
            }
            
            return this;
        }

        public YopMailInboxPage ClickInboxButton()
        {
            wait.Until(d => inboxButton.Displayed);
            inboxButton.Click();
            return new YopMailInboxPage(driver);
        }
    }
}
