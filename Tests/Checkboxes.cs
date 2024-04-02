using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;

namespace TMS_Selenium.Tests
{
    public class Checkboxes
    {
        private IWebDriver driver;
        private ReadOnlyCollection<IWebElement> checkboxes;

        [SetUp]
        public void Setup()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--incognito");
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/checkboxes");
            driver.Manage().Window.Maximize();

            checkboxes = driver.FindElements(By.CssSelector("[type = checkbox]"));
        }

        [Test]
        public void OpenPage_FirstCheckboxUnchecked()
        {
            var isChecked = checkboxes[0].GetAttribute("checked");
            Assert.IsNull(isChecked, "The checkbox is expected to be unchecked, but it is checked.");
        }

        [Test]
        public void SelectFirstCheckbox_FirstCheckboxСhecked()
        {
            checkboxes[0].Click();
            var isChecked = checkboxes[0].GetAttribute("checked");
            Assert.NotNull(isChecked, "The checkbox is expected to be checked, but it is unchecked.");
        }

        [Test]
        public void OpenPage_SecondCheckboxChecked()
        {
            var isChecked = checkboxes[1].GetAttribute("checked");
            Assert.NotNull(isChecked, "The checkbox is expected to be checked, but it is unchecked.");
        }

        [Test]
        public void SelectSecondCheckbox_FirstCheckboxUnchecked()
        {
            checkboxes[1].Click();
            var isChecked = checkboxes[1].GetAttribute("checked");
            Assert.IsNull(isChecked, "The checkbox is expected to be unchecked, but it is checked.");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}