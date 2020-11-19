using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using System;

namespace VCSprojektas
{
    class HM2
    {
        private static IWebDriver _driver;

        [OneTimeSetUp]
        public static void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("https://www.active.com/fitness/calculators/pace");           
            _driver.Manage().Window.Maximize();
            _driver.FindElement(By.CssSelector("#page-wrapper > aside > div > header > span")).Click();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.FindElement(By.CssSelector("body > div.optanon-alert-box-wrapper > div.optanon-alert-box-bg > div.optanon-alert-box-button-container > div.optanon-alert-box-button.optanon-button-allow > div > button")).Click();
        }

        [OneTimeTearDown]
        public static void TearDown()
        {
         _driver.Quit();
        }

        [Test]

        public static void TestRunningPace()
        {          
            string expres = "05";
            IWebElement hoursInput = _driver.FindElement(By.Name("time_hours"));
            hoursInput.Clear();
            hoursInput.SendKeys("1");
            IWebElement minutesInput = _driver.FindElement(By.Name("time_minutes"));
            minutesInput.Clear();
            minutesInput.SendKeys("5");
            IWebElement kilometers = _driver.FindElement(By.Name("distance"));
            kilometers.Clear();
            kilometers.SendKeys("13");
            //kilometers
            _driver.FindElement(By.CssSelector("#calculator-pace > form > div:nth-child(3) > div > span > span > span.selectboxit-text")).Click();
            _driver.FindElement(By.CssSelector("#calculator-pace > form > div:nth-child(3) > div > span > ul > li.selectboxit-option.selectboxit-option-first")).Click();
            //per km
            _driver.FindElement(By.CssSelector("#calculator-pace > form > div:nth-child(4) > div > span > span > span.selectboxit-arrow-container")).Click();
            _driver.FindElement(By.CssSelector("#calculator-pace > form > div:nth-child(4) > div > span > ul > li.selectboxit-option.selectboxit-option-first")).Click();
            IWebElement calculateResult = _driver.FindElement(By.CssSelector("#calculator-pace > form > div:nth-child(6) > div > a"));
            calculateResult.Click();
            IWebElement actualResult = _driver.FindElement(By.Name("pace_minutes"));           
            Assert.AreEqual(expres,actualResult.GetAttribute("value"), "Incorrect running pace") ; 
        }
    }
}
