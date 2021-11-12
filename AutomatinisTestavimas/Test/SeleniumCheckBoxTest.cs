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
    public class SeleniumCheckBoxTest
    {
        private static IWebDriver _driver;

        [OneTimeSetUp]
        public static void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Url = "https://demo.seleniumeasy.com/basic-checkbox-demo.html";
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            _driver.Manage().Window.Maximize();

        }

        [OneTimeTearDown]
        public static void TearDown()
        {
            //  _driver.Quit();
        }

        [Test]

        public void TestSeleniumSingleCheckbox()
        {
            SeleniumCheckBoxPage page = new SeleniumCheckBoxPage(_driver);
            string expResult = "Success - Check box is checked";
            page.ClickSingleCheckbox(true);
            page.CheckSingleCheckboxResult(expResult);
        }

        [Test]
        public void TestMultipleCheckboxButtonText()
        {
            SeleniumCheckBoxPage page = new SeleniumCheckBoxPage(_driver);
            string expResultButton = "Uncheck All";
            page.ClickAll();
            page.ClickButton();
            page.CheckMultipleCheckboxButton(expResultButton);
        }

        [Test]
        public void TestUnchecking()
        {
            SeleniumCheckBoxPage page = new SeleniumCheckBoxPage(_driver);
            page.ClickButton();
            page.AtzymejimoTikrinimas();
        }
    }
}
