using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace SeleniumCSharpDemo.Tests;

public class MouseKeyboardActionsTests
{
    private IWebDriver driver = null!;

    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
    }

    [Test]
    public void MouseActions_CanClickDoubleClickAndRightClick()
    {
        string html = """
            <html>
                <body>
                    <h1>Mouse Actions Test</h1>

                    <button
                        id="click-button"
                        onclick="document.getElementById('click-result').innerText='Clicked'">
                        Click Me
                    </button>

                    <p id="click-result">Not clicked</p>

                    <button
                        id="double-button"
                        ondblclick="document.getElementById('double-result').innerText='Double Clicked'">
                        Double Click Me
                    </button>

                    <p id="double-result">Not double clicked</p>

                    <button
                        id="right-button"
                        oncontextmenu="
                            event.preventDefault();
                            document.getElementById('right-result').innerText='Right Clicked';
                        ">
                        Right Click Me
                    </button>

                    <p id="right-result">Not right clicked</p>
                </body>
            </html>
            """;

        driver.Navigate().GoToUrl(
            "data:text/html;charset=utf-8," +
            Uri.EscapeDataString(html)
        );

        Actions actions = new Actions(driver);

        // Move to the first button and click it.
        IWebElement clickButton =
            driver.FindElement(By.Id("click-button"));

        actions.MoveToElement(clickButton)
            .Click()
            .Perform();

        Assert.That(
            driver.FindElement(By.Id("click-result")).Text,
            Is.EqualTo("Clicked")
        );

        // Double-click the second button.
        IWebElement doubleButton =
            driver.FindElement(By.Id("double-button"));

        actions.DoubleClick(doubleButton)
            .Perform();

        Assert.That(
            driver.FindElement(By.Id("double-result")).Text,
            Is.EqualTo("Double Clicked")
        );

        // Right-click the third button.
        IWebElement rightButton =
            driver.FindElement(By.Id("right-button"));

        actions.ContextClick(rightButton)
            .Perform();

        Assert.That(
            driver.FindElement(By.Id("right-result")).Text,
            Is.EqualTo("Right Clicked")
        );
    }

    [TearDown]
    public void TearDown()
    {
        driver?.Quit();
        driver?.Dispose();
    }
}