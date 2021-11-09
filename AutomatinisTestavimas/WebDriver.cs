using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomatinisTestavimas
{
    class WebDriver
    {
        [Test]
        public static void TestChromeDriver()
        {
            IWebDriver chrome = new ChromeDriver();
            chrome.Url = "https://login.yahoo.com/";
            //chrome.Quit();

        }

        [Test]
        public static void TestFirefoxDriver()
        {
            IWebDriver firefox = new FirefoxDriver();
            firefox.Url = "https://login.yahoo.com/";
            //firefox.Quit();

        }

        [Test]
        public static void TestYahooPage()
        {
            IWebDriver chrome = new ChromeDriver();
            chrome.Url = "https://login.yahoo.com/";
            IWebElement loginInputField = chrome.FindElement(By.Id("login-username"));
            loginInputField.SendKeys("Test");
            //chrome.Quit();
        }

        [Test]
        public static void TestSeleniumPage()
        {
            IWebDriver chrome = new ChromeDriver();
            chrome.Url = "https://demo.seleniumeasy.com/basic-first-form-demo.html";
            IWebElement inputField = chrome.FindElement(By.Id("user-message"));
            string myText = "Labas";
            inputField.SendKeys(myText);
            Thread.Sleep(5000);
            IWebElement popUp = chrome.FindElement(By.Id("at-cv-lightbox-close"));
            popUp.Click();
            IWebElement button = chrome.FindElement(By.CssSelector("#get-input > button"));
            button.Click();
            IWebElement result = chrome.FindElement(By.Id("display"));
            Assert.AreEqual(myText, result.Text, "Tekstas neatsirado");
            //chrome.Quit();
        }

    }
}
