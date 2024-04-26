using OpenQA.Selenium;
using TMS_Selenium.Element;

namespace TMS_Selenium.Pages.ProjectPages
{
    public class AddProjectPage : BasePage
    {
        private static readonly By _nameFieldBy = By.Id("name");
        private static readonly By _announcementField = By.Name("announcement");
        private static readonly By _isShowAnnouncementCheckbox = By.Id("show_announcement");
        private static readonly By _projectTypeRadioButton = By.Name("suite_mode");
        private static readonly By _isEnableTestCaseCheckbox = By.Id("case_statuses_enabled");
        private static readonly By _addProjectButtonBy = By.Id("accept");
        private string _endPoint = "index.php?/admin/projects/add";

        public AddProjectPage(IWebDriver driver) : base(driver)
        {
        }

        public UiElement NameField() => new UiElement(driver, _nameFieldBy);
        public UiElement AnnouncementField() => new UiElement(driver, _announcementField);
        public Checkbox IsShowAnnouncementCheckbox() => new Checkbox(driver, _isShowAnnouncementCheckbox);
        public RadioButton ProjectTypeRadioButton() => new RadioButton(driver, _projectTypeRadioButton);
        public Checkbox IsEnableTestCaseCheckbox() => new Checkbox (driver, _isEnableTestCaseCheckbox);
        public Button AddProjectButton() => new Button(driver, _addProjectButtonBy);
        public override string GetEndpoint()
        {
            return _endPoint;
        }
        protected override bool EvaluateLoadedStatus()
        {
            return AddProjectButton().Displayed;
        }
    }
}
