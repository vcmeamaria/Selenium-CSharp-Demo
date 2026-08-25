using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumCSharpDemo.Tests;

public class FrameTests
{
    private IWebDriver driver = null!;

    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
    }

    [Test]
    public void IFrame_CanSwitchInAndOut()
    {
        string html = """
            <html>
                <body>
                    <h1 id="main-heading">Main Page</h1>

                    <iframe
                        id="test-frame"
                        name="test-frame"
                        srcdoc="
                            <html>
                                <body>
                                    <h2 id='frame-heading'>
                                        Inside the Frame
                                    </h2>
                                </body>
                            </html>
                        ">
                    </iframe>
                </body>
            </html>
            """;

        driver.Navigate().GoToUrl(
            "data:text/html;charset=utf-8," +
            Uri.EscapeDataString(html)
        );

        // Switch from the main page into the iframe.
        driver.SwitchTo().Frame("test-frame");

        IWebElement frameHeading =
            driver.FindElement(By.Id("frame-heading"));

        Assert.That(
            frameHeading.Text,
            Is.EqualTo("Inside the Frame")
        );

        // Switch back to the main webpage.
        driver.SwitchTo().DefaultContent();

        IWebElement mainHeading =
            driver.FindElement(By.Id("main-heading"));

        Assert.That(
            mainHeading.Text,
            Is.EqualTo("Main Page")
        );
    }

    [TearDown]
    public void TearDown()
    {
        driver?.Quit();
        driver?.Dispose();
    }
}