

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

//Create new Chrome Browser instance    
var driver = new ChromeDriver();

//Navigate to Wikipedia page
driver.Url = "http://wikipedia.org";

System.Console.WriteLine("Current title: " + driver.Title);

//Locate search field by ID;
var searchField = driver.FindElement(By.Id("searchInput"));

//Click on element
searchField.Click();

// Searching for an element in the search field
searchField.SendKeys("QA" + Keys.Enter);

System.Console.WriteLine("Title after search: " + driver.Title);

//Close browser 
driver.Quit();