using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebProject;

IWebDriver driver = new ChromeDriver();
driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);
var timeout = 3000;

driver.Url = "https://www.globalsqa.com/angularJs-protractor/SimpleCalculator/";
var calculationPage = new CalculationPage(driver);
Thread.Sleep(timeout);

Console.WriteLine();

//Увеличение значения a на 1
calculationPage.clickButtonIncA();
Thread.Sleep(timeout);

//Уменьшение значения a на 1
calculationPage.clickButtonDecA();
Thread.Sleep(timeout);

//Увеличение значения b на 1
calculationPage.clickButtonIncB();
Thread.Sleep(timeout);

//Уменьшение значения b на 1
calculationPage.clickButtonDecB();
Thread.Sleep(timeout);

//Выбор оператора
calculationPage.selectValue("/");
Thread.Sleep(timeout);

// Заполнение и очистка полей
calculationPage.fillValueAField("1.2");
Thread.Sleep(timeout);
calculationPage.fillValueBField("2e3");
Thread.Sleep(timeout);
calculationPage.clearValueAField();
Thread.Sleep(timeout);
calculationPage.clearValueBField();
Thread.Sleep(timeout);

//Вывод результата
Console.WriteLine(calculationPage.getResult());
Thread.Sleep(timeout);

driver.Quit();