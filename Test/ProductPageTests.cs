using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace TMS_Selenium.Test
{
    [TestFixture]
    public class ProductPageTests : BaseTest
    {
        [Test]
        public void Logout()
        {
            IWebElement userNameField = driver.FindElement(By.CssSelector("[id^=user]"));
            IWebElement passwordField = driver.FindElement(By.CssSelector("[id$=word]"));
            IWebElement loginButton = driver.FindElement(By.CssSelector(".login-box .submit-button"));

            userNameField.SendKeys(userName);
            passwordField.SendKeys(password);
            loginButton.Click();

            IWebElement menuButton = driver.FindElement(By.XPath("//button[text()='Open Menu']"));
            menuButton.Click();

            IWebElement logoutLink = driver.FindElement(By.XPath("//a[contains(@data-test, 'logout')]"));
            logoutLink.Click();

            IWebElement loginTitle = driver.FindElement(By.CssSelector(".login_logo"));

            Assert.That(loginTitle.Displayed, "Login title is not displayed.");
        }

        [Test]
        public void ItemsCountAndSocialLinksEnabled()
        {
            int expectedItemsCount = 6;

            IWebElement userNameField = driver.FindElement(By.XPath("//input[@data-test='username']"));
            IWebElement passwordField = driver.FindElement(By.CssSelector("[id*='ssword']"));
            IWebElement loginButton = driver.FindElement(By.CssSelector("input.submit-button"));

            userNameField.SendKeys(userName);
            passwordField.SendKeys(password);
            loginButton.Click();

            ReadOnlyCollection<IWebElement> itemsList = driver.FindElements(By.XPath("//*[@data-test='inventory-list']/child::*"));
            
            int actualItemsCount = itemsList.Count();
            IWebElement twitterLink = driver.FindElement(By.LinkText("Twitter"));
            IWebElement facebookLink = driver.FindElement(By.PartialLinkText("aceboo"));
            IWebElement linkedinLink = driver.FindElement(By.XPath("//*[.='Facebook']/following-sibling::*"));

            Assert.Multiple(() =>
                {
                    Assert.That(actualItemsCount, Is.EqualTo(expectedItemsCount), $"Expected items count '{expectedItemsCount}', but got '{actualItemsCount}'.");
                    Assert.That(twitterLink.Enabled, "Twitter link is not enabled.");
                    Assert.That(facebookLink.Enabled, "Facebook link is not enabled.");
                    Assert.That(linkedinLink.Enabled, "LinkedIn link is not enabled.");
                }
            );
        }

        [Test]
        public void AddProduct_ChekQuantityInCartAndRemoveButton()
        {
            string expectedQuantitytInCart = "1";
            string expectedButtonText = "Remove";

            IWebElement userNameField = driver.FindElement(By.XPath("//*[@id='password']/preceding::input"));
            IWebElement passwordField = driver.FindElement(By.XPath("//input[contains(@class, 'input_error') and contains(@data-test, 'ssw')]"));
            IWebElement loginButton = driver.FindElement(By.XPath(" //*[@class='login_wrapper']//descendant::*[contains(@data-test, 'button')]"));

            userNameField.SendKeys(userName);
            passwordField.SendKeys(password);
            loginButton.Click();

            IWebElement addTShirtButton = driver.FindElement(By.XPath("//*[contains(text(), 'Labs Bolt T-Shirt')]/ancestor::*[contains(@class, 'description')]//button"));
            addTShirtButton.Click();

            string actualQuantityInCart = driver.FindElement(By.XPath("//*[contains(@data-test,'cart-badge')]")).Text;

            IWebElement removeTShirtButton = driver.FindElement(By.XPath("//*[contains(text(), 'Labs Bolt T-Shirt')]/ancestor::*[contains(@class, 'description')]//button"));
            string actualButtonText = removeTShirtButton.Text;

            Assert.Multiple(() =>
                {
                    Assert.That(actualQuantityInCart, Is.EqualTo(expectedQuantitytInCart), $"Expected quantity in cart '{expectedQuantitytInCart}', but got '{actualQuantityInCart}'.");
                    Assert.That(actualButtonText, Is.EqualTo(expectedButtonText), $"Expected the button text '{expectedButtonText}', but got '{actualButtonText}'.");
                    Assert.That(removeTShirtButton.Enabled, "Remove button is not enabled.");
                }
            );
        }
    }
}