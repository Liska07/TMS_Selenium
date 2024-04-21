using TMS_Selenium.Utils;
using Allure.NUnit.Attributes;
using Allure.Net.Commons;

namespace TMS_Selenium.Test
{
    public class ProductsTests : BaseTest
    {
        [Test]
        [AllureDescription("Test to check Logout")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureIssue("LgO-01")]
        [AllureFeature("Basic Functionality")]
        [AllureStory("Logout")]
        public void Logout()
        {
            loginPage.Login(Configurator.ReadConfiguration().UserNameSauceDemo, Configurator.ReadConfiguration().PasswordSauceDemo);
            headerPage.Logout();

            Assert.That(loginPage.LoginTitle().Displayed);
        }

        [Test]
        [AllureDescription("Test to check the displayed number of products in the cart and the text on the buttons after adding products to the cart")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureFeature("Shopping")]
        [AllureStory("Adding products to cart")]
        public void AddProducts_CheckQuantityInCartAndButtonsText()
        {
            string expectedQuantitytInCart = "2";
            string expectedButtonText = "Remove";
            string firstProduct = "Sauce Labs Bolt T-Shirt";
            string secondProduct = "Sauce Labs Backpack";

            loginPage.Login(Configurator.ReadConfiguration().UserNameSauceDemo, Configurator.ReadConfiguration().PasswordSauceDemo);
            productsPage.ProductButton(firstProduct).Click();
            productsPage.ProductButton(secondProduct).Click();

            string actualQuantityInCart = headerPage.CartLink().Text;
            string actuaFirstProductButtonText = productsPage.ProductButton(firstProduct).Text;
            string actualSecondProductButtonText = productsPage.ProductButton(secondProduct).Text;

            Assert.Multiple(() =>
                {
                    Assert.That(actualQuantityInCart, Is.EqualTo(expectedQuantitytInCart));
                    Assert.That(actuaFirstProductButtonText, Is.EqualTo(expectedButtonText));
                    Assert.That(actualSecondProductButtonText, Is.EqualTo(expectedButtonText));
                }
            );
        }

        [Test]
        [AllureDescription("Test to check an empty cart and text on a button after adding a product to the cart and deleting it")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureFeature("Shopping")]
        [AllureStory("Adding products to cart")]
        public void AddAndRemoveProduct_CheckQuantityInCartAndButtonText()
        {
            string expectedQuantitytInCart = "";
            string expectedButtonText = "Add to cart";

            loginPage.Login(Configurator.ReadConfiguration().UserNameSauceDemo, Configurator.ReadConfiguration().PasswordSauceDemo);
            productsPage.ProductButton("Sauce Labs Fleece Jacket").Click();
            productsPage.ProductButton("Sauce Labs Fleece Jacket").Click();

            string actualQuantityInCart = headerPage.CartLink().Text;
            string actualButtonText = productsPage.ProductButton("Sauce Labs Fleece Jacket").Text;
            
            Assert.Multiple(() =>
                {
                    Assert.That(actualQuantityInCart, Is.EqualTo(expectedQuantitytInCart));
                    Assert.That(actualButtonText, Is.EqualTo(expectedButtonText));
                }
            );
        }

        [Test]
        [AllureDescription("Test to check the operation of \"try-catch\" in Tear Down in case of a failed test")]
        [AllureFeature("Tests to fail")]
        public void CheckTryCatchInTearDown()
        {
            string expectedButtonText = "Invalid button text for test failure";

            loginPage.Login(Configurator.ReadConfiguration().UserNameSauceDemo, Configurator.ReadConfiguration().PasswordSauceDemo);
            logger.Debug("Successful login");

            productsPage.ProductButton("Sauce Labs Fleece Jacket").Click();
            logger.Debug("Clicked on product button");

            string actualButtonText = productsPage.ProductButton("Sauce Labs Fleece Jacket").Text;
            logger.Debug("Got button text");

            Assert.That(actualButtonText, Is.EqualTo(expectedButtonText));
        }
    }
}
