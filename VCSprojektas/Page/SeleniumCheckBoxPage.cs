using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCSprojektas.Page
{
    public class SeleniumCheckBoxPage 
    {

        private static IWebDriver _driver;
        private IWebElement checkboxclick => _driver.FindElement(By.Id("isAgeSelected"));
        private IWebElement checkBoxResult => _driver.FindElement(By.Id("txtAge"));


        public SeleniumCheckBoxPage(IWebDriver webDriver)
        {
            _driver = webDriver;
        }

        public void ClickCheckBox()
        {
            checkboxclick.Click();           
        }
        private void WaitForResultBox()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(d => checkBoxResult.Displayed);
        }

        public void CheckResult(string expectedResult)
        {
            WaitForResultBox();
            Assert.IsTrue(checkBoxResult.Text.Contains(expectedResult), $"Result is not the same, expented {expectedResult}, but was {checkBoxResult.Text}");
        }

    }
}
