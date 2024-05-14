using Allure.Net.Commons;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using NLog;
using OpenQA.Selenium;
using TMS_Selenium.Core;
using TMS_Selenium.Pages;
using TMS_Selenium.Utils;

namespace TMS_Selenium.Test
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    [FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    [AllureNUnit]
    [AllureOwner("EAntonova")]
    [AllureEpic("Swag Labs")]
    public class BaseTest
    {
        protected IWebDriver driver;
        protected HeaderPage headerPage;
        protected LoginPage loginPage;
        protected ProductsPage productsPage;
        protected ItemPage itemPage;
        protected Logger logger = LogManager.GetCurrentClassLogger();

        [OneTimeSetUp]
        [AllureBefore("Clear allure-results directory")]
        public static void OneTimeSetUp()
        {
            AllureLifecycle.Instance.CleanupResultDirectory();
        }

        [SetUp]
        [AllureBefore("Set up driver")]
        public void Setup()
        {
            driver = new Browser().Driver;
            driver.Navigate().GoToUrl(Configurator.ReadConfiguration().SauceDemoURL);
            headerPage = new HeaderPage(driver);
            loginPage = new LoginPage(driver);
            productsPage = new ProductsPage(driver);
            itemPage = new ItemPage(driver);
        }

        [TearDown]
        [AllureAfter("Driver quite")]
        public void TearDown()
        {
            try
            {
                if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
                {
                    AttachScreenshotToAllure((ITakesScreenshot)driver, "ScreenshotEntireScreen");
                    logger.Info("Attached a screenshot of the entire screen to Allure");

                    try
                    {
                        AttachScreenshotToAllure((ITakesScreenshot)loginPage.LoginContainer(), "ScreenshotElement");
                        logger.Info("Attached a screenshot of the element to  Allure");
                    }
                    catch (NoSuchElementException)
                    { }
                }
                //var errorLogFilePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "ErrorLogFile.txt");
                //AllureApi.AddAttachment("errorLog", "text/html", errorLogFilePath);
            }
            catch (Exception ex)
            {
                logger.Error("Screenshot cannot be attached! " + ex);
                throw;
            }
            finally 
            { 
                driver.Dispose(); 
            }
        }

        private void AttachScreenshotToAllure(ITakesScreenshot takesscreenshot, string name)
        {
            Screenshot screenshot = takesscreenshot.GetScreenshot();
            byte[] screenshotByte = screenshot.AsByteArray;
            AllureApi.AddAttachment(name, "image/png", screenshotByte);
        }
    }
}