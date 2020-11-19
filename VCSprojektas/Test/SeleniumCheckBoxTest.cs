using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using VCSproject.Page;

namespace VCSproject.Test
{
    public class CheckboxDemoTest
    {
        private static CheckboxDemoPage _checkboxDemoPage;

        [OneTimeSetUp]
        public static void SetUp()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            _checkboxDemoPage = new CheckboxDemoPage(driver);
        }

        [OneTimeTearDown]
        public static void TearDown()
        {
            _checkboxDemoPage.CloseBrowser();
        }

        [Order(1)]
        [Test]
        public void TestSingleCheckbox()
        {
            _checkboxDemoPage.CheckSingleCheckbox()
                .CheckResult();
        }

        [Order(2)]
        [Test]
        public void TestCheckAllCheckboxes()
        {
            _checkboxDemoPage.CheckAllCheckboxes()
                .CheckButtonValue("Uncheck All");
        }

        [Order(3)]
        [Test]
        public void TestUncheckAllCheckboxes()
        {
            _checkboxDemoPage.CheckAllCheckboxes()
                .ClickButton()
                .VerifyThatAllCheckboxesAreUnchecked();
        }

    }
}