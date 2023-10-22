using FrameworkTask.Pages;
using FrameworkTask.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkTask.Tests
{
    [TestFixture]
    public class CalculatorTests : BaseTest
    {

        private const string SEARCHPAGE_SEARCH = "Google Cloud Platform Pricing Calculator";
        private const string SEARCHPAGE_RESULT = "Google Cloud Pricing Calculator";


        [Test]
        [Category("Smoke")]
        public void GoogleCludCalculatorTest()
        {
            var machine = VirtualMachineCreator.CreateVirtualMachine();

            var startPage = new GoogleStartPage(driver)
                .OpenPage();

            var calculatorPage = startPage
                .Search(SEARCHPAGE_SEARCH)
                .ClickResult(SEARCHPAGE_RESULT);

            calculatorPage.SwitchToInnerFrame()
                .ClickComputeEngineIcon()
                .SetNumberOfInstances(machine.NumberOfInstances)
                .SetOperatingSystem(machine.OperatingSystem)
                .SetProvisioningModel(machine.ProvisioningModel)
                .SetSeries(machine.Series)
                .SetMachineType(machine.MachineType)
                .SetGPUType(machine.GPUType)
                .SetNumberOfGPUs(machine.NumberOfGPUs)
                .SetLocalSSD(machine.LocalSSD)
                .SetLocation(machine.DatacenterLocation)
                .SetCommittedUsage(machine.CommittedUsage)
                .ClickAddToEstimateButton();

            string priceInEstimateBlock = calculatorPage.GetPriceText();

            calculatorPage.ClickEmailIcon();

            driver.SwitchTo().NewWindow(WindowType.Tab);

            YopMailStartPage yopMailStartPage = new YopMailStartPage(driver).OpenPage();

            YopMailGeneratorPage yopMailGeneratorPage = yopMailStartPage.ClickAllowCookies()
                .ClickRandomEmailGeneratorLink()
                .CopyRandomEmail();

            driver.SwitchTo().Window(driver.WindowHandles[0]);

            calculatorPage.SwitchToInnerFrame().SetEmail();

            driver.SwitchTo().Window(driver.WindowHandles[1]);

            YopMailInboxPage yopMailInboxPage = yopMailGeneratorPage.ClickInboxButton();

            string priceInYopMail = yopMailInboxPage.GetPriceText();

            StringAssert.AreEqualIgnoringCase(priceInYopMail, priceInEstimateBlock);

        }

    }
}

