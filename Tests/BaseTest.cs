using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace TMS_Selenium.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class BaseTest
    {
        protected IWebDriver driver;
        protected Actions actions;

        [SetUp]
        public void Setup()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--incognito");
            driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            actions = new Actions(driver);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
        }
    }
}