using OpenQA.Selenium;

namespace TMS_Selenium.Element
{
    public class Checkbox
    {
        private readonly UiElement _uiElement;

        public Checkbox(IWebDriver driver, By locator)
        {
            _uiElement = new UiElement(driver, locator);
        }
        public void Click() => _uiElement.Click();
        public bool Displayed => _uiElement.Displayed;
        public bool Enabled => _uiElement.Enabled;
    }
}
