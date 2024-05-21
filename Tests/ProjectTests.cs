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
        [SetUp] 
        public void SetUp() 
        {
            userStep.SuccessfulLogin();
        }
        
        [Test]
        [AllureDescription("Verifying a project with name and type has been added")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureStory("Add a project")]
        public void AddProjectWithNameAndType()
        {
            string projectName = "EAntonova_" + Guid.NewGuid();

            ProjectListPage projectListPage = projectStep.AddProjectWithNameAndRadioButton(projectName, 1);
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

            ProjectListPage projectListPage = projectStep.AddProjectWithNameAndRadioButton(projectName, 0);
            navigationStep.NavigateToProjectList();
            projectStep.DeleteProject(projectName);

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

            ProjectListPage projectListPage = projectStep.AddProjectWithModel(projectInfo);
            navigationStep.NavigateToProjectList();

            Assert.That(projectListPage.IsProjectInList(projectName));
        }
    }
}


