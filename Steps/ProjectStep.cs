using Allure.NUnit.Attributes;
using OpenQA.Selenium;
using TMS_Selenium.Models;
using TMS_Selenium.Pages.ProjectPages;

namespace TMS_Selenium.Steps
{
    public class ProjectStep : BaseStep
    {
        public ProjectStep(IWebDriver driver) : base(driver)
        {
        }

        [AllureStep("Add a project with a given name and a radio button index")]
        public ProjectListPage AddProjectWithNameAndRadioButton(string projectName, int index)
        {
            new NavigationStep(driver).NavigateToProjectList();
            projectListPage.AddProjectButton().Click();

            addProjectPage.NameField().SendKeys(projectName);
            addProjectPage.ProjectTypeRadioButton().SelectByIndex(index);
            addProjectPage.AddProjectButton().Click();
            logger.Info($"Added {projectName} project");
            return projectListPage;
        }

        [AllureStep("Delete a project by its name")]
        public ProjectListPage DeleteProject(string projectName)
        {
            projectListPage.GetDeleteButtonByProjectName(projectName).Click();
            confirmationPage.IsDeleteProjectCheckbox().Select();
            confirmationPage.OkButton().Click();
            logger.Info($"Deleted {projectName} project");
            return projectListPage;
        }

        [AllureStep("Add a project with a given project model")]
        public ProjectListPage AddProjectWithModel(ProjectModel projectModel)
        {
            new NavigationStep(driver).NavigateToProjectList();
            projectListPage.AddProjectButton().Click();

            addProjectPage.NameField().SendKeys(projectModel.Name);

            if (!string.IsNullOrEmpty(projectModel.Announcement))
            {
                addProjectPage.AnnouncementField().SendKeys(projectModel.Announcement);
            }

            if (projectModel.IsShowAnnouncement == true)
            {
                addProjectPage.IsShowAnnouncementCheckbox().Select();
            }

            if (projectModel.ProjectTypeByValue != null)
            {
                addProjectPage.ProjectTypeRadioButton().SelectByValue(projectModel.ProjectTypeByValue);
            }

            if (projectModel.IsEnableTestCase == true)
            {
                addProjectPage.IsEnableTestCaseCheckbox().Select();
            }
            addProjectPage.AddProjectButton().Click();
            logger.Info($"Added {projectModel.Name} project");
            return projectListPage;
        }
    }
}
