using OpenQA.Selenium;
using TMS_Selenium.Utils;
using TMS_Selenium.Core;
using TMS_Selenium.Pages;
using Allure.NUnit;
using Allure.Net.Commons;

namespace TMS_Selenium.Test
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    [AllureNUnit]
    public class BaseTest
    {
        protected IWebDriver driver;
        protected LoginPage loginPage;
        protected ProductsPage productsPage;
        protected ItemPage itemPage;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            AllureLifecycle.Instance.CleanupResultDirectory();
        }

        [SetUp]
        public void Setup()
        {
            driver = new Browser().Driver;
            driver.Navigate().GoToUrl(Configurator.ReadConfiguration().SauceDemoURL);
            loginPage = new LoginPage(driver);
            productsPage = new ProductsPage(driver);
            itemPage = new ItemPage(driver);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
        }
    }
}