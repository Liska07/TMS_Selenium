using OpenQA.Selenium;

namespace TMS_Selenium.Pages
{
    public class ProductsPage : BasePage
    {
        private static readonly By _productsTitleBy = By.XPath("//*[text()='Products']");
        private static readonly By _menuButtonBy = By.Id("react-burger-menu-btn");
        private static readonly By _logoutLinkBy = By.Id("logout_sidebar_link");
        private static readonly By _cartLinkBy = By.CssSelector("[data-test='shopping-cart-link']");
        public ProductsPage(IWebDriver driver) : base(driver)
        {
        }
        public IWebElement ProductsTitle() => driver.FindElement(_productsTitleBy);
        public IWebElement MenuButton() => driver.FindElement(_menuButtonBy);
        public IWebElement LogoutLink() => driver.FindElement(_logoutLinkBy);
        public IWebElement CartLink() => driver.FindElement(_cartLinkBy);
        public IWebElement ProductButton(string productName) =>
            driver.FindElement(By.XPath($"//*[text()='{productName}']/ancestor::*[contains(@class, 'description')]//button"));
        public IWebElement ProductPrice(string productName) =>
            driver.FindElement(By.XPath($"//*[text()='{productName}']/ancestor::*[contains(@class, 'description')]//*[contains(@class, 'item_price')]"));
        public void OpenItemPage(string productName) =>
            driver.FindElement(By.XPath($"//*[text()='{productName}']")).Click();
    }
}
