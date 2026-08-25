using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumCSharpDemo.Utilities;

namespace SeleniumCSharpDemo.Tests;

public class ScreenshotTests
{
    private IWebDriver driver = null!;

    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
    }

    [Test]
    public void TakeScreenshot_OfSauceDemo()
    {
        driver.Navigate().GoToUrl(
            "https://www.saucedemo.com"
        );

        string screenshotPath =
            ScreenshotHelper.TakeScreenshot(
                driver,
                "saucedemo.png"
            );

        Assert.That(
            File.Exists(screenshotPath),
            Is.True
        );

        TestContext.Out.WriteLine(
            $"Screenshot saved to: {screenshotPath}"
        );
    }

    [TearDown]
    public void TearDown()
    {
        driver?.Quit();
        driver?.Dispose();
    }
}