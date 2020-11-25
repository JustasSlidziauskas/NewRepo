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
        private SelectElement DropDown => new SelectElement(Driver.FindElement(By.Id("select-demo")));
        private IWebElement ResultTextElement => Driver.FindElement(By.CssSelector(".selected-value"));
        private IWebElement ResultTextAllSelectedElement => Driver.FindElement(By.CssSelector(".getall-selected"));

        private SelectElement MultiDropDown => new SelectElement(Driver.FindElement(By.Id("multi-select")));

        private IWebElement FirstSelectedButton => Driver.FindElement(By.Id("printMe"));

        private IWebElement GetAllSelectedButton => Driver.FindElement(By.Id("printAll"));

        public DropdownDemoPage(IWebDriver webdriver) : base(webdriver) { }

        public DropdownDemoPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
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

        public DropdownDemoPage SelectFromMultipleDropdownAndClickFirstButton(List<string> listOfStates)
        {
            MultiDropDown.DeselectAll();
            Actions action = new Actions(Driver);
            action.KeyDown(Keys.LeftControl);
            foreach (string state in listOfStates)
            {
                foreach (IWebElement option in MultiDropDown.Options)
                {
                    if (state.Equals(option.GetAttribute("value")))
                    {
                        action.Click(option);
                        break;
                    }
                }
            }
            action.KeyUp(Keys.LeftControl);
            action.Build().Perform();
            action.Click(FirstSelectedButton);
            action.Build().Perform();
            return this;
        }

        public DropdownDemoPage ClickGetAllButton()
        {
            GetAllSelectedButton.Click();
            return this;
        }

        public DropdownDemoPage CheckListedStates(List<string> selectedElements)
        {
            string result = ResultTextAllSelectedElement.Text;
            foreach (string selectedElement in selectedElements)
            {
                Assert.True(result.Contains(selectedElement),
                    $"Should be {selectedElement}, but was {result}");
            }
            return this;
        }

        public DropdownDemoPage CheckFirstState(string selectedElement)
        {
            string result = ResultTextAllSelectedElement.Text;
            Assert.True(result.Contains(selectedElement),
                $"{selectedElement} is missing. {result}");
            return this;
        }

        public DropdownDemoPage SelectFromMultipleDropdownByValue(List<string> listOfStates)
        {
            MultiDropDown.DeselectAll();
            foreach (IWebElement option in MultiDropDown.Options)
                if (listOfStates.Contains(option.GetAttribute("value")))
                {
                    ClickMultipleBox(option);
                }
            return this;
        }

        private void ClickMultipleBox(IWebElement element)
        {
            Actions actions = new Actions(Driver);
            actions.KeyDown(Keys.Control);
            actions.Click(element);
            actions.KeyUp(Keys.Control);
            actions.Build().Perform();
        }
    }
}