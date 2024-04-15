using OpenQA.Selenium;

namespace TMS_Selenium.Tests
{
    public class ActionsTests : BaseTest
    {
        [Test]
        public void ContextClick_CheckAlertText()
        {
            string expectedText = "You selected a context menu";

            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/context_menu");
            actions
                .MoveToElement(driver.FindElement(By.Id("hot-spot")), 15, 15)
                .ContextClick()
                .Build()
                .Perform();

            Assert.That(driver.SwitchTo().Alert().Text, Is.EqualTo(expectedText));
        }
    }
}
