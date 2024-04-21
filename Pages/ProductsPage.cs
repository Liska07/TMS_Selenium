using Allure.NUnit.Attributes;
using OpenQA.Selenium;

namespace TMS_Selenium.Pages
{
    public class ProductsPage : BasePage
    {
        protected IWebDriver driver;

        private static readonly By _productsTitleBy = By.XPath("//*[text()='Products']");
        

        public ProductsPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }
        public IWebElement ProductsTitle() => driver.FindElement(_productsTitleBy);
        public IWebElement ProductButton(string productName) =>
            driver.FindElement(By.XPath($"//*[text()='{productName}']/ancestor::*[contains(@class, 'description')]//button"));
        public IWebElement ProductPrice(string productName) =>
            driver.FindElement(By.XPath($"//*[text()='{productName}']/ancestor::*[contains(@class, 'description')]//*[contains(@class, 'item_price')]"));

        [AllureStep("Open item page")]
        public void OpenItemPage(string productName) =>
            driver.FindElement(By.XPath($"//*[text()='{productName}']")).Click();
    }
}
