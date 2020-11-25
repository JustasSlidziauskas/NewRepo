using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VCSproject;

namespace VCSprojektas.BaigiamasisDarbas.Page 
{
    public class BaigiamasisDarbasParduotuvesNuomaPage : BasePage
    {
        private const string PageAddress = "https://www.verskis.lt/elektronines-parduotuves-nuoma";
        private IWebElement SelectGerasStartasPackageButton => Driver.FindElement(By.CssSelector("#prices>div>div>div>div>div.prices-container>div.start>a"));
        private IWebElement PopUp => Driver.FindElement(By.CssSelector("body>div.cookieinfo>div"));
        private IWebElement PaymentPeriod6MonthsButton => Driver.FindElement(By.CssSelector("#formOrder>div:nth-child(1)>div.right>div:nth-child(3)>label>span.input"));        
        private IWebElement EshopDomainNameInput => Driver.FindElement(By.Id("domainname"));
        private IWebElement RegisterOrBuyDomainButton => Driver.FindElement(By.CssSelector("#formOrder>div:nth-child(2)>div.right>div:nth-child(3)>label>span.input"));
        private IWebElement BuyEShopLogoButton => Driver.FindElement(By.CssSelector("#formOrder>div:nth-child(4)>div.right>div:nth-child(2)>label>span.input"));
        private IWebElement PrivatePersonOrdersServisesButton => Driver.FindElement(By.CssSelector("#orderer-2>label"));
        private IWebElement PersonInChargeNameInput => Driver.FindElement(By.Id("privateName"));
        private IWebElement PhoneNumberInput => Driver.FindElement(By.Id("privatePhone"));
        private IWebElement AdressInput => Driver.FindElement(By.Id("privateAddress"));
        private IWebElement EmailInput => Driver.FindElement(By.Id("privateEmail"));
        private IWebElement WriteCommentInput => Driver.FindElement(By.Id("privateEnquiry"));
        private IWebElement ConfrimationButton => Driver.FindElement(By.CssSelector("#formOrder>div:nth-child(7)>button"));
        private IWebElement FinalPriceValue => Driver.FindElement(By.CssSelector("#order>div>div>div>div>div>div.price>span"));




        public BaigiamasisDarbasParduotuvesNuomaPage(IWebDriver webdriver) : base(webdriver) { }

        public BaigiamasisDarbasParduotuvesNuomaPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
        }
        public BaigiamasisDarbasParduotuvesNuomaPage ClickGerasStartasButton()
        {
            SelectGerasStartasPackageButton.Click();
            return this;
        }
        public BaigiamasisDarbasParduotuvesNuomaPage ClickPopUp()
        {
            PopUp.Click();
            return this;
        }
        public BaigiamasisDarbasParduotuvesNuomaPage ClickPaymentPeriod6MonthsButton()
        {
            PaymentPeriod6MonthsButton.Click();
            return this;
        }
        public BaigiamasisDarbasParduotuvesNuomaPage EnterDomainNameField(string domainName)
        {
            EshopDomainNameInput.SendKeys(domainName);
            return this;
        }
        public BaigiamasisDarbasParduotuvesNuomaPage SelectRegisterOrBuyDomainButton()
        {
            RegisterOrBuyDomainButton.Click();
            return this;
        }
        public BaigiamasisDarbasParduotuvesNuomaPage SelectBuyLogoForEsHop()
        {
            BuyEShopLogoButton.Click();
            return this;
        }

        public BaigiamasisDarbasParduotuvesNuomaPage SelectPrivatePersonForServices()
        {
            PrivatePersonOrdersServisesButton.Click();
            return this;
        }
        public BaigiamasisDarbasParduotuvesNuomaPage EnterPrivateName(string personName)
        {
            PersonInChargeNameInput.SendKeys(personName);
            return this;
        }
        public BaigiamasisDarbasParduotuvesNuomaPage  EnterPhoneNumber(string phoneNumber)
        {
            PhoneNumberInput.SendKeys(phoneNumber);
            return this;
        }
        public BaigiamasisDarbasParduotuvesNuomaPage EnterAdress(string adress)
        {
            AdressInput.SendKeys(adress);
            return this;
        }
        public BaigiamasisDarbasParduotuvesNuomaPage EnterEmail(string email)
        {
            EmailInput.SendKeys(email);
            return this;
        }
        public BaigiamasisDarbasParduotuvesNuomaPage WriteComment(string yourComment)
        {
            WriteCommentInput.SendKeys(yourComment);
            return this;
        }
        public BaigiamasisDarbasParduotuvesNuomaPage ClickConfirmation()
        {
            ConfrimationButton.Click();
            return this;
        }
        public BaigiamasisDarbasParduotuvesNuomaPage WaitForNewWindowToApear()
        {          
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
                wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#order>div>div>div>div>div>div.price>span")));
                return this;   
        }
        public BaigiamasisDarbasParduotuvesNuomaPage VerifyFinalPrice(string expectedFinalPrice)
        {
               Assert.IsTrue(FinalPriceValue.Text.Contains(expectedFinalPrice), $"Result is not the same, expected {expectedFinalPrice}, but was {FinalPriceValue.Text}");
                return this;
        }


    }
}
