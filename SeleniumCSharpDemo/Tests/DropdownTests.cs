using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumCSharpDemo.Tests;

public class DropdownTests
{
    private IWebDriver driver = null!;

    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
    }

    [Test]
    public void ProductSortDropdown_SelectPriceLowToHigh()
    {
        driver.Navigate().GoToUrl("https://www.saucedemo.com");

        driver.FindElement(By.Id("user-name"))
            .SendKeys("standard_user");

        driver.FindElement(By.Id("password"))
            .SendKeys("secret_sauce");

        driver.FindElement(By.Id("login-button"))
            .Click();

        IWebElement dropdown =
            driver.FindElement(
                By.ClassName("product_sort_container")
            );

        SelectElement select =
            new SelectElement(dropdown);

        select.SelectByText(
            "Price (low to high)"
        );

        // SauceDemo refreshes the product list after sorting,
        // so locate the dropdown again before checking it.
        IWebElement updatedDropdown =
            driver.FindElement(
                By.ClassName("product_sort_container")
            );

        SelectElement updatedSelect =
            new SelectElement(updatedDropdown);

        Assert.That(
            updatedSelect.SelectedOption.Text,
            Is.EqualTo("Price (low to high)")
        );
    }

    [TearDown]
    public void TearDown()
    {
        driver?.Quit();
        driver?.Dispose();
    }
}