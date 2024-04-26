using OpenQA.Selenium;
using TMS_Selenium.Element;

namespace TMS_Selenium.Pages.ProjectPages
{
    public class ConfirmationPage : BasePage
    {
        private static readonly By _isDeleteProgectCheckboxBy = By.XPath("//*[@data-testid='caseFieldsTabDeleteDialogCheckbox']//input");
        private static readonly By _okButton = By.CssSelector("[data-testid='caseFieldsTabDeleteDialogButtonOk']");
        private string _endPoint = "";

        public ConfirmationPage(IWebDriver driver) : base(driver)
        {
        }
        public Checkbox IsDeleteProgectCheckbox() => new Checkbox(driver, _isDeleteProgectCheckboxBy);
        public Button OkButton() => new Button(driver, _okButton);
        public override string GetEndpoint()
        {
            return _endPoint;
        }

        protected override bool EvaluateLoadedStatus()
        {
            return OkButton().Displayed;
        }
    }
}
