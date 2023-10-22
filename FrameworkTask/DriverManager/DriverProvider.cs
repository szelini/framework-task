using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkTask.DriverManager
{
   
    public class DriverProvider
    {
        public static BaseDriverFactory GetDriverFactory(string browser)
        {
            
            return browser switch
            {
                "CHROME" => new ChromeDriverFactory(),
                "EDGE" => new EdgeDriverFactory(),
                _ => new ChromeDriverFactory()
            };
        }
    }
}

