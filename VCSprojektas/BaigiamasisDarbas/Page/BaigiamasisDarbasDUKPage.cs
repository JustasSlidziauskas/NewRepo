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
    public class BaigiamasisDarbasDUKPage : BasePage
    {
        private const string PageAddress = "https://www.verskis.lt/duk";

        private IWebElement PopUp => Driver.FindElement(By.CssSelector("body>div.cookieinfo>div"));

        private IWebElement GiveUsAQuestionButton => Driver.FindElement(By.CssSelector("#view>div>div>div>div>h3>a"));

        private IWebElement EnterYourNameInput => Driver.FindElement(By.Id("writeName"));
        private IWebElement EnterYourCompanyNameInput => Driver.FindElement(By.Id("writeCompany"));
        private IWebElement EnterYourEmailNameInput => Driver.FindElement(By.Id("writeEmail"));
        private IWebElement EnterYourPhoneNumberInput => Driver.FindElement(By.Id("writePhone"));
        private IWebElement EnterYourInquiryInput => Driver.FindElement(By.Id("writeEnquiry"));
        private IWebElement ClickImNotRobotButton => Driver.FindElement(By.Id("recaptcha-anchor-label"));
        private IWebElement ClickSendInquiryButton => Driver.FindElement(By.CssSelector("#writeMessage>button"));
        private IWebElement ErrorMessageClickImNotRobot => Driver.FindElement(By.CssSelector("#writeMessage>div.form_group.recaptcha>label"));
        private IWebElement CloseGiveUsAQuestion => Driver.FindElement(By.CssSelector("#writeMessageModal>div>div>div.modal-header>button"));
        public BaigiamasisDarbasDUKPage(IWebDriver webdriver) : base(webdriver) { }

        public IWebElement AskUsNameInput => Driver.FindElement(By.Id("name"));
        public IWebElement AskUsPhoneNumberInput => Driver.FindElement(By.Id("phone"));
        public IWebElement AskUsEmailInput => Driver.FindElement(By.Id("email"));
        public IWebElement AskUsCompanyNameInput => Driver.FindElement(By.Id("companyname"));
        public IWebElement AskUsEnquiryInput => Driver.FindElement(By.Id("enquiry"));
        public IWebElement AskUsClickImNotRobotButton => Driver.FindElement(By.Id("recaptcha-anchor"));
        public IWebElement AskUsClickGiveEnquiryButton => Driver.FindElement(By.CssSelector("#formQuestion>input"));
        public IWebElement AskUsImNotRobotErrorMessage => Driver.FindElement(By.CssSelector("#formQuestion>div.form_group.recaptcha>label"));



        public BaigiamasisDarbasDUKPage AskUsName(string name)
        {
            AskUsNameInput.SendKeys(name);
            return this;
        }
        public BaigiamasisDarbasDUKPage AskUsPhone(string phoneNumber)
        {
            AskUsPhoneNumberInput.SendKeys(phoneNumber);
            return this;
        }
        public BaigiamasisDarbasDUKPage AskUsEmail(string email)
        {
            AskUsEmailInput.SendKeys(email);
            return this;
        }
        public BaigiamasisDarbasDUKPage AskUsCompanyName(string companyName)
        {
            AskUsCompanyNameInput.SendKeys(companyName);
            return this;
        }
        public BaigiamasisDarbasDUKPage AskUsEnquiry(string textOfEnquiry)
        {
            AskUsEnquiryInput.SendKeys(textOfEnquiry);
            return this;
        }
        public BaigiamasisDarbasDUKPage AskUsClickSendEnquiryButton()
        {
            AskUsClickGiveEnquiryButton.Click();
            return this;
        }
        public BaigiamasisDarbasDUKPage AskUsWaitForErrorMessage()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#formQuestion>div.form_group.recaptcha>label")));
            return this;
        }
        public BaigiamasisDarbasDUKPage AskUsVerifyErrorMessage(string AskUsResult)
        {
            Assert.IsTrue(AskUsImNotRobotErrorMessage.Text.Contains(AskUsResult), $"Result is not the same, expected {AskUsResult}, but was {AskUsImNotRobotErrorMessage.Text}");
            return this;
        }











        public BaigiamasisDarbasDUKPage NavigateToDefaultPage()
            {
                if (Driver.Url != PageAddress)
                    Driver.Url = PageAddress;
                return this;
            }
        public BaigiamasisDarbasDUKPage ClickPopUp()
        {
            PopUp.Click();
            return this;
        }
        public BaigiamasisDarbasDUKPage ClickGiveUsAQuestionLink()
        {
            GiveUsAQuestionButton.Click();
            return this;
        }
        public BaigiamasisDarbasDUKPage WaitForWriteUsWindow()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#writeMessageModal>div>div>div.modal-body")));
            return this;
        }
        public BaigiamasisDarbasDUKPage EnterYourName(string name)
        {
            EnterYourNameInput.SendKeys(name);
            return this;
        }
        public BaigiamasisDarbasDUKPage EnterCompanyName (string companyName)
        {
            EnterYourCompanyNameInput.SendKeys(companyName);
            return this;
        }
        public BaigiamasisDarbasDUKPage EnterYourEmail(string email)
        {
            EnterYourEmailNameInput.SendKeys(email);
            return this;
        }
        public BaigiamasisDarbasDUKPage EnterPhoneNumber(string phoneNumber)
        {
            EnterYourPhoneNumberInput.SendKeys(phoneNumber);
            return this;
        }
        public BaigiamasisDarbasDUKPage WriteYourInquiry(string text)
        {
            EnterYourInquiryInput.SendKeys(text);
            return this;
        }       
        public BaigiamasisDarbasDUKPage WaitForNotRobotComfirmation()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#recaptcha-anchor>div.recaptcha-checkbox-checkmark")));
            return this;
        }
        public BaigiamasisDarbasDUKPage SendInquiry()
        {
            ClickSendInquiryButton.Click();
            return this;
        }
        public BaigiamasisDarbasDUKPage WaitForclickRobotButton()
        { 
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#writeMessage>div.form_group.recaptcha>label")));
            return this;
        }
        public BaigiamasisDarbasDUKPage VerifyErrorMessage(string expectedResult)
        {
            Assert.IsTrue(ErrorMessageClickImNotRobot.Text.Contains(expectedResult), $"Result is not the same, expected {expectedResult}, but was {ErrorMessageClickImNotRobot.Text}");
            return this;
        }
        public BaigiamasisDarbasDUKPage CloseAskUsAQuestionTab()
        {
            CloseGiveUsAQuestion.Click();
                return this;
        }




    }
}
