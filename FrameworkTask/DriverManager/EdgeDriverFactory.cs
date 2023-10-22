using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkTask.DriverManager
{ 
    public class EdgeDriverFactory : BaseDriverFactory
    {
        public override IWebDriver CreateDriver()
        {
            return new EdgeDriver();
        }
    }
}
