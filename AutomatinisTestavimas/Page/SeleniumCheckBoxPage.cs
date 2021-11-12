﻿using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatinisTestavimas.Page
{
    public class SeleniumCheckBoxPage : BasePage
    {

        private IWebElement _singleCheckbox => Driver.FindElement(By.CssSelector("#isAgeSelected"));
        private IWebElement _singleCheckboxResult => Driver.FindElement(By.CssSelector("#txtAge"));
        private IReadOnlyCollection<IWebElement> _multipleCheckbox => Driver.FindElements(By.CssSelector("div.checkbox:nth-child" +
            "(6) > label:nth-child(1) > input:nth-child(1)"));
        private IWebElement _button => Driver.FindElement(By.CssSelector("#check1"));

       
        public SeleniumCheckBoxPage(IWebDriver webDriver) : base(webDriver)
        { }


        public void ClickSingleCheckbox(bool pazymetas)
        {
            if (pazymetas != _singleCheckbox.Selected)
            {
                _singleCheckbox.Click();
            }
        }

        public void CheckSingleCheckboxResult (string expectedResult)
        {
            Assert.AreEqual(expectedResult, _singleCheckboxResult.Text, "Tekstas neatsirado");
        }

        public void ClickAll()
        {
            foreach (IWebElement element in _multipleCheckbox)
            {
                element.Click();
            }
        }

        public void CheckMultipleCheckboxButton (string expectedResult)
        {
            Assert.AreEqual(expectedResult, _button.GetProperty("value"), "Tekstas yra ne {0}", expectedResult);
        }

        public void ClickButton()
        {
            _button.Click();
        }

        public void AtzymejimoTikrinimas()
        {
            int kiek = 0;
            foreach (IWebElement element in _multipleCheckbox)
            {
                if (element.Selected)
                {
                    kiek++;
                }
            }
            Assert.AreEqual(0, kiek, "Ne visi laukeliai atzymeti");
        }
    }
}
