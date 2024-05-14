using Allure.NUnit.Attributes;
using OpenQA.Selenium;

namespace TMS_Selenium.Pages
{
    public class HeaderPage : BasePage
    {
        private static readonly By _menuButtonBy = By.Id("react-burger-menu-btn");
        private static readonly By _logoutLinkBy = By.Id("logout_sidebar_link");
        private static readonly By _cartLinkBy = By.CssSelector("[data-test='shopping-cart-link']");
        public HeaderPage(IWebDriver driver) : base(driver)
        {
        }
        public IWebElement MenuButton() => driver.FindElement(_menuButtonBy);
        public IWebElement LogoutLink() => driver.FindElement(_logoutLinkBy);
        public IWebElement CartLink() => driver.FindElement(_cartLinkBy);
        
        [AllureStep("Logout")]
        public void Logout()
        {
            MenuButton().Click();
            LogoutLink().Click();
        }
    }
}
