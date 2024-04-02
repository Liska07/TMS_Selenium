using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace TMS_Selenium.Tests
{
    [TestFixture]
    public class Add_Delete_Elements : Basic
    {
        [Test]
        public void AddTwoElementsAndOneDelete_SingleDeleteButton()
        {
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/add_remove_elements/");

            var addElementButton = driver.FindElement(By.XPath("//button[text()='Add Element']"));
            addElementButton.Click();
            addElementButton.Click();

            var deleteButton = driver.FindElement(By.XPath("//button[text()='Delete']"));
            deleteButton.Click();

            var deleteButtonList = driver.FindElements(By.XPath("//button[text()='Delete']"));
            int expectedCount = 1;
            Assert.That(deleteButtonList.Count == expectedCount, $"The number of delete buttons is not as expected. Expected count = {expectedCount}, Actual count = {deleteButtonList.Count}");
        }
    }
}