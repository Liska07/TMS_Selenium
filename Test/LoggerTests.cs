using Allure.NUnit.Attributes;

namespace TMS_Selenium.Test
{
    public class LoggerTests : BaseTest
    {
        [Test]
        [AllureDescription("Test to check logging functionality")]
        public void LoggerTest()
        {
            logger.Trace("Trace message from LoggerTest");
            logger.Debug("Debug message from LoggerTest");
            logger.Info("Info message from LoggerTest");
            logger.Warn("Warn message from LoggerTest");
            logger.Error("Error message from LoggerTest");
            logger.Fatal("Fatal message from LoggerTest");
        }
    }
}
