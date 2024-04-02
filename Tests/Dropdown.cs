using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace TMS_Selenium.Tests
{
    public class Dropdown
    {
        private IWebDriver driver;
        private SelectElement select;

        [SetUp]
        public void Setup()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--incognito");
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/dropdown");
            driver.Manage().Window.Maximize();

            var selectWebElement = driver.FindElement(By.Id("dropdown"));
            select = new SelectElement(selectWebElement);
        }

        [Test]
        public void SelectFirstElement_FirstElementSelected()
        {
            select.SelectByIndex(1);
            var elementValue = select.SelectedOption.GetAttribute("value");
            string expectedValue = "1";
            Assert.AreEqual(elementValue, expectedValue, "The first element is expected to be selected, but it is not.");
        }

        [Test]
        public void SelectSecondElement_SecondElementSelected()
        {
            select.SelectByIndex(2);
            var elementValue = select.SelectedOption.GetAttribute("value");
            string expectedValue = "2";
            Assert.AreEqual(elementValue, expectedValue, "The second element is expected to be selected, but it is not.");
        }

        [TearDown]
        public void OneTimeTearDown()
        {
            driver.Quit();
        }
    }
}
