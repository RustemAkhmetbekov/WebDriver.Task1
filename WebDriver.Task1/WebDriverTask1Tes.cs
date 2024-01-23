using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.AccessControl;
using OpenQA.Selenium.Interactions;

namespace WebDriver.Task1
{
    class WebDriverTask1Tes
    {
        private IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
        }

        [TearDown]
        protected void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void webDriverTask1()
        {
            driver.Navigate().GoToUrl("https://pastebin.com/");
            driver.Manage().Window.Maximize();
            driver.FindElement(By.Id("postform-text")).SendKeys("Hello from WebDriver");

            {
                IWebElement dropdown = driver.FindElement(By.Id("postform-expiration"));

                // Create a JavaScriptExecutor
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

                // Execute the JavaScript to unhide the dropdown
                js.ExecuteScript("arguments[0].style.visibility='visible';", dropdown);

                SelectElement selectElement = new SelectElement(dropdown);
                selectElement.SelectByValue("10M");
            }
            driver.FindElement(By.Id("postform-name")).SendKeys("helloweb");
        }
    }
}