using OpenQA.Selenium;
using TMS_Selenium.Element;

namespace TMS_Selenium.Pages
{
    public class LoginPage : BasePage
    {
        private static readonly By _userNameFieldBy = By.Name("name");
        private static readonly By _passwordFeldBy = By.Name("password");
        private static readonly By _loginButtonBy = By.Id("button_primary");
        private string _endPoint = "";

        public LoginPage(IWebDriver driver) : base(driver)
        {
        }
        public UiElement UserNameField() => new UiElement(driver, _userNameFieldBy);
        public UiElement PasswordFeld() => new UiElement(driver, _passwordFeldBy);
        public Button LoginButton() => new Button(driver, _loginButtonBy);

        public override string GetEndpoint()
        {
            return _endPoint;
        }

        protected override bool EvaluateLoadedStatus()
        {
            return LoginButton().Displayed;
        }
    }
}