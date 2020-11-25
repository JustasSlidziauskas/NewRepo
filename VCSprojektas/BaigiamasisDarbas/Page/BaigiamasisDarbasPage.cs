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
    public class BaigiamasisDarbasPage : BasePage
    {
        private const string PageAddress = "https://www.verskis.lt/";

        private IWebElement CreateEshopButton => Driver.FindElement(By.CssSelector("#try>div>div>div>div>div.holder>a"));
        private IWebElement PopUp => Driver.FindElement(By.CssSelector("body>div.cookieinfo>div"));
        private IWebElement EshopNameInput => Driver.FindElement(By.Id("tryTitle"));
        private IWebElement EshopEmailInput => Driver.FindElement(By.Id("tryEmail"));
        private IWebElement ConfirmEshopCreatingButton => Driver.FindElement(By.CssSelector("#tryFree>div.step1.clearfix>a"));
        private IWebElement EmailError => Driver.FindElement(By.Id("tryEmail-error"));

        //Dropdownlist private SelectElement CityDropdown => new SelectElement(Driver.FindElement(By.Id("city")));
        public BaigiamasisDarbasPage(IWebDriver webdriver) : base(webdriver) { }

        public BaigiamasisDarbasPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
        }
     
        public BaigiamasisDarbasPage ClickPopUp()
        {
            PopUp.Click();
            return this;
        }
        public BaigiamasisDarbasPage ClickSukurtiParduotuve()
        {
            CreateEshopButton.Click();
            return this;
        }
        public BaigiamasisDarbasPage GiveElParduotuvePavadinimas(string Eshopname)
        {
            EshopNameInput.Clear();
            EshopNameInput.SendKeys(Eshopname);
            return this;
        }
        public BaigiamasisDarbasPage GiveElParduotuvePavadinimas2(string Eshopname2)
        {
           
            EshopNameInput.SendKeys(Eshopname2);
            return this;
        }
        public BaigiamasisDarbasPage GiveElParduotuveEmail(string Email)
        {
            EshopEmailInput.Clear();
            EshopEmailInput.SendKeys(Email);
            return this;
        }
        public BaigiamasisDarbasPage ClearInputs()
        {
            EshopEmailInput.Clear();
            EshopNameInput.Clear();

            return this;
        }
        public BaigiamasisDarbasPage GiveElParduotuveEmail2(string Email2)
        {
            
            EshopEmailInput.SendKeys(Email2);
            return this;
        }
        public BaigiamasisDarbasPage ClickSukurtiElParduotuveButton()
        {
            if (!ConfirmEshopCreatingButton.Selected)
                ConfirmEshopCreatingButton.Click();
            return this;
          
        }
        public BaigiamasisDarbasPage WaitForEmailErrorMessage()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("tryEmail-error")));
            return this;
        }
        public BaigiamasisDarbasPage WaitForUserNameAndPhoneNumberToBeVisible()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("tryName")));
            return this;
        }

        public BaigiamasisDarbasPage VerifyEmailErrorMessage(string expectedResult)
        {
            Assert.IsTrue(EmailError.Text.Contains(expectedResult), $"Result is not the same, expected {expectedResult}, but was {EmailError.Text}");
            return this;           
        }
        public BaigiamasisDarbasPage CloseRegistrationWindow ()
        {
            Actions action = new Actions(Driver);
            action.SendKeys(Keys.Escape);
            action.Build().Perform();
            return this;
        }
    }
}