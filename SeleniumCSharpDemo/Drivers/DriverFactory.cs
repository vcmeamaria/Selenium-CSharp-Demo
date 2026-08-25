using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace SeleniumCSharpDemo.Drivers;

public static class DriverFactory
{
    public static IWebDriver CreateDriver(string browser)
    {
        return browser.ToLower() switch
        {
            "chrome" => new ChromeDriver(),
            "edge" => new EdgeDriver(),
            "firefox" => new FirefoxDriver(),
            _ => throw new ArgumentException("Unsupported browser")
        };
    }
}