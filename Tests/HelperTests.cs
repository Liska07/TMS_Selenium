using Allure.NUnit.Attributes;
using TMS_Selenium.Test;

namespace TMS_Selenium.Tests
{
    [AllureEpic("TestRail")]
    [AllureStory("Helper")]
    public class HelperTests : BaseTest
    {
        [Test]
        [NonParallelizable] //Runs after all tests
        [AllureDescription("Used to delete all my projects")]
        public void DeleteAllMyProjects()
        {
            string projectName = "EAntonova_";

            userStep.SuccessfulLogin();
            logger.Info("Login successful");

            int quantityMyProjects = navigationStep.NavigateToProjectList().GetProgectListByName(projectName).Count();
            logger.Info($"Need to delete {quantityMyProjects} my projects");

            for (int i = 0; i < quantityMyProjects; i++)
            {
                userStep.DeleteProject(projectName);
                logger.Info($"Deleted {projectName} project number {i + 1}");
            }
        }
    }
}
