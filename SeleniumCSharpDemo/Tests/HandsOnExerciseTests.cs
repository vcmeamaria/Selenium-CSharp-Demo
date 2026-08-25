using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumCSharpDemo.Pages;

namespace SeleniumCSharpDemo.Tests;

public class HandsOnExerciseTests : BaseTest
{
    [Test]
    public void AddProduct_ToBasket_ProductAppearsInCart()
    {
        // Step 1: Navigate to SauceDemo.
        Driver.Navigate().GoToUrl(
            "https://www.saucedemo.com"
        );

        // Step 2: Log in.
        LoginPage loginPage =
            new LoginPage(Driver);

        loginPage.Login(
            "standard_user",
            "secret_sauce"
        );

        // Step 3: Verify that the Products page appears.
        WebDriverWait wait =
            new WebDriverWait(
                Driver,
                TimeSpan.FromSeconds(10)
            );

        IWebElement productsTitle =
            wait.Until(d =>
                d.FindElement(By.ClassName("title"))
            );

        Assert.That(
            productsTitle.Text,
            Is.EqualTo("Products")
        );

        // Step 4: Add a product to the basket.
        Driver.FindElement(
            By.Id("add-to-cart-sauce-labs-backpack")
        ).Click();

        // Step 5: Open the basket.
        Driver.FindElement(
            By.ClassName("shopping_cart_link")
        ).Click();

        // Step 6: Verify the selected product appears.
        IWebElement product =
            wait.Until(d =>
                d.FindElement(By.ClassName("inventory_item_name"))
            );

        Assert.That(
            product.Text,
            Is.EqualTo("Sauce Labs Backpack")
        );
    }
}