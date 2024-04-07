using OpenQA.Selenium;

namespace TMS_Selenium.Tests
{
    [TestFixture]
    public class Inputs : BaseTest
    {
        private IWebElement inputField;

        [SetUp]
        public void SetUp()
        {
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/inputs");
            inputField = driver.FindElement(By.TagName("input"));
        }

        [Test]
        public void InputPositiveNumberArrowDown_ReturnPreviousNumber()
        {
            string number = "123";
            inputField.SendKeys(number);
            inputField.SendKeys(Keys.ArrowDown);
            var value = inputField.GetAttribute("value");
            string expectedValue = "122";
            Assert.That(value, Is.EqualTo(expectedValue), $"Expected the previous number '{expectedValue}' when pressing Arrow Down, but got '{value}'.");
        }

        [Test]
        public void InputNegativeNumberArrowUp_ReturnNextNumber()
        {
            string number = "-123";
            inputField.SendKeys(number);
            inputField.SendKeys(Keys.ArrowUp);
            var value = inputField.GetAttribute("value");
            string expectedValue = "-122";
            Assert.That(value, Is.EqualTo(expectedValue), $"Expected the next number '{expectedValue}' when pressing Arrow Up, but got '{value}'.");
        }

        [Test]
        public void InputText_ReturnEmptySrting()
        {
            string text = "Liska";
            inputField.SendKeys(text);
            var value = inputField.GetAttribute("value");
            string expectedValue = "";
            Assert.That(value, Is.EqualTo(expectedValue), $"Expected an empty string after input, but got '{value}'.");
        }

        [Test]
        public void InputFractionalNumberArrowUp_ReturnNextIntegerNumber()
        {
            string fractionalNumber = "1.23";
            inputField.SendKeys(fractionalNumber);
            inputField.SendKeys(Keys.ArrowUp);
            var value = inputField.GetAttribute("value");
            string expectedValue = "2";
            Assert.That(value, Is.EqualTo(expectedValue), $"Expected the next integer number '{expectedValue}' when pressing Arrow Up after inputting '{fractionalNumber}', but got '{value}'.");
        }

        [Test]
        public void InputNumberTextArrowDownArrowUp_ReturnEnteredNumber()
        {
            string number = "10";
            inputField.SendKeys(number);
            string text = "Liska";
            inputField.SendKeys(text);
            inputField.SendKeys(Keys.ArrowDown);
            inputField.SendKeys(Keys.ArrowUp);
            var value = inputField.GetAttribute("value");
            Assert.That(value, Is.EqualTo(number), $"Expected the entered number '{number}' after pressing Arrow Down and Arrow Up, but got '{value}'.");
        }
    }
}
