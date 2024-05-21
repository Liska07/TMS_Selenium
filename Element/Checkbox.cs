using OpenQA.Selenium;
using System;

namespace TMS_Selenium.Element
{
    public class Checkbox
    {
        private readonly UiElement _uiElement;

        public Checkbox(IWebDriver driver, By locator)
        {
            _uiElement = new UiElement(driver, locator);
        }

        public Checkbox(IWebDriver driver, IWebElement element)
        {
            _uiElement = new UiElement(driver, element);
        }
        public void Select() => _uiElement.Click();
        public bool Displayed => _uiElement.Displayed;
        public bool Enabled => _uiElement.Enabled;
        public bool IsChecked()
        {
            if (_uiElement.GetAttribute("checked") == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
