using OpenQA.Selenium;

namespace TMS_Selenium.Tests
{
    public class DynamicControlsTests : BaseTest
    {
        [SetUp]
        public void Setup()
        {
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/dynamic_controls");
        }

        [Test]
        public void CheckCheckboxText()
        {
            string expectedCheckboxText = "A checkbox";
            string actualCheckboxText = wait.WaitForElementExists(By.Id("checkbox")).Text;

            Assert.That(actualCheckboxText, Is.EqualTo(expectedCheckboxText));
        }
        
        [Test]
        public void ClickRemoveButton_CheckLoadingText_LoadingInvisible()
        {
            string expectedLoadingText = "Wait for it...";

            wait.WaitForElementExists(By.XPath("//button[text()='Remove']")).Click();

            string actualLoadingText = wait.WaitForElementVisible(By.Id("loading")).Text;

            Assert.Multiple(() =>
            {
                Assert.That(actualLoadingText, Is.EqualTo(expectedLoadingText));
                Assert.That(wait.WaitForElementInvisible(By.Id("loading")));
            });
        }

        [Test]
        public void ClickRemoveButton_CheckMessage_NoCheckboxes_AddButtonDisplayed()
        {
            string expectedMessage = "It's gone!";

            wait.WaitForElementExists(By.XPath("//button[text()='Remove']")).Click();

            string actualMessage = wait.WaitForElementVisible(By.Id("message")).Text;

            Assert.Multiple(() =>
            {
                Assert.That(actualMessage, Is.EqualTo(expectedMessage));
                Assert.That(wait.WaitForElementInvisible(By.Id("checkbox")));
                Assert.That(wait.WaitForElementExists(By.XPath("//button[text()='Add']")).Displayed);
            });
        }

    }
}
