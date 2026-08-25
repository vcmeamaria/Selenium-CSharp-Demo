using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumCSharpDemo.Tests;

public class ChromeOptionsTests
{
    private IWebDriver driver = null!;

    [SetUp]
    public void Setup()
    {
        ChromeOptions options = new ChromeOptions();

        options.AddArgument("--start-maximized");
        options.AddArgument("--disable-notifications");

        driver = new ChromeDriver(options);
    }

    [Test]
    public void ChromeOptions_OpenSauceDemo()
    {
        driver.Navigate().GoToUrl("https://www.saucedemo.com");

        Assert.That(
            driver.Title,
            Does.Contain("Swag Labs")
        );
    }

    [TearDown]
    public void TearDown()
    {
        driver?.Quit();
        driver?.Dispose();
    }
}