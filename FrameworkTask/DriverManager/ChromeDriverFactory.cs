using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkTask.DriverManager
{
    public class ChromeDriverFactory : BaseDriverFactory
    {
        public override IWebDriver CreateDriver()
        {
            var options = new ChromeOptions();
            return new ChromeDriver();
        }

    }
}

