using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;

namespace TMS_Selenium.Tests
{
    public class Typos
    {
        private IWebDriver driver;
        ReadOnlyCollection<IWebElement> paragraphs;

        [SetUp]
        public void Setup()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--incognito");
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/typos");
            driver.Manage().Window.Maximize();

            paragraphs = driver.FindElements(By.TagName("p"));
        }

        [Test]
        public void CheckFirstParagraphs()
        {
            var paragraphText = paragraphs[0].Text;
            Assert.IsTrue(paragraphText == "This example demonstrates a typo being introduced. It does it randomly on each page load.", $"Typos found in the text of the paragraph: '{paragraphText}'");
        }

        [Test]
        public void CheckSecondParagraphs()
        {
            var paragraphText = paragraphs[1].Text;
            Assert.IsTrue(paragraphText == "Sometimes you'll see a typo, other times you won't.", $"Typos found in the text of the paragraph: '{paragraphText}'");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
