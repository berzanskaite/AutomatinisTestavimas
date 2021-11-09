using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatinisTestavimas
{
    class Uzd1_Narsykles
    {
        private static IWebDriver _driver;
        private static string _textToCheck;

        [TestCase("Chrome", "Chrome", TestName = "Chrome")]
        [TestCase("Firefox", "Firefox", TestName = "Firefox")]


        public static void TestBrowser(string browser, string tekstas)
        {
            switch (browser)
            {
                case "Chrome":
                    _driver = new ChromeDriver();
                    _textToCheck = tekstas;
                    break;
                case "Firefox":
                    _driver = new FirefoxDriver();
                    _textToCheck = tekstas;
                    break;
            }

            SetUp();
            string textas = _driver.FindElement(By.CssSelector(".simple-major")).Text;
            Assert.IsTrue(textas.Contains(_textToCheck), "Ne toks tekstas");
            TearDown();
        }

        private static void SetUp()
        {
            _driver.Url = "https://developers.whatismybrowser.com/useragents/parse/?analyse-my-user-agent=yes#parse-useragent";
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.Manage().Window.Maximize();
        }

        
        private static void TearDown()
        {
           // _driver.Quit();
        }
    }
}
