using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCSprojektas
{
    class TestWebDriver
    {
        [Test]

        public static void TestChromeDriver()
        {
            IWebDriver chrome = new ChromeDriver();
            chrome.Url = "https://login.yahoo.com/";
            chrome.Quit();
        }

        [Test]

        public static void TestYahooPage()
        {
            IWebDriver chrome = new ChromeDriver();
            chrome.Url = "https://login.yahoo.com/";
            IWebElement loginInputField = chrome.FindElement(By.Id("login-username"));
            loginInputField.SendKeys("test");

            IWebElement loginButton = chrome.FindElement(By.Id("login-signin"));
            loginButton.Click();

            chrome.Quit();
        }

        [Test]
        public static void TestSeleniumPage()
        {

            IWebDriver chrome = new ChromeDriver();
            chrome.Url = "https://www.seleniumeasy.com/test/basic-first-form-demo.html";
            IWebElement inputField = chrome.FindElement(By.Id("user-message"));
            string myText = "Katinukai";
            inputField.SendKeys(myText);

            IWebElement button = chrome.FindElement(By.CssSelector(".btn.btn-default"));
            button.Click();
            IWebElement result = chrome.FindElement(By.Id("display"));
            Assert.AreEqual(myText, result.Text, "Tekstas neatsirado");
            chrome.Quit();
        }



        //2 pamoka 

        private static IWebDriver _driver;

        [OneTimeSetUp]
        public static void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Url = "https://www.seleniumeasy.com/test/basic-first-form-demo.html";
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            IWebElement popUp = _driver.FindElement(By.Id("at-cv-lightbox-close"));
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(d => popUp.Displayed);
            popUp.Click();
        }
        [OneTimeTearDown]
        public static void TearDown()
        {
            _driver.Quit();
        }


        [TestCase("2", "2", "4", TestName = "2 plius 2 = 4")]
        [TestCase("-5", "3", "-2", TestName = "-5 plius 3 = -2")]
        [TestCase("a", "b", "NaN", TestName = "a plius b = NaN")]

        public static void TestSeleniumPageHM1(string firstName, string secondName, string result)
        {

            IWebElement inputField1 = _driver.FindElement(By.Id("sum1"));
            IWebElement inputField2 = _driver.FindElement(By.Id("sum2"));
            inputField1.Clear();
            inputField1.SendKeys(firstName);
            inputField2.Clear();
            inputField2.SendKeys(secondName);

            _driver.FindElement(By.CssSelector("#gettotal>button")).Click();           
            IWebElement resultFromPage = _driver.FindElement(By.Id("displayvalue"));
            Assert.AreEqual(result, resultFromPage.Text, "Tekstas neatsirado");

        }







        
        [Test]
        public static void TestSeleniumPageHM2()
        {

            IWebDriver chrome = new ChromeDriver();    //pasirenkame chrome naršyklę sukūrę obj.
            chrome.Url = "https://www.seleniumeasy.com/test/basic-first-form-demo.html"; //nurodomę norimą pre-condition(šiuo atveju svetainės url).
            //Čia jau atsidarėme Google Chrome naršyklę.
            //susikuriame kintamuosius
            int num1 = -5;
            string text1 = num1.ToString();
            int num2 = 3;
            string text2 = num2.ToString();
            int resultatas = -2;
            string text3 = resultatas.ToString();

            IWebElement inputField1 = chrome.FindElement(By.Id("sum1")); // Įvedame, kad ieškome WebElement pagal jo Id, kuris yra "sum1".         
            inputField1.SendKeys(Convert.ToString(text1));

            IWebElement inputField2 = chrome.FindElement(By.Id("sum2")); // Įvedame, kad ieškome WebElement pagal jo Id, kuris yra "sum2".         
            inputField2.SendKeys(Convert.ToString(text2));

            IWebElement buttonToClick = chrome.FindElement(By.CssSelector("#gettotal>button")); // sukuriamas naujas elementas, nusakantis button .
            buttonToClick.Click();  // nurodoma,kad sukurtas naujas elementas button paspaustų ant jo .

            IWebElement result = chrome.FindElement(By.Id("displayvalue")); // resultatas(gautas tekstas)

            Assert.AreEqual(text3, result.Text, "Tekstas neatsirado"); // patikriname , ar gavome tai , ko norime.
            chrome.Quit();

        }


        [Test]
        public static void TestSeleniumPageHM3()
        {

            IWebDriver chrome = new ChromeDriver();    //pasirenkame chrome naršyklę sukūrę obj.
            chrome.Url = "https://www.seleniumeasy.com/test/basic-first-form-demo.html"; //nurodomę norimą pre-condition(šiuo atveju svetainės url).
            //Čia jau atsidarėme Google Chrome naršyklę.
            //susikuriame kintamuosius
            string char1 = "a";
            string char2 = "b";
            string resultatas = "NaN";

            IWebElement inputField1 = chrome.FindElement(By.Id("sum1")); // Įvedame, kad ieškome WebElement pagal jo Id, kuris yra "sum1".         
            inputField1.SendKeys(Convert.ToString(char1));

            IWebElement inputField2 = chrome.FindElement(By.Id("sum2")); // Įvedame, kad ieškome WebElement pagal jo Id, kuris yra "sum2".         
            inputField2.SendKeys(Convert.ToString(char2));

            IWebElement buttonToClick = chrome.FindElement(By.CssSelector("#gettotal>button")); // sukuriamas naujas elementas, nusakantis button .
            buttonToClick.Click();  // nurodoma,kad sukurtas naujas elementas button paspaustų ant jo .

            IWebElement result = chrome.FindElement(By.Id("displayvalue")); // resultatas(gautas tekstas)

            Assert.AreEqual(resultatas, result.Text, "Tekstas neatsirado"); // patikriname , ar gavome tai , ko norime.
            chrome.Quit();//uzdarome browser
        }
        //Norint konvertuoti tekstą į skaičių:
        //norint konvertuot skaičių į tekstą atvirkšsiai 
        //int skaicius = 6;
        //string text = skaicius.ToString();
        //string text = "6"';
        //int skacius = Int32.Parse(text);
    
    }
}
