using TMS_Selenium.Utils;

namespace TMS_Selenium.Test
{
    public class LoginTests : BaseTest
    {
        [Test]
        public void PositiveLogin()
        {
            loginPage.Login(Configurator.ReadConfiguration().UserNameSauceDemo, Configurator.ReadConfiguration().PasswordSauceDemo);

            Assert.That(productsPage.ProductsTitle().Displayed, "Product title is not displayed.");
        }

        [Test]
        public void LoginWithoutPassword()
        {
            string expectedErrorText = "Epic sadface: Password is required";

            loginPage.Login(Configurator.ReadConfiguration().UserNameSauceDemo);

            string actualErrorText = loginPage.ErrorMessage().Text;

            Assert.That(actualErrorText, Is.EqualTo(expectedErrorText), $"Expected the error text '{expectedErrorText}', but got '{actualErrorText}'.");
        }

        [Test]
        public void LoginWithoutLoginAndPassword()
        {
            string expectedErrorText = "Epic sadface: Username is required";

            loginPage.Login();

            string actualErrorText = loginPage.ErrorMessage().Text;

            Assert.That(actualErrorText, Is.EqualTo(expectedErrorText), $"Expected the error text '{expectedErrorText}', but got '{actualErrorText}'.");
        }
    }
}
