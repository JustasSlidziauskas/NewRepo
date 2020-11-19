using System;
using System.Collections;
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
    public class DropdownDemoTest
    {
        private static DropdownDemoPage _page;

        [OneTimeSetUp]
        public static void SetUp()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            _page = new DropdownDemoPage(driver);
        }

        [OneTimeTearDown]
        public static void TearDown()
        {
            _page.CloseBrowser();
        }
        [Order(1)]
        [Test]
        public void TestDropdown()
        {
            _page.SelectFromDropdownByText("Friday")
                .VerifyResult("Friday");
        }
        [Order(2)]
        [TestCase("New Jersey", "California", TestName = "Pasirenkame 2 valstijas ir patikriname first selected atsakyma")]

        public void TestMultipleDropdownFirstSelect2(params string[] selectedElements)
        {
            _page.SelectFromMultipleDropdownByValue(selectedElements.ToList())
                .ClickFirstSelectedButton()
                .VerifyMultiDropDownFirstResult("New Jersey");
        }
        [Order(3)]
        [TestCase("New Jersey", "California", TestName = "Pasirenkame 2 valstijas ir patikriname get all selected atsakyma")]
        public void TestMultipleDropdownGetAllSelect2(params string[] selectedElements)
        {
            _page.SelectFromMultipleDropdownByValue(selectedElements.ToList())
                .ClickAllSelectedButton()
              .VerifyMultiDropDownMultitResult("New Jersey, California");
        }
        [Order(4)]
        [TestCase("New Jersey", "California", "Ohio", TestName = "Pasirenkame 3 valstijas ir patikriname first all selected atsakyma")]
        public void TestMultipleDropdownFirstSelect3(params string[] selectedElements)
        {
            _page.SelectFromMultipleDropdownByValue(selectedElements.ToList())
                .ClickFirstSelectedButton()
                .VerifyMultiDropDownFirstResult("New Jersey");
        }
        [Order(5)]
        [TestCase("New Jersey", "California", "Ohio", "Texas", TestName = "Pasirenkame 4 valstijas ir patikriname get all selected atsakyma")]
        public void TestMultipleDropdownGetAllSelect3(params string[] selectedElements)
        {
            _page.SelectFromMultipleDropdownByValue(selectedElements.ToList())
                .ClickAllSelectedButton()
              .VerifyMultiDropDownMultitResult("New Jersey,California,Ohio,Texas");
        }
    }
}