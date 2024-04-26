using OpenQA.Selenium;
using TMS_Selenium.Pages.ProjectPages;

namespace TMS_Selenium.Steps
{
    public class NavigationStep : BaseStep
    {
        public NavigationStep(IWebDriver driver) : base(driver)
        {
        }

        public ProjectListPage NavigateToProjectList()
        {
            return new ProjectListPage(driver, true);
        }
    }
}
