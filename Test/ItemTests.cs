using Allure.Net.Commons;
using Allure.NUnit.Attributes;
using TMS_Selenium.Utils;

namespace TMS_Selenium.Test
{
    [AllureFeature("Shopping")]
    public class ItemTests : BaseTest
    {
        [Test]
        [AllureDescription("Test to check information on the Item page: the price and name of the product are the same as on the Products page, " +
            "and the \"Add to cart\" button is displayed")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureStory("Viewing products")]
        public void OpenItemPage_CheckProductNameAndPriceAndButton()
        {
            loginPage.Login(Configurator.ReadConfiguration().UserNameSauceDemo, Configurator.ReadConfiguration().PasswordSauceDemo);

            string productName = "Sauce Labs Bike Light";
            string productPrice = productsPage.ProductPrice(productName).Text;

            productsPage.OpenItemPage(productName);

            string actualProductNameText = itemPage.ItemName().Text;
            string actualProductPrice = itemPage.ProductPrice().Text;

            Assert.Multiple(() =>
                {
                    Assert.That(actualProductNameText, Is.EqualTo(productName));
                    Assert.That(actualProductPrice, Is.EqualTo(productPrice));
                    Assert.That(itemPage.AddToCartButton().Displayed);
                }
            );
        }

        [Test]
        [AllureDescription("Test to check a button to return from an Item page to Products page")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureStory("Viewing products")]
        public void BackToProducts()
        {
            loginPage.Login(Configurator.ReadConfiguration().UserNameSauceDemo, Configurator.ReadConfiguration().PasswordSauceDemo);

            string productName = "Sauce Labs Onesie";
            productsPage.OpenItemPage(productName);
            itemPage.BackToProductsButton().Click();

            Assert.That(productsPage.ProductsTitle().Displayed);
        }

        [Test]
        [AllureDescription("Test to check the displayed number of products in the cart and the text on the button after adding product to the cart on the Item page")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureStory("Adding products to cart")]
        public void AddProductItemPage_CheckQuantityInCartAndButtonText()
        {
            string expectedQuantitytInCart = "1";

            loginPage.Login(Configurator.ReadConfiguration().UserNameSauceDemo, Configurator.ReadConfiguration().PasswordSauceDemo);

            string productName = "Sauce Labs Fleece Jacket";
            productsPage.OpenItemPage(productName);
            itemPage.AddToCartButton().Click();

            string actualQuantityInCart = headerPage.CartLink().Text;

            Assert.Multiple(() =>
                {
                    Assert.That(actualQuantityInCart, Is.EqualTo(expectedQuantitytInCart));
                    Assert.That(itemPage.RemoveButton().Displayed);
                }
            );
        }
    }
}
