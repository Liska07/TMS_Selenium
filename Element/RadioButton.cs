using NLog;
using OpenQA.Selenium;

namespace TMS_Selenium.Element
{
    public class RadioButton
    {
        private readonly List<UiElement> _uiElements;
        private readonly List<string> _values;
        private readonly List<string> _texts;
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public RadioButton(IWebDriver driver, By locator) 
        { 
            _uiElements = new List<UiElement>();
            _values = new List<string>();
            _texts = new List<string>();
            foreach(IWebElement element in driver.FindElements(locator)) 
            { 
                UiElement uiElement = new UiElement(driver, element);
                _uiElements.Add(uiElement);
                _values.Add(element.GetAttribute("value"));
                _texts.Add(element.FindElement(By.XPath("preceding-sibling::strong")).Text.Trim().ToLower());
            }
        }

        /// <summary>
        /// Indexing starts from 0
        /// </summary>
        /// <param name="index"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void SelectByIndex(int index)
        {
            if (index < _uiElements.Count && index >= 0) 
            {
                _uiElements[index].Click();
            }
            else 
            {
                _logger.Error($"Couldn't find radio button with index: {index}!");
                throw new ArgumentOutOfRangeException($"Couldn't find radio button with index: {index}!"); 
            }
        }

        public void SelectByValue(string value) 
        { 
            int index = _values.IndexOf(value);
            if (index == -1)
            {
                _logger.Error($"Couldn't find radio button with value: {value}!");
                throw new ArgumentOutOfRangeException($"Couldn't find radio button with value: {value}!");
            }
            else
            {
                _uiElements[index].Click();
            }
        }

        public void SelectByText(string text)
        {
            int index = _texts.IndexOf(text.Trim().ToLower());
            if (index == -1)
            {
                _logger.Error($"Couldn't find radio button with text: {text}!");
                throw new ArgumentOutOfRangeException($"Couldn't find radio button with text: {text}!");
            }
            else
            {
                _uiElements[index].Click();
            }
        }
    }
}
