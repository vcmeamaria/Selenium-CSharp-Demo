using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumCSharpDemo.Tests;

public class AlertTests
{
    private IWebDriver driver = null!;

    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
    }

    [Test]
    public void JavaScriptAlert_CanBeAccepted()
    {
        string html = """
            <html>
                <body>
                    <h1>Alert Test</h1>

                    <button
                        id="show-alert"
                        onclick="alert('Hello from Selenium!')">
                        Show Alert
                    </button>
                </body>
            </html>
            """;

        driver.Navigate().GoToUrl(
            "data:text/html;charset=utf-8," +
            Uri.EscapeDataString(html)
        );

        // Click the button that opens the alert.
        driver.FindElement(By.Id("show-alert"))
            .Click();

        // Switch Selenium from the webpage to the alert.
        IAlert alert =
            driver.SwitchTo().Alert();

        // Read the message shown inside the alert.
        string message = alert.Text;

        Assert.That(
            message,
            Is.EqualTo("Hello from Selenium!")
        );

        // Press OK.
        alert.Accept();
    }

    [TearDown]
    public void TearDown()
    {
        driver?.Quit();
        driver?.Dispose();
    }
}