using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System.IO;

namespace WeatherChecker.BDD.Factories
{
    public class DriverFactory
    {
        public IWebDriver CreateDriver()
        {
            string browser = Environment.GetEnvironmentVariable("BROWSER");

            switch (browser.ToUpperInvariant())
            {
                case "CHROME":
                    return new ChromeDriver(Directory.GetCurrentDirectory());
                case "FIREFOX":
                    return new FirefoxDriver();
                case "IE":
                    return new InternetExplorerDriver();
                default:
                    throw new ArgumentException($"Browser not yet implemented or not found: '{browser}'");
            }
        }
    }
}