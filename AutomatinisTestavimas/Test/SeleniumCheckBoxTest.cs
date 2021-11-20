//using AutomatinisTestavimas.Page;
//using NUnit.Framework;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
//using OpenQA.Selenium.Support.UI;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace AutomatinisTestavimas.Test
//{
//    public class SeleniumCheckBoxTest
//    {
//        //kodėl? buvo iwebdriver _driver + SetUpo metode _driver pasikeitė į driver, prisidėjo _page
//        private static SeleniumCheckBoxPage _page;

//        [OneTimeSetUp]
//        public static void SetUp()
//        {
//            IWebDriver driver = new ChromeDriver();
//            driver.Url = "https://demo.seleniumeasy.com/basic-checkbox-demo.html";
//            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
//            driver.Manage().Window.Maximize();
//            _page = new SeleniumCheckBoxPage(driver);

//        }

//        [OneTimeTearDown]
//        public static void TearDown()
//        {
//            //_driver.Quit();
//        }

//        [Test]
//        //[Order(1)]
//        public void TestSeleniumSingleCheckbox()
//        {
//            SeleniumCheckBoxPage page = new SeleniumCheckBoxPage(_driver);
//            string expResult = "Success - Check box is checked";
//            page.ClickSingleCheckbox(true);
//            page.CheckSingleCheckboxResult(expResult);
//        }

//        [Test]
//        public void TestMultipleCheckboxButtonText()
//        {
//            SeleniumCheckBoxPage page = new SeleniumCheckBoxPage(_driver);
//            string expResultButton = "Uncheck All";
//            page.ClickAll();
//            page.ClickButton();
//            page.CheckMultipleCheckboxButton(expResultButton);

//            //DefaultWait.Until(ExpectedConditions.TextToBePresentInElement(_button, "Uncheck All"))
//        }

//        [Test]
//        public void TestUnchecking()
//        {
//            SeleniumCheckBoxPage page = new SeleniumCheckBoxPage(_driver);
//            page.ClickButton();
//            page.AtzymejimoTikrinimas();
//        }
//    }
//}
