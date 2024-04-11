using OpenQA.Selenium;
using TMS_Selenium.Utils;
using TMS_Selenium.Core;
using TMS_Selenium.Pages;

namespace TMS_Selenium.Test
{
    [Parallelizable(ParallelScope.Fixtures)]
    public class BaseTest
    {
        protected IWebDriver driver;
        protected LoginPage loginPage;
        protected ProductsPage productsPage;
        protected ItemPage itemPage;


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