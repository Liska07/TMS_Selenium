using OpenQA.Selenium;

namespace TMS_Selenium.Pages
{
    public class ItemPage : BasePage
    {
        private static readonly By _itemNameBy = By.CssSelector("[data-test='inventory-item-name']");
        private static readonly By _productPriceBy = By.CssSelector("[data-test='inventory-item-price']");
        private static readonly By _addToCartButtonBy = By.Id("add-to-cart");
        private static readonly By _removeButtonBy = By.Id("remove");
        private static readonly By _backToProductsButtonBy = By.Id("back-to-products");
        private static readonly By _cartLinkBy = By.CssSelector("[data-test='shopping-cart-link']");
        public ItemPage(IWebDriver driver) : base(driver)
        {
        }
        public IWebElement ItemName() => driver.FindElement(_itemNameBy);
        public IWebElement ProductPrice() => driver.FindElement(_productPriceBy);
        public IWebElement AddToCartButton() => driver.FindElement(_addToCartButtonBy);
        public IWebElement RemoveButton() => driver.FindElement(_removeButtonBy);
        public IWebElement BackToProductsButton() => driver.FindElement(_backToProductsButtonBy);
        public IWebElement CartLink() => driver.FindElement(_cartLinkBy);
        
    }
}
