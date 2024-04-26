using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TMS_Selenium.Utils;

namespace TMS_Selenium.Pages
{
    public abstract class BasePage : LoadableComponent<BasePage>
    {
        protected IWebDriver driver;
        protected BasePage(IWebDriver driver, bool openPageByUrl = false)
        {
            this.driver = driver;
            if (openPageByUrl)
            {
                ExecuteLoad();
                Load();
            }
        }

        public abstract string GetEndpoint();

        protected override void ExecuteLoad()
        {
            driver.Navigate().GoToUrl(Configurator.ReadConfiguration().TestRailURL + GetEndpoint());
        }
    }
}