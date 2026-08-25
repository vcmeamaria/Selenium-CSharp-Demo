using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumCSharpDemo.Tests;

public class WindowTests
{
    private IWebDriver driver = null!;

    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
    }

    [Test]
    public void MultipleWindows_CanSwitchBetweenTabs()
    {
        string html = """
            <html>
                <body>
                    <h1 id="main-heading">Main Window</h1>

                    <a
                        id="open-window"
                        href="https://www.example.com"
                        target="_blank">
                        Open New Window
                    </a>
                </body>
            </html>
            """;

        driver.Navigate().GoToUrl(
            "data:text/html;charset=utf-8," +
            Uri.EscapeDataString(html)
        );

        // Remember the original browser window.
        string originalWindow =
            driver.CurrentWindowHandle;

        // Open Example.com in a new tab/window.
        driver.FindElement(By.Id("open-window"))
            .Click();

        WebDriverWait wait =
            new WebDriverWait(
                driver,
                TimeSpan.FromSeconds(10)
            );

        // Wait until two browser windows exist.
        wait.Until(d =>
            d.WindowHandles.Count == 2
        );

        var windows = driver.WindowHandles;

        // Switch to the newly opened window.
        driver.SwitchTo()
            .Window(windows[1]);

        Assert.That(
            driver.Title,
            Does.Contain("Example Domain")
        );

        // Switch back to the original window.
        driver.SwitchTo()
            .Window(originalWindow);

        IWebElement mainHeading =
            driver.FindElement(
                By.Id("main-heading")
            );

        Assert.That(
            mainHeading.Text,
            Is.EqualTo("Main Window")
        );
    }

    [TearDown]
    public void TearDown()
    {
        driver?.Quit();
        driver?.Dispose();
    }
}