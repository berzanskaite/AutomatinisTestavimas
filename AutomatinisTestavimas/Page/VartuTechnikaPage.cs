using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatinisTestavimas.Page
{
    public class VartuTechnikaPage : BasePage
    {
        private const string PageAddress = "http://vartutechnika.lt/";
        private IWebElement _plocioLaukelis => Driver.FindElement(By.Id("doors_width"));
        private IWebElement _aukscioLaukelis => Driver.FindElement(By.Id("doors_height"));
        private IWebElement _automatikaCheckBox => Driver.FindElement(By.Id("automatika"));
        private IWebElement _montavimasCheckBox => Driver.FindElement(By.Id("darbai"));
        private IWebElement _calculateButton => Driver.FindElement(By.Id("calc_submit"));
        private IWebElement _resultBox => Driver.FindElement(By.CssSelector("#calc_result > div"));

        //konstruktorius
        public VartuTechnikaPage(IWebDriver webDriver) : base(webDriver)
        {
            Driver.Url = PageAddress;
        }

        public VartuTechnikaPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
        }

        public void IvestiPloti(string plotis)
        {
            _plocioLaukelis.Clear();
            _plocioLaukelis.SendKeys(plotis);
        }
        public void IvestiAuksti(string aukstis)
        {
            _aukscioLaukelis.Clear();
            _aukscioLaukelis.SendKeys(aukstis);
        }

        public void IvestiAbuMatmenis (string plotis, string aukstis)
        {
            IvestiPloti(plotis);
            IvestiAuksti(aukstis);
        }
        public void CheckAutomatika (bool turiButiPazymetas)
        {
            if (turiButiPazymetas != _automatikaCheckBox.Selected)
                _automatikaCheckBox.Click();
        }
        public void CheckDarbai(bool turiButiPazymetas)
        {
            if (turiButiPazymetas != _montavimasCheckBox.Selected)
                _montavimasCheckBox.Click();
        }

        public void ClickCalculate ()
        {
            _calculateButton.Click();
        }

        private void WaitForResult()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(d => _resultBox.Displayed);
        }

        public void CheckResult(string expectedResult)
        {
            WaitForResult();
            Assert.IsTrue(_resultBox.Text.Contains(expectedResult), $"Rezultatas yra ne toks pats, lauktas" +
                $"rezultatas yra {expectedResult}, bet yra {_resultBox.Text}");
        }
    }
}
