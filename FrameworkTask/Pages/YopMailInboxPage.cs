using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkTask.Pages
{
    public class YopMailInboxPage : BasePage
    {
        public YopMailInboxPage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement mailCount => driver.FindElement(By.Id("nbmail"));

        private IWebElement mailFrame => driver.FindElement(By.Id("ifmail"));

        private IWebElement priceText => driver.FindElement(By.XPath("//table/tbody/tr[2]/td[2]/h3"));

        private YopMailInboxPage SwitchToInnerFrame()
        {
            wait.Until(d => mailFrame.Displayed);
            driver.SwitchTo().Frame(mailFrame);
            return this;
        }

        public string GetPriceText()
        {

            for (int i = 0; i < 10; i++)
            {
                if (wait.Until(d => mailCount.Displayed) && mailCount.Text == "0 mail")
                {
                    driver.Navigate().Refresh();
                }
                else
                {
                    break;
                }
            }
           
            SwitchToInnerFrame();

            wait.Until(d => priceText.Displayed);
            return priceText.Text.Replace("USD", "").Trim();
        }
    }
}
