using NLog;
using OpenQA.Selenium;
using TMS_Selenium.Pages;
using TMS_Selenium.Pages.ProjectPages;

namespace TMS_Selenium.Steps
{
    public class BaseStep
    {
        protected Logger logger = LogManager.GetCurrentClassLogger();
        protected IWebDriver driver;
        protected LoginPage loginPage;
        protected DashboardPage dashboardPage;
        protected AddProjectPage addProjectPage;
        protected ProjectListPage projectListPage;
        protected ConfirmationPage confirmationPage;
        public BaseStep(IWebDriver driver)
        {
            this.driver = driver;
            loginPage = new LoginPage(driver);
            dashboardPage = new DashboardPage(driver);
            addProjectPage = new AddProjectPage(driver);
            projectListPage = new ProjectListPage(driver);
            confirmationPage = new ConfirmationPage(driver);
        }
    }

}
