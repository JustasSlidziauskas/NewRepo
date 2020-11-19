using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VCSproject;

namespace VCSprojektas.Page
{
    public class VartuTechnikaPage : BasePage
    {

        private static IWebDriver _driver;

        private IWebElement _widthInput => _driver.FindElement(By.Id("doors_width"));

        private IWebElement _heighInput => _driver.FindElement(By.Id("doors_height"));

        private IWebElement _autoCheckbox => _driver.FindElement(By.Id("automatika"));

        private IWebElement _montavimoCheckbox => _driver.FindElement(By.Id("darbai"));

        private IWebElement _calculateButton => _driver.FindElement(By.Id("calc_submit"));

        private IWebElement _resultBox => _driver.FindElement(By.CssSelector("#calc_result > div"));


        public VartuTechnikaPage(IWebDriver webdriver) : base(webdriver) { }
      
        public VartuTechnikaPage InsertWidth(string width)
        {
            _widthInput.Clear();
            _widthInput.SendKeys(width);
            return this;
        }
        public VartuTechnikaPage InsertHeight(string height)
        {
            _heighInput.Clear();
            _heighInput.SendKeys(height);
            return this;

        }
        public VartuTechnikaPage InsertWidthAndHeight(string width, string height)
        {
            InsertWidth(width);
            InsertHeight(height);
            return this;
        }

        public VartuTechnikaPage checkAutomatikaCheckbox(bool shouldBeChecked)
        {
            if (shouldBeChecked != _autoCheckbox.Selected)
                _autoCheckbox.Click();
            return this;
        }

        public VartuTechnikaPage checkMontavimoDarbai(bool shouldBeChecked)
        {
            if (shouldBeChecked != _montavimoCheckbox.Selected)
                _montavimoCheckbox.Click();
            return this;

        }
        public VartuTechnikaPage ClickCalculateButton()
        {
            _calculateButton.Click();
            return this;

        }

        public VartuTechnikaPage checkResult(string expectedResult)
        {
            WaitForResult();
            Assert.IsTrue(_resultBox.Text.Contains(expectedResult), $"Result is not the same, expented {expectedResult}, but was {_resultBox.Text}");
            return this;

        }
        private VartuTechnikaPage WaitForResult()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(d => _resultBox.Displayed);
            return this;

        }
    }
}
