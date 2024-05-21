using NLog;
using OpenQA.Selenium;

namespace TMS_Selenium.Element
{
    public class CheckboxList
    {
        private readonly List<Checkbox> _checkboxes;
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public CheckboxList(IWebDriver driver, By locator)
        {
            _checkboxes = new List<Checkbox>();
            foreach (IWebElement element in driver.FindElements(locator))
            {
                Checkbox checkbox = new Checkbox(driver, element);
                _checkboxes.Add(checkbox);
            }
        }

        /// <summary>
        /// Indexing starts from 0
        /// </summary>
        /// <param name="index"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void SelectByIndex(int index)
        {
            if (index < _checkboxes.Count && index >= 0)
            {
                _checkboxes[index].Select();
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
        public bool IsCheckedByIndex(int index)
        {
            if (index < _checkboxes.Count && index >= 0)
            {
                return _checkboxes[index].IsChecked();
            }
            else
            {
                _logger.Error($"Couldn't find checkbox with index: {index}!");
                throw new ArgumentOutOfRangeException($"Couldn't find checkbox with index: {index}!");
            }
        }
    }
}
