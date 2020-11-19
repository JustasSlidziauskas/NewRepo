using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace VCSproject.Page
{
    public class DropdownDemoPage : BasePage
    {

        private const string PageAddress = "https://www.seleniumeasy.com/test/basic-select-dropdown-demo.html";

        private const string ResultText = "Day selected :- ";
        private const string FirstSelectedStateResultText = "First selected option is : ";

        private SelectElement DropDown => new SelectElement(Driver.FindElement(By.Id("select-demo")));

        private IWebElement ResultTextElement => Driver.FindElement(By.CssSelector(".selected-value"));

        private SelectElement MultiDropDown => new SelectElement(Driver.FindElement(By.Id("multi-select")));

        private IWebElement FirstSelectedButton => Driver.FindElement(By.Id("printMe"));

        private IWebElement GetAllSelectedButton => Driver.FindElement(By.Id("printAll"));
        private IWebElement SelectedButtonResult => Driver.FindElement(By.CssSelector(".getall-selected"));

        public DropdownDemoPage(IWebDriver webdriver) : base(webdriver)
        {
            Driver.Url = PageAddress;
        }

        public DropdownDemoPage SelectFromDropdownByText(string text)
        {
            DropDown.SelectByText(text);
            return this;
        }

        public DropdownDemoPage SelectFromDropdownByValue(string text)
        {
            DropDown.SelectByValue(text);
            return this;
        }

        public DropdownDemoPage VerifyResult(string selectedDay)
        {
            Assert.AreEqual(ResultTextElement.Text, ResultText + selectedDay, $"Result is wrong, not {selectedDay}");
            return this;
        }

        public DropdownDemoPage SelectFromMultipleDropdownByValue(List<string> listOfStates)
        {
            Actions action = new Actions(Driver);
            action.KeyDown(Keys.Control);
            foreach (IWebElement option in MultiDropDown.Options)
            {
                if (listOfStates.Contains(option.GetAttribute("value")))
                {
                    action.Click(option);
                }
            }
            action.KeyUp(Keys.Control);
            action.Build().Perform();
            return this;
        }

        public DropdownDemoPage ClickFirstSelectedButton()
        {
            FirstSelectedButton.Click();
            return this;
        }

        public DropdownDemoPage ClickAllSelectedButton()
        {   
            GetAllSelectedButton.Click();
            return this;
        }


        public DropdownDemoPage VerifyMultiDropDownFirstResult(string firstSelectedState)
        {
            Assert.AreEqual("First selected option is : "+ firstSelectedState,SelectedButtonResult.Text, $"Result is wrong, not {firstSelectedState}");
            return this;
        }
        public DropdownDemoPage VerifyMultiDropDownMultitResult(string SelectedAllstates)
        {
            Assert.AreEqual("Options selected are : " + SelectedAllstates, SelectedButtonResult.Text, $"Result is wrong, not {SelectedAllstates}");
            return this;
        }



    }
}