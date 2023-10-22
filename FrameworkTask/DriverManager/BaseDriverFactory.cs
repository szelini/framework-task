using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkTask.DriverManager
{
    public abstract class BaseDriverFactory
    {
        public abstract IWebDriver CreateDriver();
    }
}
