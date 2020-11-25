using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using VCSproject.Page;
using VCSprojektas.Test;

namespace VCSproject.Test
{
    public class BaigiamasisDarbasTest : BaseTest

    {

        [Test]

        public void TestEshopCreatingInputs()
        {
            _baigiamasisDarbasPage.NavigateToDefaultPage()
                .ClickPopUp()
                .ClickSukurtiParduotuve()
                .GiveElParduotuvePavadinimas("VCSshop60")
                .GiveElParduotuveEmail("89897845")              
                .ClickSukurtiElParduotuveButton()
                .WaitForEmailErrorMessage()
                .VerifyEmailErrorMessage("Įveskite el. pašto adresą")
                .CloseRegistrationWindow();
        }
        [Test]

        public void TestEshopCreatingInputs2()
        {
            _baigiamasisDarbasPage.NavigateToDefaultPage()
                //.ClickPopUp()
                .ClickSukurtiParduotuve()
                .ClearInputs()
                .GiveElParduotuvePavadinimas("GrybuParduotuve")
                .GiveElParduotuveEmail("12354")
                .ClickSukurtiElParduotuveButton()
                .WaitForEmailErrorMessage()
               .VerifyEmailErrorMessage("Įveskite el. pašto adresą");

        }



    }
}