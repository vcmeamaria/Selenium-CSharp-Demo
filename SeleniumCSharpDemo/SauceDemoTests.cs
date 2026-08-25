using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumCSharpDemo.Pages;

namespace SeleniumCSharpDemo;

public class SauceDemoTests
{
    private IWebDriver driver = null!;
    private WebDriverWait wait = null!;
    private LoginPage loginPage = null!;

    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        driver.Manage().Window.Maximize();

        wait = new WebDriverWait(
            driver,
            TimeSpan.FromSeconds(10)
        );

        loginPage = new LoginPage(driver);
    }

    [Test]
    public void ValidUserCanLogin()
    {
        driver.Navigate().GoToUrl("https://www.saucedemo.com");

        loginPage.Login(
            "standard_user",
            "secret_sauce"
        );

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