using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace TMS_Selenium.Utils
{
    public class WaitHelper
    {
        private IWebDriver _driver;
        private TimeSpan _timeout;
        private WebDriverWait _wait;
 
        public WaitHelper(IWebDriver driver)
        {
            _driver = driver;
            _timeout = TimeSpan.FromSeconds(10);
            _wait = new WebDriverWait(_driver, _timeout);
        }

        public IWebElement WaitForElementVisible(By locator)
        {
            return _wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public bool WaitForElementInvisible(By locator)
        {
            return _wait.Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
        }

        public void WaitForAlertPresent()
        {
            _wait.Until(ExpectedConditions.AlertIsPresent());
        }

        public IWebElement WaitForElementExists(By locator)
        {
            return _wait.Until(ExpectedConditions.ElementExists(locator));
        }
    }
}
