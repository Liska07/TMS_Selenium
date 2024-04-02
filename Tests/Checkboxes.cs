using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;

namespace TMS_Selenium.Tests
{
    [TestFixture]
    public class Checkboxes : Basic
    {
        private ReadOnlyCollection<IWebElement> checkboxes;

        [SetUp]
        public void Setup()
        {
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/checkboxes");
            checkboxes = driver.FindElements(By.CssSelector("[type = checkbox]"));
        }

        [Test]
        public void OpenPage_FirstCheckboxUnchecked()
        {
            var isChecked = checkboxes[0].GetAttribute("checked");
            Assert.That(isChecked, Is.Null, "The checkbox is expected to be unchecked, but it is checked.");
        }

        [Test]
        public void SelectFirstCheckbox_FirstCheckboxСhecked()
        {
            checkboxes[0].Click();
            var isChecked = checkboxes[0].GetAttribute("checked");
            Assert.That(isChecked, Is.Not.Null, "The checkbox is expected to be checked, but it is unchecked.");
        }

        [Test]
        public void OpenPage_SecondCheckboxChecked()
        {
            var isChecked = checkboxes[1].GetAttribute("checked");
            Assert.That(isChecked, Is.Not.Null, "The checkbox is expected to be checked, but it is unchecked.");
        }

        [Test]
        public void SelectSecondCheckbox_FirstCheckboxUnchecked()
        {
            checkboxes[1].Click();
            var isChecked = checkboxes[1].GetAttribute("checked");
            Assert.That(isChecked, Is.Null, "The checkbox is expected to be unchecked, but it is checked.");
        }
    }
}