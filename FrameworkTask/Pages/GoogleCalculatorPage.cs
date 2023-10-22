using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameworkTask.Utilities;

namespace FrameworkTask.Pages
{
    public class GoogleCalculatorPage : BasePage
    {
        public GoogleCalculatorPage(IWebDriver driver) : base(driver)
        {
            LoggerWrapper.LogInfo("Google Cloud Pricing Calculator page opened!");
        }



        private IWebElement mainFrame => driver.FindElement(By.CssSelector("iframe[name*='goog_']"));

        private IWebElement innerFrame => driver.FindElement(By.Id("myFrame"));

        private IWebElement computeEngineIcon => driver.FindElement(By.CssSelector(".tab-holder.compute"));

        private IWebElement numberOfInstancesInput => driver.FindElement(By.Id("input_99"));

        private IWebElement operationSystemSelect => driver.FindElement(By.XPath("//*[@ng-model='listingCtrl.computeServer.os']"));

        private IWebElement provisioningModelSelect => driver.FindElement(By.XPath("//*[@ng-model='listingCtrl.computeServer.class']"));

        private IWebElement seriesSelect => driver.FindElement(By.XPath("//*[@ng-model='listingCtrl.computeServer.series']"));

        private IWebElement machineTypeSelect => driver.FindElement(By.XPath("//*[@ng-model='listingCtrl.computeServer.instance']"));

        private IWebElement addGPUCheckbox => driver.FindElement(By.XPath("//*[@ng-model='listingCtrl.computeServer.addGPUs']"));

        private IWebElement typeOfGPUSelect => driver.FindElement(By.XPath("//*[@ng-model='listingCtrl.computeServer.gpuType']"));

        private IWebElement numberOfGPUSelect => driver.FindElement(By.XPath("//*[@ng-model='listingCtrl.computeServer.gpuCount']"));

        private IWebElement localSSDSelect => driver.FindElement(By.XPath("//*[@ng-model='listingCtrl.computeServer.ssd']"));

        private IWebElement locationSelect => driver.FindElement(By.XPath("//*[@ng-model='listingCtrl.computeServer.location']"));

        private IWebElement committedUsageSelect => driver.FindElement(By.XPath("//*[@ng-model='listingCtrl.computeServer.cud']"));

        private IWebElement addToEstimateButton => driver.FindElement(By.XPath("//button[@ng-click='listingCtrl.addComputeServer(ComputeEngineForm);']"));

        public IWebElement emailEstimateIcon => driver.FindElement(By.Id("Email Estimate"));

        public IWebElement emailInput => driver.FindElement(By.XPath("//input[@type='email']"));

        public IWebElement emailSend => driver.FindElement(By.XPath("//form[@name='emailForm']//button[2]"));

        public IWebElement priceText => driver.FindElement(By.XPath("//*[@id='resultBlock']//h2[2]"));

        public GoogleCalculatorPage SwitchToInnerFrame()
        {
            wait.Until(d => mainFrame.Displayed);
            driver.SwitchTo().Frame(mainFrame);
            wait.Until(d => innerFrame.Displayed);
            driver.SwitchTo().Frame(innerFrame);
            return this;
        }

        private void SelectOptionFromDropDown(string value)
        {
            IWebElement selectOption = wait.Until(d => driver.FindElement(By.XPath($"//div[contains(@class, 'md-clickable')]//md-option[@value='{value}']")));
            selectOption.Click();

        }

        public GoogleCalculatorPage SwitchToDefault()
        {
            driver.SwitchTo().DefaultContent();
            return this;
        }

        public GoogleCalculatorPage ClickComputeEngineIcon()
        {

            wait.Until(d => computeEngineIcon.Displayed);
            computeEngineIcon.Click();
            return this;
        }

        public GoogleCalculatorPage SetNumberOfInstances(string numberOfInstances)
        {
            try
            {
                wait.Until(d => numberOfInstancesInput.Displayed);
                numberOfInstancesInput.SendKeys(numberOfInstances);
            }
            catch (Exception)
            {
                LoggerWrapper.LogError("numberOfInstancesInput was not found");
                throw;
            }
            
            return this;
        }

        public GoogleCalculatorPage SetOperatingSystem(string operatingSystem)
        {
            try
            {
                wait.Until(d => operationSystemSelect.Displayed);
                operationSystemSelect.Click();
                SelectOptionFromDropDown(operatingSystem);
            }
            catch (Exception)
            {
                LoggerWrapper.LogError("operationSystemSelect was not found, or select from dropdown doesn't work");
                throw;
            }
            
            return this;
        }

        public GoogleCalculatorPage SetProvisioningModel(string provisioningModel)
        {
            try
            {
                wait.Until(d => provisioningModelSelect.Displayed);
                provisioningModelSelect.Click();
                SelectOptionFromDropDown(provisioningModel);
            }
            catch (Exception)
            {
                LoggerWrapper.LogError("provisioningModelSelect was not found, or select from dropdown doesn't work");
                throw;
            }
           
            return this;
        }

        public GoogleCalculatorPage SetSeries(string series)
        {
            try
            {
                wait.Until(d => seriesSelect.Displayed);
                seriesSelect.Click();
                SelectOptionFromDropDown(series);
            }
            catch (Exception)
            {
                LoggerWrapper.LogError("seriesSelect was not found, or select from dropdown doesn't work");
                throw;
            }
            
            return this;
        }

        public GoogleCalculatorPage SetMachineType(string machineType)
        {
            try
            {
                wait.Until(d => machineTypeSelect.Displayed);
                machineTypeSelect.Click();
                SelectOptionFromDropDown(machineType);
            }
            catch (Exception)
            {
                LoggerWrapper.LogError("machineTypeSelect was not found, or select from dropdown doesn't work");
                throw;
            }
            
            return this;
        }

        public GoogleCalculatorPage SetGPUType(string GPUType)
        {

            addGPUCheckbox.Click();
            wait.Until(d => typeOfGPUSelect.Displayed);
            new Actions(driver).ScrollToElement(typeOfGPUSelect);
            typeOfGPUSelect.Click();
            SelectOptionFromDropDown(GPUType);
            return this;
        }

        public GoogleCalculatorPage SetNumberOfGPUs(string numberOfGPUs)
        {
            try
            {
                wait.Until(d => numberOfGPUSelect.Displayed);
                new Actions(driver).ScrollToElement(numberOfGPUSelect);
                numberOfGPUSelect.Click();
                SelectOptionFromDropDown(numberOfGPUs);
            }
            catch (Exception)
            {
                LoggerWrapper.LogError("numberOfGPUSelect was not found, or select from dropdown doesn't work");
                throw;
            }
            
            return this;
        }



        public GoogleCalculatorPage SetLocalSSD(string localSSD)
        {
            try
            {
                wait.Until(d => localSSDSelect.Displayed);
                new Actions(driver).ScrollToElement(localSSDSelect);
                localSSDSelect.Click();
                SelectOptionFromDropDown(localSSD);
            }
            catch (Exception)
            {
                LoggerWrapper.LogError("localSSDSelect was not found, or select from dropdown doesn't work");
                throw;
            }
            
            return this;
        }

        public GoogleCalculatorPage SetLocation(string location)
        {
            try
            {
                wait.Until(d => locationSelect.Displayed);
                new Actions(driver).ScrollToElement(locationSelect);
                locationSelect.Click();
                SelectOptionFromDropDown(location);
            }
            catch (Exception)
            {
                LoggerWrapper.LogError("locationSelect was not found, or select from dropdown doesn't work");
                throw;
            }
           
            return this;
        }

        public GoogleCalculatorPage SetCommittedUsage(string years)
        {
            try
            {
                wait.Until(d => committedUsageSelect.Displayed);
                new Actions(driver).ScrollToElement(committedUsageSelect);
                committedUsageSelect.Click();
                SelectOptionFromDropDown(years);
            }
            catch (Exception)
            {
                LoggerWrapper.LogError("committedUsageSelect was not found, or select from dropdown doesn't work");
                throw;
            }
           
            return this;
        }

        public GoogleCalculatorPage ClickAddToEstimateButton()
        {
            wait.Until(d => addToEstimateButton.Displayed);
            new Actions(driver).ScrollToElement(addToEstimateButton);
            addToEstimateButton.Click();
            return this;
        }

        public GoogleCalculatorPage ClickEmailIcon()
        {
            wait.Until(d => emailEstimateIcon.Displayed);
            emailEstimateIcon.Click();
            return this;
        }

        public GoogleCalculatorPage SetEmail()
        {
            wait.Until(d => emailInput.Displayed);
            wait.Until(d => emailSend.Displayed);

            new Actions(driver)
                .SendKeys(Keys.Tab)
                .SendKeys(Keys.Tab)
                .KeyDown(Keys.Control)
                .SendKeys("v")
                .KeyUp(Keys.Control)
                .Build().Perform();

            emailSend.Click();

            return this;

        }

        public string GetPriceText()
        {
            wait.Until(d => priceText.Displayed);
            return priceText.Text.Replace(" / mo", "").Trim();
        }

    }
}
