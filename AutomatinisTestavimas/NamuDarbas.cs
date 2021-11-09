using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomatinisTestavimas
{
    class NamuDarbas
    {
        private static IWebDriver _driver;

        [OneTimeSetUp]

        public static void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Url = "https://demo.seleniumeasy.com/basic-first-form-demo.html";
            IWebElement popUp = _driver.FindElement((By.Id("at-cv-lightbox-close")));
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(d => popUp.Displayed);
            popUp.Click();
        }

        [OneTimeTearDown]
        public static void TearDown()
        {
          //  _driver.Quit();
        }

        [TestCase("2", "2", "4", TestName = "2 + 2 = 4")]
        [TestCase("-5", "3", "-2", TestName = "-5 + 3 = -2")]
        [TestCase("a", "b", "NaN", TestName = "a + b = NaN")]

        public static void TestSeleniumPage1(string firstName, string secondName, string result)
        {
            IWebElement inputField1 = _driver.FindElement(By.Id("sum1"));
            IWebElement inputField2 = _driver.FindElement(By.Id("sum2"));
            inputField1.Clear();
            inputField1.SendKeys(firstName);
            inputField2.Clear();
            inputField2.SendKeys(secondName);
            _driver.FindElement(By.CssSelector("#gettotal > button")).Click();
            IWebElement resultFromPage = _driver.FindElement(By.Id("displayvalue"));
            Assert.AreEqual(result, resultFromPage.Text, "Suskaiciuota neteisingai");
            
        }

        [Test]
        public static void TestSeleniumPage2()
        {
            IWebDriver _driver = new ChromeDriver();
            _driver.Url = "https://demo.seleniumeasy.com/basic-first-form-demo.html";
            IWebElement inputField1 = _driver.FindElement(By.Id("sum1"));
            string text1 = "-5";
            IWebElement inputField2 = _driver.FindElement(By.Id("sum2"));
            string text2 = "3";
            inputField1.SendKeys(text1);
            inputField2.SendKeys(text2);
            Thread.Sleep(5000);
            IWebElement popUp = _driver.FindElement(By.Id("at-cv-lightbox-close"));
            popUp.Click();
            IWebElement button = _driver.FindElement(By.CssSelector("#gettotal > button"));
            button.Click();
            IWebElement result = _driver.FindElement(By.Id("displayvalue"));
            Assert.AreEqual("-2", result.Text, "Suskaiciuota neteisingai");
            //firefox.Quit();
        }

        [Test]
        public static void TestSeleniumPage3()
        {
            IWebDriver _driver = new ChromeDriver();
            _driver.Url = "https://demo.seleniumeasy.com/basic-first-form-demo.html";
            IWebElement inputField1 = _driver.FindElement(By.Id("sum1"));
            string text1 = "a";
            IWebElement inputField2 = _driver.FindElement(By.Id("sum2"));
            string text2 = "b";
            inputField1.SendKeys(text1);
            inputField2.SendKeys(text2);
            Thread.Sleep(5000);
            IWebElement popUp = _driver.FindElement(By.Id("at-cv-lightbox-close"));
            popUp.Click();
            IWebElement button = _driver.FindElement(By.CssSelector("#gettotal > button"));
            button.Click();
            IWebElement result = _driver.FindElement(By.Id("displayvalue"));
            Assert.AreEqual("NaN", result.Text, "Suskaiciuota neteisingai");
            _driver.Quit();
        }

        /* dar tokį parašiau (nežinau, ar naudinga) "daugkartinį" kodą, kuriame
          pakeitaliojus text1 ir text2, nereikėtų keisti rezultato asserto eilutėje  */

        [Test]
        public static void TestSeleniumPage4()
        {
            IWebDriver _driver = new ChromeDriver();
            _driver.Url = "https://demo.seleniumeasy.com/basic-first-form-demo.html";
            IWebElement laukelis1 = _driver.FindElement(By.Id("sum1"));
            string text1 = "5";
            IWebElement laukelis2 = _driver.FindElement(By.Id("sum2"));
            string text2 = "7";
            int skaicius1 = Convert.ToInt32(text1);
            int skaicius2 = Convert.ToInt32(text2);
            laukelis1.SendKeys(text1);
            laukelis2.SendKeys(text2);
            Thread.Sleep(5000);
            IWebElement popUp = _driver.FindElement(By.Id("at-cv-lightbox-close"));
            popUp.Click();
            IWebElement button = _driver.FindElement(By.CssSelector("#gettotal > button"));
            button.Click();
            IWebElement suma = _driver.FindElement(By.Id("displayvalue"));
            Assert.AreEqual(Convert.ToString(skaicius1 + skaicius2), suma.Text, "Suskaiciuota neteisingai");
            //_driver.Quit();
        }

    }
}
