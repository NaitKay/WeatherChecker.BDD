using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace WeatherChecker.BDD.PageObjects
{
    public abstract class PageObject
    {
        private readonly IWebDriver _driver;

        public PageObject(IWebDriver driver)
        {
            _driver = driver;
        }

        public void Navigate(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        public void AssertTitle(string title)
        {
            string pageTitle = _driver.Title;
            pageTitle.Should().Be(title);
        }

        public void AssertURL(string url)
        {
            _driver.Url.Should().Contain(url);
        }

    }
}