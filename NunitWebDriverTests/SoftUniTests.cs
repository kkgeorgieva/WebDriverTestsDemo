using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace NunitWebDriverTests
{
    public class SoftUniTests
    {
        private WebDriver driver;
     
        [OneTimeSetUp]
        public void OpenBrowserAndNavigate()
        {
            //Executes before each test
        
            driver = new ChromeDriver();
            driver.Url = "https://softuni.bg";
            //Maximize the window before running the tests for better results
            driver.Manage().Window.Size = new System.Drawing.Size(1920, 1040);

        }

        [OneTimeTearDown]
        public void CloseBrowser() {
            driver.Quit();
        }

        [Test]
        public void AssertTitleName()
        {
          
            //Act
         
            String expectedTitle = "ИТ курсове по програмиране - Софтуерен университет";

            //Assert
            Assert.That(expectedTitle, Is.EqualTo(driver.Title));

            driver.Quit();
        }
        [Test]
        public void AssertAboutPageTitle()
        {
            //Navigate to the element on the page 
            var aboutElement = driver.FindElement(By.CssSelector("#nav-items-list > ul > li.page-header-items-list-element.dropdown-item.relative-dropdown > a > span.main-title"));
            //Click on the element on the page 
            aboutElement.Click();

            String expectedTitle = "За нас";

            //Assert
            Assert.That(expectedTitle, Is.EqualTo("За нас"));


            driver.Quit();
        }

        [Test]
        //Tests where you try to log in with incorrect crededntials
        public void IncorrectUsernameLoginTest()
        {
            
            driver.FindElement(By.CssSelector(".softuni-btn-primary:nth-child(1)")).Click();
            driver.FindElement(By.Id("username")).Click();
            driver.FindElement(By.Id("username")).SendKeys("HFHFHF");
            driver.FindElement(By.Id("password-input")).Click();
            driver.FindElement(By.Id("password-input")).SendKeys("HFHFHF");
            driver.FindElement(By.CssSelector(".softuni-btn")).Click();
            driver.FindElement(By.CssSelector("li")).Click();
            Assert.That(driver.FindElement(By.CssSelector("li")).Text, Is.EqualTo("Невалидно потребителско име или парола"));

        }

        [Test]

        public void newTestCase()
        {
            driver.Navigate().GoToUrl("https://softuni.bg/");
            driver.Manage().Window.Size = new System.Drawing.Size(1920, 1040);
            driver.FindElement(By.CssSelector(".header-search-icon > img")).Click();
            driver.FindElement(By.Id("search-input")).Click();
            driver.FindElement(By.Id("search-input")).SendKeys("QA");
            driver.FindElement(By.Id("search-input")).SendKeys(Keys.Enter);
            Assert.That(driver.FindElement(By.CssSelector(".search-title")).Text, Is.EqualTo("Резултати от търсене на “QA”"));
        }
    }
}