using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace SeleniumCSharpDemo.Tests;

public class CrossBrowserTests
{
    [Test]
    public void SauceDemo_OpensInEdge()
    {
        IWebDriver driver = new EdgeDriver();

        try
        {
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://www.saucedemo.com");

            Assert.That(
                driver.Title,
                Does.Contain("Swag Labs")
            );
        }
        finally
        {
            driver.Quit();
            driver.Dispose();
        }
    }

    [Test]
    public void SauceDemo_OpensInFirefox()
    {
        IWebDriver driver = new FirefoxDriver();

        try
        {
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://www.saucedemo.com");

            Assert.That(
                driver.Title,
                Does.Contain("Swag Labs")
            );
        }
        finally
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}