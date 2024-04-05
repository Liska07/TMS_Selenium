using OpenQA.Selenium;

namespace TMS_Selenium.Test
{
    [TestFixture]
    public class LoginPageTests : BaseTest
    {
        [Test]
        public void PositiveLogin()
        {
            IWebElement userNameField = driver.FindElement(By.Id("user-name"));
            IWebElement passwordField = driver.FindElement(By.Name("password"));
            IWebElement loginButton = driver.FindElement(By.CssSelector(".submit-button.btn_action"));

            userNameField.SendKeys(userName);
            passwordField.SendKeys(password);
            loginButton.Click();

            IWebElement productTitle = driver.FindElement(By.ClassName("title"));

            Assert.That(productTitle.Displayed, "Product title is not displayed.");
        }

        [Test]
        public void LoginWithoutPassword() 
        {
            string expectedErrorText = "Epic sadface: Password is required";

            IWebElement userNameField = driver.FindElement(By.CssSelector("#user-name"));
            IWebElement loginButton = driver.FindElement(By.CssSelector("[data-test='login-button']"));

            userNameField.SendKeys(userName);
            loginButton.Click();

            string actualErrorText = driver.FindElement(By.TagName("h3")).Text;

            Assert.That(actualErrorText, Is.EqualTo(expectedErrorText), $"Expected the error text '{expectedErrorText}', but got '{actualErrorText}'.");
        }

        [Test]
        public void LoginWithoutLoginAndPassword()
        {
            string expectedErrorText = "Epic sadface: Username is required";

            IWebElement loginButton = driver.FindElement(By.CssSelector("[id|='login']"));
            loginButton.Click();

            string actualErrorText = driver.FindElement(By.CssSelector("h3")).Text;

            Assert.That(actualErrorText, Is.EqualTo(expectedErrorText), $"Expected the error text '{expectedErrorText}', but got '{actualErrorText}'.");
        }
    }
}
