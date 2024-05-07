using Allure.Net.Commons;
using Allure.NUnit.Attributes;
using NUnit.Framework.Constraints;
using OpenQA.Selenium;
using TMS_Selenium.Element;
using TMS_Selenium.Models;
using TMS_Selenium.Pages;
using TMS_Selenium.Pages.ProjectPages;
using TMS_Selenium.Test;
using TMS_Selenium.Utils;

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
