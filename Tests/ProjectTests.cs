using Allure.Net.Commons;
using Allure.NUnit.Attributes;
using TMS_Selenium.Models;
using TMS_Selenium.Pages.ProjectPages;
using TMS_Selenium.Test;

namespace TMS_Selenium.Tests
{
    [AllureEpic("TestRail")]
    [AllureFeature("Basic Functionality")]
    public class ProjectTests : BaseTest
    {
        [Test]
        [AllureDescription("Verifying a project with name and type has been added")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureStory("Add a project")]
        public void AddProjectWithNameAndType()
        {
            string projectName = "EAntonova_" + Guid.NewGuid();

            userStep.SuccessfulLogin();
            logger.Info("Login successful");

            ProjectListPage projectListPage = userStep.AddProjectWithNameAndRadioButton(projectName, 1);
            logger.Info($"Added {projectName} project");

            navigationStep.NavigateToProjectList();

            Assert.That(projectListPage.IsProjectInList(projectName));
        }

        [Test]
        [AllureDescription("Verifying an added project has been deleted")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureStory("Delete a project")]
        public void DeleteAddedProject()
        {
            string projectName = "EAntonova_" + Guid.NewGuid();
            string expectedMessageText = "Successfully deleted the project.";

            userStep.SuccessfulLogin();
            logger.Info("Login successful");

            ProjectListPage projectListPage = userStep.AddProjectWithNameAndRadioButton(projectName, 0);
            logger.Info($"Added {projectName} project");

            navigationStep.NavigateToProjectList();

            userStep.DeleteProject(projectName);
            logger.Info($"Deleted {projectName} project");

            Assert.Multiple(() =>
            {
                Assert.That(projectListPage.GetMessage(), Is.EqualTo(expectedMessageText));
                Assert.That(!projectListPage.IsProjectInList(projectName));
            });
        }

        [Test]
        [AllureDescription("Verifying a project with model data has been added")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureStory("Add a project")]
        public void AddProjectWithModel()
        {
            string projectName = "EAntonova_" + Guid.NewGuid();
            ProjectModel projectInfo = new ProjectModel(projectName)
            {
                Announcement = "Test announcement",
                IsShowAnnouncement = true,
                ProjectTypeByValue = "2",
                IsEnableTestCase = true,
            };

            userStep.SuccessfulLogin();
            logger.Info("Login successful");

            ProjectListPage projectListPage = userStep.AddProjectWithModel(projectInfo);
            logger.Info($"Added {projectName} project");

            navigationStep.NavigateToProjectList();

            Assert.That(projectListPage.IsProjectInList(projectName));
        }
    }
}


