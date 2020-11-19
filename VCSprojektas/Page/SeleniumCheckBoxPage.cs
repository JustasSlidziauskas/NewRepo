using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using VCSprojektas.Page;

namespace VCSproject.Page
{
    public class CheckboxDemoPage : BasePage
    {
        private const string PageAddress = "https://www.seleniumeasy.com/test/basic-checkbox-demo.html";
        private const string TextToCheck = "Success - Check box is checked";
        private IWebElement SingleCheckbox => Driver.FindElement(By.Id("isAgeSelected"));
        private IWebElement Text => Driver.FindElement(By.Id("txtAge"));
        private IReadOnlyCollection<IWebElement> MultipleCheckboxList => Driver.FindElements(By.CssSelector(".cb1-element"));
        private IWebElement Button => Driver.FindElement(By.Id("check1"));

        public CheckboxDemoPage(IWebDriver webdriver) : base(webdriver)
        {
            Driver.Url = PageAddress;
        }

        public CheckboxDemoPage CheckSingleCheckbox()
        {
            if (!SingleCheckbox.Selected)
                SingleCheckbox.Click();
            return this;
        }

        public CheckboxDemoPage CheckResult()
        {
            Assert.IsTrue(Text.Text.Equals(TextToCheck));
            return this;
        }

        private void UncheckFirstBlockCheckbox()
        {
            if (SingleCheckbox.Selected)
                SingleCheckbox.Click();
        }

        public CheckboxDemoPage CheckAllCheckboxes()
        {
            UncheckFirstBlockCheckbox();
            foreach (IWebElement element in MultipleCheckboxList)
            {
                if (!element.Selected)
                    element.Click();
            }
            return this;
        }

        public CheckboxDemoPage CheckButtonValue(string value)
        {
            GetWait(3).Until(ExpectedConditions.TextToBePresentInElementValue(Button, "Uncheck All"));
            Assert.IsTrue(Button.GetAttribute("value").Equals(value), "Seconds are wrong");
            return this;
        }

        public CheckboxDemoPage ClickButton()
        {
            Button.Click();
            return this;
        }

        public CheckboxDemoPage VerifyThatAllCheckboxesAreUnchecked()
        {
            foreach (IWebElement element in MultipleCheckboxList)
            {
                Assert.False(element.Selected, "Checkbox is still checked");
                Assert.IsTrue(!element.Selected, "Checkbox is still checked");
                Assert.That(!element.Selected, "Checkbox is still checked");
            }
            return this;
        }
    }
}