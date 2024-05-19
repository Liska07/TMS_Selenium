using Allure.NUnit.Attributes;
using OpenQA.Selenium;
using TMS_Selenium.Pages;
using TMS_Selenium.Utils;

namespace TMS_Selenium.Steps
{
    public class UserStep : BaseStep
    {
        public UserStep(IWebDriver driver) : base(driver)
        {
        }

        [AllureStep("Successful login")]
        public DashboardPage SuccessfulLogin()
        {
            Login(Configurator.ReadConfiguration().UserName, Configurator.ReadConfiguration().Password);
            logger.Info("Login successful");
            return dashboardPage;
        }

        public LoginPage UnsuccessfulLogin(string userName = "", string password = "")
        {
            Login(userName, password);
            return loginPage;
        }
        public void Login(string userName, string password)
        {
            loginPage.UserNameField().SendKeys(userName);
            loginPage.PasswordFeld().SendKeys(password);
            loginPage.LoginButton().Click();
        } 
    }
}
