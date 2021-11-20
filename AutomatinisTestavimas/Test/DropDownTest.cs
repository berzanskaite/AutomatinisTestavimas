using AutomatinisTestavimas.Drivers;
using AutomatinisTestavimas.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatinisTestavimas.Test
{
    public class DropDownTest : BaseTest
    {
        

        [Test]
        public void TestDropDown()
        {
            _dropDownPage.NavigateToDefaultPage()
                .SelectFromDropDownByText("Friday")
                .VerifyResult("Friday");
        }

        //[TestCase("Ohio", "Texas", TestName = "1 Ohio, 2 Texas")]
        //[TestCase("Florida", "California", TestName = "1 Florida, 2 California")]
        //[TestCase("Pennsylvania", "Ohio", TestName = "1 Pennsylvania, 2 Ohio")]
        //[TestCase("New Jersey", "Florida", TestName = "1 New Jersey, 2 Florida")]
        //[TestCase("New York", "Texas", TestName = "1 New York, 2 Texas")]
        //public void TestMultiSelect(string first, string second)
        //{

        //    _page.SelectFromMultiDropDownByValue(first, second)
        //        .ClickButtonFirstSelected()
        //        .CheckResultFirstSelected(first);

        //}
        [Test]
        public void TestMultiSelect()
        {

            _dropDownPage.NavigateToDefaultPage()
                .SelectFromMultiDropDownByValue("Texas", "Ohio")
                .ClickButtonFirstSelected()
                .CheckResultFirstSelected("Texas");

        }

        [Test]
        public void TestMultiSelect2()
        {
            List<string> states = new List<string> { "Pennsylvania", "Ohio", "Texas" };
            _dropDownPage.NavigateToDefaultPage()
                .SelectFromMultipleDropDownByValue(states)
                .ClickButtonFirstSelected()
                .CheckResultFirstSelected("Pennsylvania");
        }


        

    }
}
