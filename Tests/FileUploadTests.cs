using OpenQA.Selenium;
using System.Reflection;

namespace TMS_Selenium.Tests
{
    public class FileUploadTests : BaseTest
    {
        [Test]
        public void UploadFile()
        {
            string filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Resources", "LiskaTest.txt");

            driver.Navigate().GoToUrl("https://formy-project.herokuapp.com/fileupload");
            driver.FindElement(By.CssSelector("[type='file']")).SendKeys(filePath);
            driver.FindElement(By.XPath("//*[.='Reset']")).Click();
        }
    }
}
