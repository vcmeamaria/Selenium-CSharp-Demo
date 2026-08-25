using NUnit.Framework;
using SeleniumCSharpDemo.Pages;

namespace SeleniumCSharpDemo.Tests;

public class DataDrivenLoginTests : BaseTest
{
    [TestCase("standard_user", "secret_sauce")]
    [TestCase("problem_user", "secret_sauce")]
    public void UserCanLogin(
        string username,
        string password)
    {
        Driver.Navigate().GoToUrl(
            "https://www.saucedemo.com"
        );

        LoginPage loginPage =
            new LoginPage(Driver);

        loginPage.Login(
            username,
            password
        );

        Assert.That(
            Driver.Url,
            Does.Contain("inventory")
        );
    }
}