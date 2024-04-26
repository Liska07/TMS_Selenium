using OpenQA.Selenium;
using System.Collections.ObjectModel;
using TMS_Selenium.Element;

namespace TMS_Selenium.Pages.ProjectPages
{
    public class ProjectListPage :BasePage
    {
        private static readonly By _messageBy = By.CssSelector("[data-testid='messageSuccessDivBox']");
        private static readonly By _addProgectButton = By.XPath("//a[contains(text(), 'Add Project')]");
        private string _endPoint = "index.php?/admin/projects/overview";
        public ProjectListPage(IWebDriver driver, bool openPageByUrl = false) : base(driver, openPageByUrl)
        {
        }
        public string GetMessage() => new UiElement(driver, _messageBy).Text.Trim();
        public Button AddProjectButton() => new Button(driver, _addProgectButton);
        public override string GetEndpoint()
        {
            return _endPoint;
        }

        protected override bool EvaluateLoadedStatus()
        {
            return AddProjectButton().Displayed;
        }

        public bool IsProjectInList(string projectName)
        {
            var projectList = driver.FindElements(By.XPath($"//a[contains(text(),'{projectName}')]"));
            if (projectList.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public ReadOnlyCollection<IWebElement> GetProgectListByName(string projectName)
        {
            var projectList = driver.FindElements(By.XPath($"//a[contains(text(),'{projectName}')]"));
            return projectList;
        }

        public Button GetDeleteButtonByProjectName(string projectName)
        {
            return new Button(driver, By.XPath($"//a[contains(text(),'{projectName}')]/ancestor::tr//div[@data-testid='projectDeleteButton']"));
        }
    }
}
