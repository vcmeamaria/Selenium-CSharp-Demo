using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumCSharpDemo.Drivers;

namespace SeleniumCSharpDemo.Tests;

public class DriverFactoryTests
{
    private IWebDriver driver = null!;

    [TearDown]
    public void TearDown()
    {
        driver?.Quit();
        driver?.Dispose();
    }

    [TestCase("chrome")]
    [TestCase("edge")]
    [TestCase("firefox")]
    public void DriverFactory_OpensSauceDemo(string browser)
    {
        driver = DriverFactory.CreateDriver(browser);

        driver.Manage().Window.Maximize();

        driver.Navigate().GoToUrl("https://www.saucedemo.com");

        Assert.That(
            driver.Title,
            Does.Contain("Swag Labs")
        );
    }
}