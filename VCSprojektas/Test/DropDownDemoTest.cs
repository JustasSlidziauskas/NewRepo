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
using VCSprojektas.Drivers;
using VCSprojektas.Test;

namespace VCSproject.Test
{ } 
/*public class DropdownDemoTest : BaseTest
  {
     [Test]
     public void TestDropdown()
     {
         _dropdownDemoPage.NavigateToDefaultPage()
             .SelectFromDropdownByText("Friday")
             .VerifyResult("Friday");
     }

     [TestCase("New Jersey", "California", TestName = "Pasirenkame 2 reiksmes ir patikriname pirma pasirinkima")]
     [TestCase("Washington", "Ohio", "Texas", TestName = "Pasirenkame 3 reiksmes ir patikriname pirma pasirinkima")]
     public void TestMultipleDropdown(params string[] selectedElements)
     {
         _dropdownDemoPage.NavigateToDefaultPage()
             .SelectFromMultipleDropdownAndClickFirstButton(selectedElements.ToList())
             .CheckFirstState(selectedElements[0]);

     }

     [TestCase("New Jersey", "California", TestName = "Pasirenkame 2 reiksmes ir patikriname visus pasirinkimus")]
     [TestCase("Washington", "Ohio", "Texas", "Florida", TestName = "Pasirenkame 4 reiksmes ir patikriname visus pasirinkimus")]
     public void TestMultipleDropdownGetAll(params string[] selectedElements)
     {
         _dropdownDemoPage.NavigateToDefaultPage()
             .SelectFromMultipleDropdownByValue(selectedElements.ToList())
             .ClickGetAllButton()
             .CheckListedStates(selectedElements.ToList());
     }
 }
}*/