using OpenQA.Selenium;
using TMS_Selenium.Utils;

namespace TMS_Selenium.Core
{
    public class Browser
    {
        public IWebDriver Driver { get; set; }
        public Browser()
        {
            string browserName = Configurator.ReadConfiguration().BrowserType.ToLower();
            switch(browserName)
            {
                case "chrome":
                    Driver = new DriverFactory().GetChromeDriver();
                    break;
                default:
                    throw new NotImplementedException($"There is no implementation for {browserName}");
            }

            //Driver = Configurator.ReadConfiguration().BrowserType.ToLower() 
            //    switch
            //    {
            //        "chrome" => new DriverFactory().GetChromeDriver(),
            //        _ => throw new NotImplementedException($"There is no implementation for {browserName}")
            //    };

            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Configurator.ReadConfiguration().TimeOut);
            Driver.Manage().Window.Maximize();
        }

    }
}
