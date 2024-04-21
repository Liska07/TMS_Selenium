using Allure.NUnit.Attributes;
using OpenQA.Selenium;

namespace TMS_Selenium.Pages
{
    public class LoginPage : BasePage
    {
        protected IWebDriver driver;

        private static readonly By _userNameFieldBy = By.Id("user-name");
        private static readonly By _passwordFeldBy = By.Id("password");
        private static readonly By _loginButtonBy = By.Id("login-button");
        private static readonly By _errorMessageBy = By.CssSelector("[data-test='error']");
        private static readonly By _loginTitleBy = By.CssSelector(".login_logo");
        private static readonly By _loginContainerBy = By.Id("login_button_container");
        public LoginPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }
        public IWebElement UserNameField() => driver.FindElement(_userNameFieldBy);
        public IWebElement PasswordFeld() => driver.FindElement(_passwordFeldBy);
        public IWebElement LoginButton() => driver.FindElement(_loginButtonBy);
        public IWebElement ErrorMessage() => driver.FindElement(_errorMessageBy);
        public IWebElement LoginTitle() => driver.FindElement(_loginTitleBy);
        public IWebElement LoginContainer() => driver.FindElement(_loginContainerBy);
        
        [AllureStep("Login")]
        public void Login(string userName = "", string password = "")
        {
            UserNameField().SendKeys(userName);
            PasswordFeld().SendKeys(password);
            LoginButton().Click();
        }
    }
}
