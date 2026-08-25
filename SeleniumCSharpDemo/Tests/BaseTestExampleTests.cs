using NUnit.Framework;

namespace SeleniumCSharpDemo.Tests;

public class BaseTestExampleTests : BaseTest
{
    [Test]
    public void SauceDemo_OpensUsingBaseTest()
    {
        Driver.Navigate().GoToUrl(
            "https://www.saucedemo.com"
        );

        Assert.That(
            Driver.Title,
            Does.Contain("Swag Labs")
        );
    }
}