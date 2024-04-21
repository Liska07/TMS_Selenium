using Allure.Net.Commons;
using Allure.NUnit.Attributes;
using TMS_Selenium.Utils;

namespace TMS_Selenium.Test
{
    public class LoginTests : BaseTest
    {
        [Test]
        [AllureDescription("Test to check logging with the correct username and password")]
        [AllureSeverity(SeverityLevel.blocker)]
        [AllureIssue("LgI-01")]
        [AllureTms("LgI_TMS-01")]
        [AllureLink("SwagLabsSite", "https://www.saucedemo.com/")]
        [AllureFeature("Basic Functionality")]
        [AllureStory("Login")]
        public void PositiveLogin()
        {
            loginPage.Login(Configurator.ReadConfiguration().UserNameSauceDemo, Configurator.ReadConfiguration().PasswordSauceDemo);

            Assert.That(productsPage.ProductsTitle().Displayed);
        }

        [Test]
        [AllureDescription("Test to check the error message if the correct username is entered, but the password is not entered")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureIssue("LgI-02")]
        [AllureTms("LgI_TMS-01")]
        [AllureFeature("Basic Functionality")]
        [AllureStory("Login")]
        public void LoginWithoutPassword()
        {
            string expectedErrorText = "Epic sadface: Password is required";

            loginPage.Login(Configurator.ReadConfiguration().UserNameSauceDemo);

            string actualErrorText = loginPage.ErrorMessage().Text;

            Assert.That(actualErrorText, Is.EqualTo(expectedErrorText));
        }

        [Test]
        [AllureDescription("Test to check the error message if username and password are not entered")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureIssue("LgI-02")]
        [AllureTms("LgI_TMS-01")]
        [AllureFeature("Basic Functionality")]
        [AllureStory("Login")]
        public void LoginWithoutLoginAndPassword()
        {
            string expectedErrorText = "Epic sadface: Username is required";

            loginPage.Login();

            string actualErrorText = loginPage.ErrorMessage().Text;

            Assert.That(actualErrorText, Is.EqualTo(expectedErrorText));
        }

        [Test]
        [AllureDescription("Test to check screenshots (entire screen and element) in case of a failed test")]
        [AllureFeature("Tests to fail")]
        public void CheckScreenshots()
        {
            string expectedErrorText = "Invalid error text for test failure";

            loginPage.Login();
            logger.Debug("Clicked the \"Login\" button when the username and password fields are empty");

            string actualErrorText = loginPage.ErrorMessage().Text;
            logger.Debug("Got error message text");

            Assert.That(actualErrorText, Is.EqualTo(expectedErrorText));
        }
    }
}
