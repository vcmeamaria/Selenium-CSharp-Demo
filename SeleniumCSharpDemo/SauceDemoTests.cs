using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumCSharpDemo;

public class SauceDemoTests
{
    private IWebDriver driver = null!;
    private WebDriverWait wait = null!;

    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        driver.Manage().Window.Maximize();

        wait = new WebDriverWait(
            driver,
            TimeSpan.FromSeconds(10)
        );
    }

    [Test]
    public void ValidUserCanLogin()
    {
        driver.Navigate().GoToUrl("https://www.saucedemo.com");

        IWebElement username =
            wait.Until(d =>
                d.FindElement(By.Id("user-name"))
            );

        username.SendKeys("standard_user");

        driver.FindElement(By.Id("password"))
            .SendKeys("secret_sauce");

        driver.FindElement(By.Id("login-button"))
            .Click();

        IWebElement title =
            wait.Until(d =>
                d.FindElement(By.ClassName("title"))
            );

        Assert.That(
            title.Text,
            Is.EqualTo("Products")
        );
    }

    [TearDown]
    public void TearDown()
    {
        driver?.Quit();
        driver?.Dispose();
    }
}