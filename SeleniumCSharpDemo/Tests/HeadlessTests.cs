using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumCSharpDemo.Tests;

public class HeadlessTests
{
    private IWebDriver driver = null!;

    [SetUp]
    public void Setup()
    {
        ChromeOptions options = new ChromeOptions();

        options.AddArgument("--headless");
        options.AddArgument("--window-size=1920,1080");

        driver = new ChromeDriver(options);
    }

    [Test]
    public void GoogleHomePage_Headless_IsDisplayed()
    {
        driver.Navigate().GoToUrl("https://www.google.com");

        Assert.That(
            driver.Title,
            Does.Contain("Google")
        );
    }

    [TearDown]
    public void TearDown()
    {
        driver?.Quit();
        driver?.Dispose();
    }
}