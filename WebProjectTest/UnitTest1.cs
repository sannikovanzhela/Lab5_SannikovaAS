using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebProject;

namespace WebProjectTest
{
    public class Tests
    {
        private IWebDriver driver;
        CalculationPage page;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Url = "https://www.globalsqa.com/angularJs-protractor/SimpleCalculator/";
            page = new CalculationPage(driver);
        }

        [Test]
        public void TestValueAisNotNumber()
        {
            var expect = "null + 0 = null";

            page.fillValueAField("value1_+=значение");
            var actual = page.getResult();

            Assert.That(actual, Is.EqualTo(expect));
        }

        [Test]
        public void TestValueBisNotNumber()
        {
            var expect = "0 + null = null";

            page.fillValueBField("value2_+=значение");
            var actual = page.getResult();

            Assert.That(actual, Is.EqualTo(expect));
        }

        [Test]
        public void TestValuesAreNotNumber()
        {
            var expect = "null + null = null";

            page.fillValueAField("value1_+=значение");
            page.fillValueBField("value2_+=значение");
            var actual = page.getResult();

            Assert.That(actual, Is.EqualTo(expect));
        }

        [Test]
        public void TestValueAwithComma()
        {
            var expect = "null + 0 = null";

            page.fillValueAField("65,09");
            var actual = page.getResult();

            Assert.That(actual, Is.EqualTo(expect));
        }

        [Test]
        public void TestValueBwithComma()
        {
            var expect = "0 + null = null";

            page.fillValueBField("87,3");
            var actual = page.getResult();

            Assert.That(actual, Is.EqualTo(expect));
        }

        [Test]
        public void TestValuesWithPoint()
        {
            var expect = "null + null = null";

            page.fillValueAField("65,09");
            page.fillValueBField("87,3");
            var actual = page.getResult();

            Assert.That(actual, Is.EqualTo(expect));
        }

        [Test]
        public void TestValueAWithExponent()
        {
            var expect = "1000 + 0 = 1000";

            page.fillValueAField("1e3");
            var actual = page.getResult();

            Assert.That(actual, Is.EqualTo(expect));
        }

        [Test]
        public void TestValueBWithexponent()
        {
            var expect = "0 + 900 = 900";

            page.fillValueBField("9e2");
            var actual = page.getResult();

            Assert.That(actual, Is.EqualTo(expect));
        }

        [Test]
        public void TestValuesWithexponent()
        {
            var expect = "1000 + 900 = 1900";

            page.fillValueAField("1e3");
            page.fillValueBField("9e2");
            var actual = page.getResult();

            Assert.That(actual, Is.EqualTo(expect));
        }


        [Test]
        public void TestValueAisFloat()
        {
            var expect = "13.23 + 0 = 13.23";

            page.fillValueAField("13.23");
            var actual = page.getResult();

            Assert.That(actual, Is.EqualTo(expect));
        }

        [Test]
        public void TestValueBisFloat()
        {
            var expect = "0 + 192.21 = 192.21";

            page.fillValueBField("192.21");
            var actual = page.getResult();

            Assert.That(actual, Is.EqualTo(expect));
        }

        [Test]
        public void TestValuesAreFloat()
        {
            var expect = "13.23 + 192.21 = 205.44";

            page.fillValueAField("13.23");
            page.fillValueBField("192.21");
            var actual = page.getResult();

            Assert.That(actual, Is.EqualTo(expect));
        }

        [Test]
        public void TestValueAbigNumber()
        {
            var expect = "1.1111111111111111e+21 + 0 = 1.1111111111111111e+21";

            page.fillValueAField("1111111111111111111111");
            var actual = page.getResult();

            Assert.That(actual, Is.EqualTo(expect));
        }

        [Test]
        public void TestValueBbigNumber()
        {
            var expect = "0 + 2.2222222222222222e+21 = 2.2222222222222222e+21";

            page.fillValueBField("2222222222222222222222");
            var actual = page.getResult();

            Assert.That(actual, Is.EqualTo(expect));
        }

        [Test]
        public void TestValuesBig()
        {
            var expect = "1.1111111111111111e+21 + 2.2222222222222222e+21 = 3.333333333333333e+21";

            page.fillValueAField("1111111111111111111111");
            page.fillValueBField("2222222222222222222222");
            var actual = page.getResult();

            Assert.That(actual, Is.EqualTo(expect));
        }

        [Test]
        public void TestClearValueA()
        {
            var expect = "0 + 0 = 0";

            page.fillValueAField("13");
            page.clearValueAField();

            var actual = page.getResult();

            Assert.That(actual, Is.EqualTo(expect));
        }

        [Test]
        public void TestClearValueB()
        {
            var expect = "0 + 0 = 0";

            page.fillValueBField("32");

            page.clearValueBField();
            var actual = page.getResult();

            Assert.That(actual, Is.EqualTo(expect));
        }


        [Test]
        public void TestClearValues()
        {
            var expect = "0 + 0 = 0";

            page.fillValueAField("13");
            page.fillValueBField("32");

            page.clearValueAField();
            page.clearValueBField();

            var actual = page.getResult();

            Assert.That(actual, Is.EqualTo(expect));
        }

        [Test]
        public void TestValueIncA()
        {
            var expect = "1 + 0 = 1";

            page.clickButtonIncA();
            var actual = page.getResult();

            Assert.That(actual, Is.EqualTo(expect));
        }

        [Test]
        public void TestValueDecA()
        {
            var expect = "-1 + 0 = -1";

            page.clickButtonDecA();
            var actual = page.getResult();

            Assert.That(actual, Is.EqualTo(expect));
        }

        [Test]
        public void TestValueIncB()
        {
            var expect = "0 + 1 = 1";

            page.clickButtonIncB();
            var actual = page.getResult();

            Assert.That(actual, Is.EqualTo(expect));
        }

        [Test]
        public void TestValueDecB()
        {
            var expect = "0 + -1 = -1";

            page.clickButtonDecB();
            var actual = page.getResult();

            Assert.That(actual, Is.EqualTo(expect));
        }

        [Test]
        public void TestDevideByZero()
        {
            var expect = "0 / 0 = null";

            page.selectValue("/");
            var actual = page.getResult();

            Assert.That(actual, Is.EqualTo(expect));
        }

        [TearDown] public void TearDown()
        {
            driver.Quit();
        }
    }
}