using OpenQA.Selenium;

namespace TMS_Selenium.Element
{
    public class Message
    {
        private readonly UiElement _uiElement;
        public Message(IWebDriver driver, By locator)
        {
            _uiElement = new UiElement(driver, locator);
        }
        public bool Displayed => _uiElement.Displayed;
        public string Text => _uiElement.Text;
    }
}