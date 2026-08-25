using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumCSharpDemo.Tests;

public class CheckboxTests
{
    private IWebDriver driver = null!;

    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
    }

    [Test]
    public void RememberCheckbox_CanBeSelected()
    {
        string html = """
            <html>
                <body>
                    <h1>Checkbox Test</h1>

                    <label>
                        <input
                            type="checkbox"
                            id="remember">

                        Remember me
                    </label>
                </body>
            </html>
            """;

        driver.Navigate().GoToUrl(
            "data:text/html;charset=utf-8," +
            Uri.EscapeDataString(html)
        );

        IWebElement checkbox =
            driver.FindElement(By.Id("remember"));

        if (!checkbox.Selected)
        {
            checkbox.Click();
        }

        Assert.That(
            checkbox.Selected,
            Is.True
        );
    }

    [TearDown]
    public void TearDown()
    {
        driver?.Quit();
        driver?.Dispose();
    }
}