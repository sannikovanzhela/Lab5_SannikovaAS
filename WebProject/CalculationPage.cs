using Microsoft.VisualBasic;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V117.Debugger;
using OpenQA.Selenium.Support.UI;
using System.Linq.Expressions;
using System.Security.Cryptography;

namespace WebProject
{
    public class CalculationPage
    {
        private IWebDriver driver;
        private TimeSpan timeout = TimeSpan.FromMilliseconds(2000);

        private By inputA = By.CssSelector("input[ng-model='a']");
        private By inputB = By.CssSelector("input[ng-model='b']");

        private By btnIncA = By.CssSelector("button[ng-click='inca()']");
        private By btnDecA = By.CssSelector("button[ng-click='deca()']");
        private By btnIncB = By.CssSelector("button[ng-click='incb()']");
        private By btnDecB = By.CssSelector("button[ng-click='decb()']");

        private By selectOperation = By.TagName("select");
        private By result = By.CssSelector(".result.ng-binding");
        public CalculationPage(IWebDriver driver)
        {
            this.driver = driver;
            Thread.Sleep(timeout);

            try
            {
                new WebDriverWait(driver, timeout).Until(drv => drv.FindElement(result));
            }
            catch
            {
                throw new Exception("Не удалось загрузить AngularJS calculator");
            }
        }

        public CalculationPage clickButtonIncA()
        {
            driver.FindElement(btnIncA).Click();
            return this;
        }

        public CalculationPage clickButtonDecA()
        {
            driver.FindElement(btnDecA).Click();
            return this;
        }

        public CalculationPage clickButtonIncB()
        {
            driver.FindElement(btnIncB).Click();
            return this;
        }

        public CalculationPage clickButtonDecB()
        {
            driver.FindElement(btnDecB).Click();
            return this;
        }

        public CalculationPage selectValue(string value)
        {
            SelectElement selectElm = new SelectElement(driver.FindElement(selectOperation));
            selectElm.SelectByValue(value);
            return this;
        }

        public CalculationPage fillValueAField(string valueA)
        {
            clearValueAField();
            driver.FindElement(inputA).SendKeys(valueA);
            return this;
        }

        public CalculationPage fillValueBField(string valueB)
        {
            clearValueBField();
            driver.FindElement(inputB).SendKeys(valueB);
            return this;
        }

        public CalculationPage clearValueAField()
        {
            driver.FindElement(inputA).SendKeys(Keys.Control + "a" + Keys.Backspace);
            return this;
        }

        public CalculationPage clearValueBField()
        {
            driver.FindElement(inputB).SendKeys(Keys.Control + "a" + Keys.Backspace);
            return this;
        }

        public string getResult()
        {
            return driver.FindElement(result).Text;
        }

    }
}
