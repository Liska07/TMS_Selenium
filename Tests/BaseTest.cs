using Allure.Net.Commons;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using NLog;
using OpenQA.Selenium;
using TMS_Selenium.Core;
using TMS_Selenium.Utils;
using TMS_Selenium.Steps;


namespace TMS_Selenium.Test
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    [FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    [AllureNUnit]
    [AllureOwner("EAntonova")]
    public class BaseTest
    {
        protected IWebDriver driver;
        protected UserStep userStep;
        protected NavigationStep navigationStep;
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
            driver.Navigate().GoToUrl(Configurator.ReadConfiguration().TestRailURL);
            userStep = new UserStep(driver);
            navigationStep = new NavigationStep(driver);
        }

        [TearDown]
        [AllureAfter("Driver quite")]
        public void TearDown()
        {
            try
            {
                if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
                {
                    AttachScreenshotToAllure((ITakesScreenshot)driver, "Screenshot");
                    logger.Info("Attached a screenshot to Allure");
                }
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