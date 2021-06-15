using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace WeatherChecker.BDD.PageObjects
{
    public static class Condition
    {
        public static IWebElement WaitUntilVisible(this IWebDriver driver, By locator, int secondsTimeout = 3)
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, secondsTimeout));
            var element = wait.Until<IWebElement>(driver =>
            {
                try
                {
                    var targetElement = driver.FindElement(locator);
                    if (targetElement.Displayed)
                    {
                        return targetElement;
                    }
                    return null;
                }
                catch (StaleElementReferenceException)
                {
                    return null;
                }
                catch (NoSuchElementException)
                {
                    return null;
                }
                catch (ElementClickInterceptedException)
                {
                    return null;
                }
            });
            return element;
        }
    }
}