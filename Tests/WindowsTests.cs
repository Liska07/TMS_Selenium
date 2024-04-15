using OpenQA.Selenium;

namespace TMS_Selenium.Tests
{
    public class WindowsTests : BaseTest
    {
        [SetUp]
        public void SetUp() 
        {
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/windows");
        }

        [Test]
        public void OpenNewWindow_CheckTextInNewWindow_CountWindows()
        {
            string expectedText = "New Window";
            int expectedCountWindows = 2;
            
            driver.FindElement(By.LinkText("Click Here")).Click();
            driver.SwitchTo().Window(driver.WindowHandles.Last());

            Assert.Multiple(() =>
            {
                Assert.That(driver.FindElement(By.TagName("h3")).Text, Is.EqualTo(expectedText));
                Assert.That(driver.WindowHandles.Count == expectedCountWindows);
            });
        }

        [Test]
        public void OpenSeveralWindows_CloseOneWindow_CheckCountWindows()
        {
            int expectedCountWindows = 3;
            string generalWindowHandle = driver.CurrentWindowHandle;

            IWebElement clickHereButton = driver.FindElement(By.LinkText("Click Here"));
            clickHereButton.Click();
            clickHereButton.Click();
            driver.SwitchTo().Window(driver.WindowHandles.Last()).Close();
            driver.SwitchTo().Window(generalWindowHandle);
            clickHereButton.Click();

            Assert.That(driver.WindowHandles.Count == expectedCountWindows);
        }
    }
}
