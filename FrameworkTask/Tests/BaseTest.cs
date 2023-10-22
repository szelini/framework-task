using FrameworkTask.DriverManager;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;

using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkTask.Tests
{
    public class BaseTest
    {
        protected IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            var browser = System.Environment.GetEnvironmentVariable("BROWSER");
            driver = DriverProvider.GetDriverFactory(browser).CreateDriver();
            driver.Manage().Window.Maximize();
        }


        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                var screenshot = ((ITakesScreenshot)driver).GetScreenshot();

                if (!Directory.Exists(@"./screenshots/"))
                {
                    Directory.CreateDirectory(@"./screenshots");
                }
       
                screenshot.SaveAsFile($"./screenshots/{DateTime.Now:yyyy-MM-dd_HH-mm-ss.fffff}.jpg", ScreenshotImageFormat.Jpeg);
            }
            driver.Quit();
        }

       

    }
}
