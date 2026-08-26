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
        ChromeOptions options = new ChromeOptions();

        // Disable Chrome Password Manager prompts.
        options.AddUserProfilePreference(
            "credentials_enable_service",
            false
        );

        options.AddUserProfilePreference(
            "profile.password_manager_enabled",
            false
        );

        options.AddUserProfilePreference(
            "profile.password_manager_leak_detection",
            false
        );

        // Extra protection against password leak warnings.
        options.AddArgument(
            "--disable-features=PasswordLeakDetection,PasswordManagerLeakDetection"
        );

        Driver = new ChromeDriver(options);

        Driver.Manage().Window.Maximize();
    }

    [TearDown]
    public void BaseTearDown()
    {
        Driver?.Quit();
        Driver?.Dispose();
    }
}