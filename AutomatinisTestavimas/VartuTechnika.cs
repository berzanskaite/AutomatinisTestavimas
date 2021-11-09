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
    class VartuTechnika
    {
        private static IWebDriver _driver;

        [OneTimeSetUp]

        public static void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Url = "http://vartutechnika.lt/";
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            _driver.Manage().Window.Maximize();
            _driver.FindElement(By.Id("cookiescript_reject")).Click();
        }

        [OneTimeTearDown]
        public static void TearDown()
        {
            //  _driver.Quit();
        }

        [TestCase("2000", "2000", true, false, "665.98€", TestName = "2000 x 2000 + Vartu automatika = 665.98€")]

        public static void TestCartuTechnikaPage(string plotis, string aukstis, bool automatika, bool montavimas, string suma)
        {
            IWebElement plocioLaukelis = _driver.FindElement(By.Id("doors_width"));
            plocioLaukelis.Clear();
            plocioLaukelis.SendKeys(plotis);
            IWebElement aukscioLaukelis = _driver.FindElement(By.Id("doors_height"));
            aukscioLaukelis.Clear();
            aukscioLaukelis.SendKeys(aukstis);
            IWebElement automatikaCheckBox = _driver.FindElement(By.Id("automatika"));
            if (automatika != automatikaCheckBox.Selected)
                {
                    automatikaCheckBox.Click();
                }
            IWebElement montavimasCheckBox = _driver.FindElement(By.Id("darbai"));
            if (montavimas != montavimasCheckBox.Selected)
                {
                    montavimasCheckBox.Click();
                }

            }
        }
    }

