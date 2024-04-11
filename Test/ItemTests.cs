using TMS_Selenium.Utils;

namespace TMS_Selenium.Test
{
    [TestFixture]
    public class ItemTests : BaseTest
    {
        [Test]
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
                    Assert.That(actualProductNameText, Is.EqualTo(productName), $"Expected item text '{productName}', but got '{actualProductNameText}'.");
                    Assert.That(actualProductPrice, Is.EqualTo(productPrice), $"Expected product price '{productPrice}', but got '{actualProductPrice}'.");
                    Assert.That(itemPage.AddToCartButton().Displayed, "Add To Cart button is not displayed.");
                }
            );
        }

        [Test]
        public void BackToProducts()
        {
            loginPage.Login(Configurator.ReadConfiguration().UserNameSauceDemo, Configurator.ReadConfiguration().PasswordSauceDemo);

            string productName = "Sauce Labs Onesie";
            productsPage.OpenItemPage(productName);
            itemPage.BackToProductsButton().Click();

            Assert.That(productsPage.ProductsTitle().Displayed, "Product title is not displayed.");
        }

        [Test]
        public void AddProduct_CheckQuantityInCartAndButtonText()
        {
            string expectedQuantitytInCart = "1";

            loginPage.Login(Configurator.ReadConfiguration().UserNameSauceDemo, Configurator.ReadConfiguration().PasswordSauceDemo);

            string productName = "Sauce Labs Fleece Jacket";
            productsPage.OpenItemPage(productName);
            itemPage.AddToCartButton().Click();

            string actualQuantityInCart = itemPage.CartLink().Text;

            Assert.Multiple(() =>
                {
                    Assert.That(actualQuantityInCart, Is.EqualTo(expectedQuantitytInCart), $"Expected quantity in cart '{expectedQuantitytInCart}', but got '{actualQuantityInCart}'.");
                    Assert.That(itemPage.RemoveButton().Displayed, "Remove button is not displayed.");
                }
            );
        }
    }
}
