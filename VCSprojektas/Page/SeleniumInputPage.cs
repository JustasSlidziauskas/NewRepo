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
    public class SeleniumInputPage
    {
        private static IWebDriver _driver;
        private IWebElement loginInputField => _driver.FindElement(By.Id("user-message"));
        private IWebElement loginButton => _driver.FindElement(By.CssSelector("#get-input > button"));
        private IWebElement result => _driver.FindElement(By.Id("display"));
        private IWebElement inputField1 => _driver.FindElement(By.Id("sum1"));
        private IWebElement inputField2 => _driver.FindElement(By.Id("sum2"));
        private IWebElement getTotalButton => _driver.FindElement(By.CssSelector("#gettotal>button"));
        private IWebElement resultFromPage => _driver.FindElement(By.Id("displayvalue"));


        public SeleniumInputPage(IWebDriver webDriver)
         {
            _driver = webDriver;
         }

        public void InsertText(string text)
        {
            loginInputField.Clear();
            loginInputField.SendKeys(text);
        }

        public void ClickShowMessageButton()
        {
            loginButton.Click();
        }

        public void CheckResult(string expectedResult)
        {
            Assert.AreEqual(expectedResult, result.Text, "Tekstas neatsirado");
        }

        public void InsertFirstInput(string text)
        {
            inputField1.Clear();
            inputField1.SendKeys(text);
        }
        public void InsertSecondInput(string text)
        {
            inputField2.Clear();
            inputField2.SendKeys(text);
        }

        public void InsertBothInputs(string first,string second)
        {
            InsertFirstInput(first);
            InsertSecondInput(second);
        }


        public void ClickGetTotalButton()
        {
            getTotalButton.Click();
        }

        public void CheckSumResult(string expectedResultSum)
        {
            Assert.AreEqual(expectedResultSum, resultFromPage.Text, "Tekstas neatsirado");

        }

    }
}
