using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VCSprojektas.Test;

namespace VCSprojektas.BaigiamasisDarbas.Test
{
    public class BaigiamasisDarbasParduotuvesNuomaTest : BaseTest
    {
        [Order(1)]
        [Test]
        public void TestParduotuvesNuoma()
        {
            _baigiamasisDarbasParduotuvesNuomaPage.NavigateToDefaultPage()
                .ClickPopUp()
                .ClickGerasStartasButton()
                .ClickPaymentPeriod6MonthsButton()
                .EnterDomainNameField("ZirklesSakutes.lt")
                .SelectRegisterOrBuyDomainButton()
                .SelectBuyLogoForEsHop()
                .SelectPrivatePersonForServices()
                .EnterPrivateName("Jonas")
                .EnterPhoneNumber("868699777")
                .EnterAdress("Gatvės g. 8 - 88, Vilnius")
                .EnterEmail("pavarde@vardas.lt")
                .WriteComment("Neturiu komentaru")
                .ClickConfirmation()
                .WaitForNewWindowToApear()               
                .VerifyFinalPrice("346");



        }





    }
}
