using TMS_Selenium.Utils;

namespace TMS_Selenium.Test
{
    public class ProductsTests : BaseTest
    {
        [Test]
        public void Logout()
        {
            loginPage.Login(Configurator.ReadConfiguration().UserNameSauceDemo, Configurator.ReadConfiguration().PasswordSauceDemo);
            productsPage.MenuButton().Click();
            productsPage.LogoutLink().Click();

            Assert.That(loginPage.LoginTitle().Displayed, "Login title is not displayed.");
        }

        [Test]
        public void AddProducts_CheckQuantityInCartAndButtonsText()
        {
            string expectedQuantitytInCart = "2";
            string expectedButtonText = "Remove";
            string firstProduct = "Sauce Labs Bolt T-Shirt";
            string secondProduct = "Sauce Labs Backpack";

            loginPage.Login(Configurator.ReadConfiguration().UserNameSauceDemo, Configurator.ReadConfiguration().PasswordSauceDemo);
            productsPage.ProductButton(firstProduct).Click();
            productsPage.ProductButton(secondProduct).Click();

            string actualQuantityInCart = productsPage.CartLink().Text;
            string actuaFirstProductButtonText = productsPage.ProductButton(firstProduct).Text;
            string actualSecondProductButtonText = productsPage.ProductButton(secondProduct).Text;

            Assert.Multiple(() =>
                {
                    Assert.That(actualQuantityInCart, Is.EqualTo(expectedQuantitytInCart), $"Expected quantity in cart '{expectedQuantitytInCart}', but got '{actualQuantityInCart}'.");
                    Assert.That(actuaFirstProductButtonText, Is.EqualTo(expectedButtonText), $"Expected the button text '{expectedButtonText}', but got '{actuaFirstProductButtonText}'.");
                    Assert.That(actualSecondProductButtonText, Is.EqualTo(expectedButtonText), $"Expected the button text '{expectedButtonText}', but got '{actualSecondProductButtonText}'.");
                }
            );
        }

        [Test]
        public void AddAndRemoveProduct_CheckQuantityInCartAndButtonText()
        {
            string expectedQuantitytInCart = "";
            string expectedButtonText = "Add to cart";

            loginPage.Login(Configurator.ReadConfiguration().UserNameSauceDemo, Configurator.ReadConfiguration().PasswordSauceDemo);
            productsPage.ProductButton("Sauce Labs Fleece Jacket").Click();
            productsPage.ProductButton("Sauce Labs Fleece Jacket").Click();

            string actualQuantityInCart = productsPage.CartLink().Text;
            string actualButtonText = productsPage.ProductButton("Sauce Labs Fleece Jacket").Text;
            
            Assert.Multiple(() =>
                {
                    Assert.That(actualQuantityInCart, Is.EqualTo(expectedQuantitytInCart), $"Expected quantity in cart '{expectedQuantitytInCart}', but got '{actualQuantityInCart}'.");
                    Assert.That(actualButtonText, Is.EqualTo(expectedButtonText), $"Expected the button text '{expectedButtonText}', but got '{actualButtonText}'.");
                }
            );
        }
    }
}
