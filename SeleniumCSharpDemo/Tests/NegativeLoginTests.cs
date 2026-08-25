using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumCSharpDemo.Pages;

namespace SeleniumCSharpDemo.Tests;

public class NegativeLoginTests : BaseTest
{
    [Test]
    public void InvalidLoginDisplaysError()
    {
        Driver.Navigate().GoToUrl(
            "https://www.saucedemo.com"
        );

        LoginPage loginPage =
            new LoginPage(Driver);

        loginPage.Login(
            "invalid_user",
            "invalid_password"
        );

        IWebElement error =
            Driver.FindElement(
                By.CssSelector("[data-test='error']")
            );

        Assert.That(
            error.Displayed,
            Is.True
        );
    }
}