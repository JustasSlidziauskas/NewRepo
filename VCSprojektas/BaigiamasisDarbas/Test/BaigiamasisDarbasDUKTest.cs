using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VCSprojektas.Test;

namespace VCSprojektas.BaigiamasisDarbas.Test
{
    public class BaigiamasisDarbasDUKTest : BaseTest
    {
        [Order(1)]
        [Test]

        public void TestGiveUsAQuestion()
        {
            _baigiamasisDarbasDUKPage.NavigateToDefaultPage()
                .ClickPopUp()
                .ClickGiveUsAQuestionLink()
                .WaitForWriteUsWindow()
                .EnterYourName("Petras")
                .EnterCompanyName("Bebrynas")
                .EnterYourEmail("nezinau@petraitis.lt")
                .EnterPhoneNumber("868655845")
                .WriteYourInquiry("Neturiu ka pakomentuoti")
                .SendInquiry()
                .WaitForclickRobotButton()
                .CloseAskUsAQuestionTab()
                .VerifyErrorMessage("aš ne robotas");

        }

        [Order(2)]
        [Test]

        public void AskAQuestionPage()
        {
            _baigiamasisDarbasDUKPage.NavigateToDefaultPage()
              //.ClickPopUp()
              .AskUsName("John")
              .AskUsPhone("86867954896")
              .AskUsEmail("jonas@email.lt")
              .AskUsCompanyName("Laturplanedusena")
              .AskUsEnquiry("Noreciau suzinoti apie jus")
              .AskUsClickSendEnquiryButton()
              .AskUsWaitForErrorMessage()
              .AskUsVerifyErrorMessage("aš ne robotas");
            
        }
    }
}
