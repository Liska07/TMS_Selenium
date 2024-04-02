using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace TMS_Selenium.Tests
{
    public class Data_Tables
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--incognito");
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/tables");
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void CheckTextTable1Row1Column1()
        {
            var element = driver.FindElement(By.XPath("//table[@id='table1']//tr[1]/td[1]"));
            var elementText = element.Text;
            string expectedText = "Smith";
            Assert.IsTrue(elementText == expectedText, $"Expected the text '{expectedText}' in the first row, first column of table1, but got '{elementText}'.");
        }

        [Test]
        public void CheckTextTable1Row3Column4()
        {
            var element = driver.FindElement(By.XPath("//table[@id='table1']//tr[3]/td[4]"));
            var elementText = element.Text;
            string expectedText = "$100.00";
            Assert.IsTrue(elementText == expectedText, $"Expected the text '{expectedText}' in the third row, fourth column of table1, but got '{elementText}'.");
        }

        [Test]
        public void CheckTextTable2Row1ColumnEmail()
        {
            var element = driver.FindElement(By.XPath("//table[@id='table2']//tr[1]/td[@class='email']"));
            var elementText = element.Text;
            string expectedText = "jsmith@gmail.com";
            Assert.IsTrue(elementText == expectedText, $"Expected the text '{expectedText}' in the first row, 'email' column of table2, but got '{elementText}'.");
        }

        [Test]
        public void CheckTextTable2Row4ColumnWebSite()
        {
            var element = driver.FindElement(By.XPath("//table[@id='table2']//tr[4]/td[@class='web-site']"));
            var elementText = element.Text;
            string expectedText = "http://www.timconway.com";
            Assert.IsTrue(elementText == expectedText, $"Expected the text '{expectedText}' in the fourth row, 'web-site' column of table2, but got '{elementText}'.");
        }

        [TearDown]
        public void OneTimeTearDown()
        {
            driver.Quit();
        }
    }
}
