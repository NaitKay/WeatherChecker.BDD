using System;
using OpenQA.Selenium;
using System.Globalization;
using System.Collections.Generic;

namespace WeatherChecker.BDD.PageObjects
{
    public class SearchPostCodePage : PageObject
    {
        private readonly IWebDriver _driver;
        private readonly string appUrl;


        
        public SearchPostCodePage(IWebDriver driver) : base(driver)
        {
            appUrl = Environment.GetEnvironmentVariable("appUrl");
            _driver = driver;
        }

        private IWebElement postcodeText => _driver.WaitUntilVisible(By.CssSelector("#searchLocation>input"));
        private IWebElement searchButton => _driver.WaitUntilVisible(By.CssSelector("#searchLocation>button"));
        private IWebElement weatherDetailsTable => _driver.WaitUntilVisible(By.CssSelector("table>caption.tableHeader"));
        private IWebElement errorMessage => _driver.WaitUntilVisible(By.CssSelector("#root h1"));
        public IWebElement weatherTime => _driver.WaitUntilVisible(By.XPath("//th[text()='Time:']/../td"));
        public IWebElement weatherTemprature => _driver.WaitUntilVisible(By.XPath("//th[text()='Temperature:']/../td"));
        public IWebElement weatherHumidity => _driver.WaitUntilVisible(By.XPath("//th[text()='Humidity:']/../td"));
        
        private List<IWebElement> weatherTableProperties = new List<IWebElement>();
        
        

        public void SearchPostcode(string postcode)
        {
            postcodeText.SendKeys(postcode);
            searchButton.Click();
        }

        public void OpenApplication()
        {
            Navigate(appUrl);
        }

        public bool IsWeatherDetailsDisplayed()
        {
            return weatherDetailsTable.Displayed;
        }

        public bool CheckDateFormat(string date)
        {
            string[] formats = { "dd/MM/yyyy HH:mm:ss" };
            DateTime dateValue;
            return DateTime.TryParseExact(
                               date, formats,
                               CultureInfo.CurrentCulture,
                               DateTimeStyles.None,
                               out dateValue
                               );
                
        }

        public bool CheckWeatherTimeFormat()
        {
            return CheckDateFormat(weatherTime.Text);
           
        }

        public bool CheckTemprateureHumidityDisplayed()
        {
            return (weatherTemprature.Displayed && weatherHumidity.Displayed);
        }

        public bool CheckAllWeatherPropeties()
        {
            weatherTableProperties.AddRange(_driver.FindElements(By.XPath("//table//tr/td")));
            foreach(IWebElement weatherTableProperty in weatherTableProperties)
            {
                if (weatherTableProperty.Text == "") return false;
            }

            return true;
        }

        public string CheckErrorMessage()
        {
            return errorMessage.Text;
        }

       
    }
}