using Allure.Net.Commons;
using Allure.NUnit.Attributes;
using TMS_Selenium.Pages;
using TMS_Selenium.Test;

namespace TMS_Selenium.Tests
{
    [AllureEpic("TestRail")]
    [AllureFeature("Basic Functionality")]
    [AllureStory("Login")]
    public class LoginTests : BaseTest
    {
        [Test]
        [AllureDescription("Check logging with the correct username and password")]
        [AllureSeverity(SeverityLevel.blocker)]
        public void PositiveLogin()
        {
            Assert.That(userStep.SuccessfulLogin().AddProjectButton().Displayed);
        }

        [Test]
        [AllureDescription("Check the error messages if username and password are not entered")]
        [AllureSeverity(SeverityLevel.normal)]
        public void LoginWithoutUserNameAndPassword()
        {
            string expectedUserNameErrorText = "Email/Login is required.";
            string expectedPasswordErrorText = "Password is required.";

            LoginPage loginPage = userStep.UnsuccessfulLogin();

            string actualUserNameErrorText = loginPage.GetUserNameErrorMessage();
            string actualPasswordErrorText = loginPage.GetPasswordErrorMessage();

            Assert.Multiple(() =>
            {
                Assert.That(actualUserNameErrorText, Is.EqualTo(expectedUserNameErrorText));
                Assert.That(actualPasswordErrorText, Is.EqualTo(expectedPasswordErrorText));
            });
        }

        [Test]
        [AllureDescription("Check the error message if password is less than 5 characters")]
        [AllureSeverity(SeverityLevel.normal)]
        public void LoginWithShortPassword()
        {
            string userName = "WrongUserName";
            string password = "1234";
            string expectedPasswordErrorText = "Password is too short (5 characters required).";

            LoginPage loginPage = userStep.UnsuccessfulLogin(userName, password);

            string actualPasswordErrorText = loginPage.GetPasswordErrorMessage();

            Assert.That(actualPasswordErrorText, Is.EqualTo(expectedPasswordErrorText));
        }

        [Test]
        [AllureDescription("Check the error messages if username and password are incorrect")]
        [AllureSeverity(SeverityLevel.normal)]
        public void LoginWithWrongUserNameAndPassword()
        {
            string userName = "WrongUserName";
            string password = "12345";
            string expectedTopErrorText = "Sorry, there was a problem.";
            string expectedLoginErrorText = "Email/Login or Password is incorrect. Please try again.";

            LoginPage loginPage = userStep.UnsuccessfulLogin(userName, password);

            string actualTopErrorText = loginPage.GetTopErrorMessage();
            string actualLoginErrorText = loginPage.GetLoginErrorMessage();


            Assert.Multiple(() =>
            {
                Assert.That(actualTopErrorText, Is.EqualTo(expectedTopErrorText));
                Assert.That(actualLoginErrorText, Is.EqualTo(expectedLoginErrorText));
            });
        }
    }
}
