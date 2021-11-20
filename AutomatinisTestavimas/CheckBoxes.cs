using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatinisTestavimas
{
    class CheckBoxes
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
        public static void TestChekBoxes()
        {
            IWebElement firstCheckBox = _driver.FindElement(By.Id("isAgeSelected"));
            if (firstCheckBox.Selected)
            {
                firstCheckBox.Click();
            }
            IReadOnlyCollection<IWebElement> multipleCheckBoxList = _driver.FindElements(By.CssSelector(".cb1-element"));
            foreach(IWebElement element in multipleCheckBoxList)
            {
                element.Click();
            }

            IWebElement button = _driver.FindElement(By.Id("check1"));
            button.GetProperty("value");
            Assert.IsTrue(button.GetProperty("value").Equals("Uncheck All"));
        }

        [Test]
        public static void TestCheckBoxes2()
        {
            IWebElement button = _driver.FindElement(By.Id("check1"));
            if (button.GetProperty("value").Equals("Uncheck All"))
            {
                button.Click();
            }

            IReadOnlyCollection<IWebElement> multipleCheckBoxList = _driver.FindElements(By.ClassName("cb1-element"));
            int kiek = 0;
            foreach (IWebElement element in multipleCheckBoxList)
            {
                if (element.Selected)
                {
                    kiek++;
                }
            }
            Assert.AreEqual(0, kiek, "Kazkurie chekboxai pazymeti");
        }

        [Test]
        public static void ClickSingleCheckbox()
        {
            IWebElement singleCheckbox = _driver.FindElement(By.Id("isAgeSelected"));
            IWebElement singleCheckboxResult = _driver.FindElement(By.Id("txtAge"));
            bool pazymetas = true;
            if (pazymetas != singleCheckbox.Selected)
            {
                singleCheckbox.Click();
            }
            string expectedResult = "Success - Check box is checked";
            Assert.AreEqual(expectedResult, singleCheckboxResult.Text, "Tekstas neatsirado");
        }

    }
}