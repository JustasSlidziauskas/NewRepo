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
    public class BasePage
    {
        protected static IWebDriver Driver;

            public BasePage (IWebDriver webDriver)
        {
            Driver = webDriver;
        }
         public void CloseBrowser()
        {
            Driver.Quit();
        }

    }
}
