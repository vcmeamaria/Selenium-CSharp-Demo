using NUnit.Framework;
using SeleniumCSharpDemo.Pages;

namespace SeleniumCSharpDemo.Tests;

public class CompleteCheckoutTests : BaseTest
{
    [Test]
    public void CompleteCheckout_ValidDetails_OrderIsConfirmed()
    {
        // Create the Page Objects.
        LoginPage loginPage =
            new LoginPage(Driver);

        InventoryPage inventoryPage =
            new InventoryPage(Driver);

        CartPage cartPage =
            new CartPage(Driver);

        CheckoutPage checkoutPage =
            new CheckoutPage(Driver);

        CheckoutOverviewPage checkoutOverviewPage =
            new CheckoutOverviewPage(Driver);

        CheckoutCompletePage checkoutCompletePage =
            new CheckoutCompletePage(Driver);

        // Step 1: Open SauceDemo.
        Driver.Navigate().GoToUrl(
            "https://www.saucedemo.com"
        );

        // Step 2: Login.
        loginPage.Login(
            "standard_user",
            "secret_sauce"
        );

        // Step 3: Verify the Products page.
        Assert.That(
            inventoryPage.IsProductsPageDisplayed(),
            Is.True
        );

        // Step 4: Add the Sauce Labs Backpack.
        inventoryPage.AddBackpackToCart();

        // Step 5: Open the cart.
        inventoryPage.OpenCart();

        // Step 6: Verify the backpack is in the cart.
        Assert.That(
            cartPage.IsBackpackDisplayed(),
            Is.True
        );

        // Step 7: Go to checkout.
        cartPage.GoToCheckout();

        // Step 8: Enter customer details.
        checkoutPage.EnterCustomerDetails(
            "Peter",
            "Parker",
            "CV21 1AA"
        );

        // Step 9: Continue to the checkout overview.
        checkoutPage.Continue();

        // Step 10: Verify the product is still correct.
        Assert.That(
            checkoutOverviewPage.IsBackpackDisplayed(),
            Is.True
        );

        // Step 11: Finish the order.
        checkoutOverviewPage.FinishOrder();

        // Step 12: Verify the confirmation page.
        Assert.That(
            checkoutCompletePage.IsOrderComplete(),
            Is.True
        );
    }
}