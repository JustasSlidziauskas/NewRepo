using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VCSprojektas.Page;

namespace VCSprojektas.Test
{
    public class SeleniumCheckBoxTest
    {
        private static IWebDriver _driver;

        [OneTimeSetUp]
        public static void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("https://www.seleniumeasy.com/test/basic-checkbox-demo.html");
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.Manage().Window.Maximize();
            //_driver.FindElement(By.Id("cookiescript_reject")).Click(); jeigu bus cookies 
        }

        [OneTimeTearDown]
        public static void TearDown()
        {
            _driver.Quit();
        }

        [Test]
        public void TestSeleniumInputFirstCechkBox()
        {
            SeleniumCheckBoxPage page = new SeleniumCheckBoxPage(_driver);

            page.ClickCheckBox();
            page.CheckResult("checked");
        }

        [Test]
        public void TestSeleniumMultiCechkBox()
        {
            SeleniumCheckBoxPage page = new SeleniumCheckBoxPage(_driver);

            page.ClickMultipleCheckBox();
            page.MultipleCheckBoxResult("Uncheck All");
        }







    }
}
