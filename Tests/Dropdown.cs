using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TMS_Selenium.Tests
{
    [TestFixture]
    public class Dropdown : BaseTest
    {
        private SelectElement select;

        [SetUp]
        public void SetUp()
        {
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/dropdown");
            var selectWebElement = driver.FindElement(By.Id("dropdown"));
            select = new SelectElement(selectWebElement);
        }

        [Test]
        public void SelectFirstElement_FirstElementSelected()
        {
            select.SelectByIndex(1);
            var value = select.SelectedOption.GetAttribute("value");
            string expectedValue = "1";
            Assert.That(value, Is.EqualTo(expectedValue), "The first element is expected to be selected, but it is not.");
        }

        [Test]
        public void SelectSecondElement_SecondElementSelected()
        {
            select.SelectByIndex(2);
            var value = select.SelectedOption.GetAttribute("value");
            string expectedValue = "2";
            Assert.That(value, Is.EqualTo(expectedValue), "The second element is expected to be selected, but it is not.");
        }
    }
}
