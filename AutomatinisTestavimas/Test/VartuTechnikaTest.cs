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
    public class VartuTechnikaTest
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

        [TestCase("2000", "2000", true, false, "665.98", TestName = "2000+2000+A=665.98")]
        [TestCase("4000", "2000", true, true, "1006.43", TestName = "4000+2000+A+M=1006.43")]
        [TestCase("4000", "2000", false, false, "692.35", TestName = "4000+2000=692.35")]
        [TestCase("5000", "2000", false, true, "989.21", TestName = "5000+2000+M=989.21")]
        public void TestVartuTechnika(string plotis, string aukstis, bool automatika, bool montavimas, string result)
        {
            VartuTechnikaPage page = new VartuTechnikaPage(_driver);
            page.IvestiAbuMatmenis(plotis, aukstis);
            page.CheckAutomatika(automatika);
            page.CheckDarbai(montavimas);
            page.ClickCalculate();
            page.CheckResult(result);
        }
    }
}
