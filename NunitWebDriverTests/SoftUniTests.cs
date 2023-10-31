using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace NunitWebDriverTests
{
    public class SoftUniTests
    {
        private WebDriver driver;

        [OneTimeSetUp]
        public void OpenBrowserAndNavigate()
        {
            //Executes before each test
    
            this.driver = new ChromeDriver();
            driver.Url = "https://softuni.bg";
            //Maximize the window before running the tests for better results
            try
            {
                driver.Manage().Window.Maximize();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while maximizing the window: " + ex.Message);
            }

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
            var aboutElement = driver.FindElement(By.CssSelector("#nav-items-list > ul > li.page-header-items-list-element.dropdown-item.relative-dropdown > a > span.main-title");
            //Click on the element on the page 
            aboutElement.Click();

            String expectedTitle = "За нас";

            //Assert
            Assert.That(expectedTitle, Is.EqualTo("За нас"));


            driver.Quit();
        }
       
    }
}