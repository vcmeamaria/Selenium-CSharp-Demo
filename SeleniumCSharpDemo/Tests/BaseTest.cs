using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumCSharpDemo.Tests;

public class BaseTest
{
    protected IWebDriver Driver = null!;

    [SetUp]
    public void BaseSetup()
    {
        Driver = new ChromeDriver();
        Driver.Manage().Window.Maximize();
    }

    [TearDown]
    public void BaseTearDown()
    {
        Driver?.Quit();
        Driver?.Dispose();
    }
}