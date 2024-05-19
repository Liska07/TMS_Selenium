using Allure.NUnit.Attributes;
using TMS_Selenium.Test;

namespace TMS_Selenium.Tests
{
    [Category("TestRail")]
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

            int quantityMyProjects = navigationStep.NavigateToProjectList().GetProgectListByPartialName(projectName).Count();
            logger.Info($"Need to delete {quantityMyProjects} my projects");

            for (int i = 0; i < quantityMyProjects; i++)
            {
                projectStep.DeleteProject(projectName);
            }
        }
    }
}
//test
