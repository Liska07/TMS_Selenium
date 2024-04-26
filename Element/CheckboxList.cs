using NLog;
using OpenQA.Selenium;

namespace TMS_Selenium.Element
{
    public class CheckboxList
    {
        private readonly List<UiElement> _uiElements;
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public CheckboxList(IWebDriver driver, By locator)
        {
            _uiElements = new List<UiElement>();
            foreach (IWebElement element in driver.FindElements(locator))
            {
                UiElement uiElement = new UiElement(driver, element);
                _uiElements.Add(uiElement);
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
                _logger.Error($"Couldn't find checkbox with index: {index}!");
                throw new ArgumentOutOfRangeException($"Couldn't find checkbox with index: {index}!");
            }
        }

        /// <summary>
        /// Indexing starts from 0
        /// </summary>
        /// <param name="index"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public bool IsChecked(int index)
        {
            if (index < _uiElements.Count && index >= 0)
            {
                if (_uiElements[index].GetAttribute("checked") == null)
                {
                    return false;
                }
                else 
                { 
                    return true; 
                }
            }
            else
            {
                _logger.Error($"Couldn't find checkbox with index: {index}!");
                throw new ArgumentOutOfRangeException($"Couldn't find checkbox with index: {index}!");
            }
        }
    }
}
