using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace TMS_Selenium.Test
{
    [TestFixture]
    [Parallelizable(ParallelScope.Self)]
    public class BaseTest
    {
        protected IWebDriver driver;
        private const string url = "https://www.saucedemo.com/";
        protected string userName = "standard_user";
        protected string password = "secret_sauce";
        [SetUp]
        public void Setup()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--incognito");
            driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl(url);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
