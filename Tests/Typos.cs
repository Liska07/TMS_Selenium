using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace TMS_Selenium.Tests
{
    [TestFixture]
    public class Typos : BaseTest
    {
        ReadOnlyCollection<IWebElement> paragraphs;

        [SetUp]
        public void SetUp()
        {
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/typos");
            paragraphs = driver.FindElements(By.TagName("p"));
        }

        [Test]
        public void CheckFirstParagraphs()
        {
            var paragraphText = paragraphs[0].Text;
            Assert.That(paragraphText == "This example demonstrates a typo being introduced. It does it randomly on each page load.", $"Typos found in the text of the paragraph: '{paragraphText}'");
        }

        [Test]
        public void CheckSecondParagraphs()
        {
            var paragraphText = paragraphs[1].Text;
            Assert.That(paragraphText == "Sometimes you'll see a typo, other times you won't.", $"Typos found in the text of the paragraph: '{paragraphText}'");
        }
    }
}
