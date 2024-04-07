using OpenQA.Selenium;

namespace TMS_Selenium.Tests
{
    [TestFixture]
    public class Data_Tables : BaseTest
    {
        [SetUp]
        public void SetUp()
        {
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/tables");
        }

        [Test]
        public void CheckTextTable1Row1Column1()
        {
            var element = driver.FindElement(By.XPath("//table[@id='table1']//tr[1]/td[1]"));
            var elementText = element.Text;
            string expectedText = "Smith";
            Assert.That(elementText == expectedText, $"Expected the text '{expectedText}' in the first row, first column of table1, but got '{elementText}'.");
        }

        [Test]
        public void CheckTextTable1Row3Column4()
        {
            var element = driver.FindElement(By.XPath("//table[@id='table1']//tr[3]/td[4]"));
            var elementText = element.Text;
            string expectedText = "$100.00";
            Assert.That(elementText == expectedText, $"Expected the text '{expectedText}' in the third row, fourth column of table1, but got '{elementText}'.");
        }

        [Test]
        public void CheckTextTable2Row1ColumnEmail()
        {
            var element = driver.FindElement(By.XPath("//table[@id='table2']//tr[1]/td[@class='email']"));
            var elementText = element.Text;
            string expectedText = "jsmith@gmail.com";
            Assert.That(elementText == expectedText, $"Expected the text '{expectedText}' in the first row, 'email' column of table2, but got '{elementText}'.");
        }

        [Test]
        public void CheckTextTable2Row4ColumnWebSite()
        {
            var element = driver.FindElement(By.XPath("//table[@id='table2']//tr[4]/td[@class='web-site']"));
            var elementText = element.Text;
            string expectedText = "http://www.timconway.com";
            Assert.That(elementText == expectedText, $"Expected the text '{expectedText}' in the fourth row, 'web-site' column of table2, but got '{elementText}'.");
        }
    }
}
