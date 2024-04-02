using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace TMS_Selenium.Tests
{
    public class Add_Delete_Elements
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--incognito");
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/add_remove_elements/");
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void AddTwoElementsAndOneDelete_SingleDeleteButton()
        {
            var addElementButton = driver.FindElement(By.XPath("//button[text()='Add Element']"));
            addElementButton.Click();
            addElementButton.Click();

            var deleteButton = driver.FindElement(By.XPath("//button[text()='Delete']"));
            deleteButton.Click();

            var deleteButtonList = driver.FindElements(By.XPath("//button[text()='Delete']"));
            int expectedCount = 1;
            Assert.IsTrue(deleteButtonList.Count == expectedCount, $"The number of delete buttons is not as expected. Expected count = {expectedCount}, Actual count = {deleteButtonList.Count}");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}