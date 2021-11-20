using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatinisTestavimas.Page
{
    public class DropDownPage : BasePage
    {
        private const string PageAddress = "https://.seleniumeasy.com/basic-select-dropdown-demo.html";
        private const string ResultText = "Day selected :- ";
        private const string ResultTextFirstSelected = "First selected option is : ";
        private const string ResultGetAllSelected = "Options selected are : ";
        private SelectElement DropDown => new SelectElement(Driver.FindElement(By.Id("select-demo")));
        private IWebElement ResultTextElement => Driver.FindElement(By.CssSelector(".selected-value")); //kodel ne pagal classname
        private SelectElement MultiSelect => new SelectElement(Driver.FindElement(By.Id("multi-select")));
        private IWebElement ButtonFirstSelected => Driver.FindElement(By.Id("printMe"));
        private IWebElement ButtonGetAll => Driver.FindElement(By.Id("printAll"));
        private IWebElement TextFirstSelected => Driver.FindElement(By.CssSelector(".getall-selected"));
        



        public DropDownPage(IWebDriver webDriver) : base(webDriver)
        {
            Driver.Url = PageAddress;
        }

        public DropDownPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
        }

        public DropDownPage SelectFromDropDownByText(string text)
        {
            DropDown.SelectByText(text);
            return this;
        }

        public DropDownPage SelectFromDropDownByValue(string text)
        {
            DropDown.SelectByValue(text);
            return this;
        }

        public DropDownPage VerifyResult(string selectedDay)
        {
            Assert.IsTrue(ResultTextElement.Text.Equals(ResultText + selectedDay), $"Result is wrong, not {selectedDay}");
            return this;
        }

        public DropDownPage SelectFromMultiDropDownByValue(string firstValue, string secondValue)
        {
            
            Actions action = new Actions(Driver);
            MultiSelect.SelectByValue(firstValue);
            action.KeyDown(Keys.Control);
            MultiSelect.SelectByValue(secondValue);
            action.KeyUp(Keys.Control);
            action.Build().Perform();
            return this;
        }

        public DropDownPage CheckResultFirstSelected(string first)
        {
            Assert.IsTrue(TextFirstSelected.Text.Equals(ResultTextFirstSelected + first), $"Rezultatas neteisingas, ne {first}"); 
            return this;
        }

        public DropDownPage CheckResultGetAllSelected(List <string> listas)
        {
            Assert.IsTrue(TextFirstSelected.Text.Contains(ResultTextFirstSelected + listas), $"Rezultatas neteisingas, ne {listas}");
            return this;
        }

        public DropDownPage ClickButtonFirstSelected()
        {
            ButtonFirstSelected.Click();
            return this;
        }
        public DropDownPage ClickButtonGetAll()
        {
            ButtonGetAll.Click();
            return this;
        }



        public DropDownPage SelectFromMultipleDropDownByValue(List<string> listOfStates)
        {
            MultiSelect.DeselectAll();
            Actions action = new Actions(Driver);
            action.KeyDown(Keys.LeftControl);
            foreach (string state in listOfStates)
            {
                foreach (IWebElement option in MultiSelect.Options)
                {
                    if (state.Equals(option.GetAttribute("value")))
                    {
                        action.Click(option);
                        break;
                    }
                }
            }
            action.KeyUp(Keys.LeftControl);
            action.Build().Perform();
            action.Click(ButtonFirstSelected);
            action.Build().Perform();
            return this;
        }

        public DropDownPage SelectThreeFromMultipleDD (string first, string second, string third)
        {
            MultiSelect.DeselectAll();
            Actions action = new Actions(Driver);
            action.KeyDown(Keys.Control);

            return this;
        }

    }
}
