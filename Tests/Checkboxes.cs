using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace TMS_Selenium.Tests
{
    [TestFixture]
    public class Checkboxes : BaseTest
    {
        private ReadOnlyCollection<IWebElement> checkboxes;

        [SetUp]
        public void SetUp()
        {
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/checkboxes");
            checkboxes = driver.FindElements(By.CssSelector("[type = checkbox]"));
        }

        [Test]
        public void OpenPage_FirstCheckboxUncheckedAndSecondCheckboxChecked()
        {
            var firstCheckboxIsChecked = checkboxes[0].GetAttribute("checked");
            var secondCheckboxIsChecked = checkboxes[1].GetAttribute("checked");

            Assert.Multiple(() =>
                {
                    Assert.That(firstCheckboxIsChecked, Is.Null, "The first checkbox is expected to be unchecked, but it is checked.");
                    Assert.That(secondCheckboxIsChecked, Is.Not.Null, "The second checkbox is expected to be checked, but it is unchecked.");
                }
            );
        }

        [Test]
        public void SelectFirstAndSecondCheckboxes_FirstCheckboxСheckedAndSecondCheckboxUnchecked()
        {
            checkboxes[0].Click();
            checkboxes[1].Click();

            var firstCheckboxIsChecked = checkboxes[0].GetAttribute("checked");
            var secondCheckboxIsChecked = checkboxes[1].GetAttribute("checked");

            Assert.Multiple(() =>
                {
                    Assert.That(firstCheckboxIsChecked, Is.Not.Null, "The first checkbox is expected to be checked, but it is unchecked.");
                    Assert.That(secondCheckboxIsChecked, Is.Null, "The second checkbox is expected to be unchecked, but it is checked.");
                }
            );
        }
    }
}