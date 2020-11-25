using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VCSproject.Page;
using VCSprojektas.BaigiamasisDarbas.Page;
using VCSprojektas.Drivers;
using VCSprojektas.Page;
using VCSprojektas.Tools;

namespace VCSprojektas.Test
{
    public class BaseTest
    {
        public static IWebDriver driver;
        public static BaigiamasisDarbasPage _baigiamasisDarbasPage;
        public static BaigiamasisDarbasDUKPage _baigiamasisDarbasDUKPage;
        public static BaigiamasisDarbasParduotuvesNuomaPage _baigiamasisDarbasParduotuvesNuomaPage;

        [OneTimeSetUp]
        public static void SetUp()
        {
            driver = CustomDriver.GetChromeDriver();
            _baigiamasisDarbasPage = new BaigiamasisDarbasPage(driver);
            _baigiamasisDarbasDUKPage = new BaigiamasisDarbasDUKPage(driver);
            _baigiamasisDarbasParduotuvesNuomaPage = new BaigiamasisDarbasParduotuvesNuomaPage(driver);
        }

        [TearDown]
        public static void TakeScreeshot()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
                MyScreenshot.MakeScreeshot(driver);           
        }

        [OneTimeTearDown]
        public static void TearDown()
        {
           //driver.Quit();
        }
    }
}
