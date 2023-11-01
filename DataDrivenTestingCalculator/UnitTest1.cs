using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace DataDrivenTestingCalculator
{
    public class Tests
    {
        //Test may fail due to missing web page
        private ChromeDriver driver;
        //We turn them into IWebElements 
        IWebElement field1;
        IWebElement field2;
        IWebElement operation;
        IWebElement calculate;
        IWebElement resultField;
        IWebElement clearField;
        

        [OneTimeSetUp]
        public void OpenAndNavigate()
        {
            this.driver = new ChromeDriver();
            driver.Url = "https://number-calculator.nakov.repl.co/";
            IWebElement field1 = driver.FindElement(By.Id("number1"));
            IWebElement field2 = driver.FindElement(By.Id("number2"));
            IWebElement operation = driver.FindElement(By.Id("operation"));
            IWebElement calculate = driver.FindElement(By.Id("calcButton"));
            IWebElement resultField = driver.FindElement(By.Id("result"));
            IWebElement clearField = driver.FindElement(By.Id("resetButton"));
        }
        //Creating multiple test cases so that there is no unnecessary code duplication
        [TestCase("5", "6", "+", "Result: 11")]
        [TestCase("15", "6", "-", "Result: 9")]
        [TestCase("15", "1", "-", "Result: 14")]
        public void TestCalculator(string num1, String num2, string operat, string result)
        {
            //Act
            field1.SendKeys(num1);
            operation.SendKeys(operat);
            field2.SendKeys(num2);


            calculate.Click();

            //Checking the result 
            Assert.That(result, Is.Not.EqualTo(resultField.Text));
            clearField.Click();

            driver.Quit();

        }
    }
}