using OpenQA.Selenium;

namespace TMS_Selenium.Tests
{
    public class AlertTests : BaseTest
    {
        [SetUp]
        public void Setup()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/alerts");
        }
        
        [Test]
        public void ClickAlertButton_CheckAlertText()
        {
            string expectedAlertText = "You clicked a button";
            
            driver.FindElement(By.Id("alertButton")).Click();
            string actualAlertText = driver.SwitchTo().Alert().Text;

            Assert.That(actualAlertText, Is.EqualTo(expectedAlertText));
        }

        [Test]
        public void ClickTimerAlertButton_CheckAlertText()
        {
            string expectedAlertText = "This alert appeared after 5 seconds";

            driver.FindElement(By.Id("timerAlertButton")).Click();
            wait.WaitForAlertPresent();
            string actualAlertText = driver.SwitchTo().Alert().Text;

            Assert.That(actualAlertText, Is.EqualTo(expectedAlertText));
        }

        [Test]
        public void ClickConfirmButton_AcceptAlert_CheckMessage()
        {
            string expectedMessage = "You selected Ok";

            driver.FindElement(By.Id("confirmButton")).Click();
            driver.SwitchTo().Alert().Accept();
            string actualMessage = driver.FindElement(By.Id("confirmResult")).Text;

            Assert.That(actualMessage, Is.EqualTo(expectedMessage));
        }

        [Test]
        public void ClickConfirmButton_DismissAlert_CheckMessage()
        {
            string expectedMessage = "You selected Cancel";

            driver.FindElement(By.Id("confirmButton")).Click();
            driver.SwitchTo().Alert().Dismiss();
            string actualMessage = driver.FindElement(By.Id("confirmResult")).Text;

            Assert.That(actualMessage, Is.EqualTo(expectedMessage));
        }

        [Test]
        public void ClickPromtButton_EnterText_AcceptAlert_CheckMessage()
        {
            string nameForEnter = "Liska";
            string expectedMessage = $"You entered {nameForEnter}";

            driver.FindElement(By.Id("promtButton")).Click();

            IAlert alert = driver.SwitchTo().Alert();
            alert.SendKeys(nameForEnter);
            alert.Accept();

            string actualMessage = driver.FindElement(By.Id("promptResult")).Text;

            Assert.That(actualMessage, Is.EqualTo(expectedMessage));
        }

        [Test]
        public void ClickPromtButton_EnterText_DismissAlert_CheckNoMessage()
        {
            string nameForEnter = "Liska";

            driver.FindElement(By.Id("promtButton")).Click();

            IAlert alert = driver.SwitchTo().Alert();
            alert.SendKeys(nameForEnter);
            alert.Dismiss();

            int countMessages = driver.FindElements(By.Id("promptResult")).Count;

            Assert.That(countMessages == 0);
        }
    }
}
