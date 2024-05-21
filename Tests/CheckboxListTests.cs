using Allure.NUnit.Attributes;
using OpenQA.Selenium;
using TMS_Selenium.Element;
using TMS_Selenium.Test;

namespace TMS_Selenium.Tests
{
    [Category("Herokuapp")]
    [AllureEpic("Herokuapp")]
    [AllureFeature("CheckboxList")]
    public class CheckboxListTests : BaseTest
    {
        [SetUp]
        public void SetUp()
        {
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/checkboxes");
        }

        [Test]
        [AllureDescription("Check positive scenarios for 'Checkbox List' methods")]
        public void Checkbox_SelectByIndex()
        {
            CheckboxList checkboxes = new CheckboxList(driver, By.CssSelector("[type = checkbox]"));

            checkboxes.SelectByIndex(0);
            checkboxes.SelectByIndex(1);

            Assert.Multiple(() =>
            {
                Assert.That(checkboxes.IsCheckedByIndex(0));
                Assert.That(!checkboxes.IsCheckedByIndex(1));
            });
        }

        [Test]
        [AllureDescription("Check the correct operation of 'if-else' structures in 'Checkbox List' methods")]
        public void Checkbox_Negative()
        {
            CheckboxList checkbox = new CheckboxList(driver, By.CssSelector("[type = checkbox]"));

            //Uncomment what you need:
            checkbox.SelectByIndex(9);
            //checkbox.SelectByIndex(-11);
            //checkbox.IsChecked(10);
        }
    }
}
