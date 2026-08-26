using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumCSharpDemo.Pages;

public class CartPage
{
    private readonly IWebDriver driver;
    private readonly WebDriverWait wait;

    public CartPage(IWebDriver driver)
    {
        this.driver = driver;

        wait = new WebDriverWait(
            driver,
            TimeSpan.FromSeconds(10)
        );
    }

    private IWebElement CartItemName =>
        wait.Until(d =>
            d.FindElement(
                By.ClassName("inventory_item_name")
            )
        );

    private IWebElement CheckoutButton =>
        wait.Until(d =>
        {
            IWebElement button =
                d.FindElement(By.Id("checkout"));

            return button.Displayed && button.Enabled
                ? button
                : null;
        })!;

    public bool IsBackpackDisplayed()
    {
        wait.Until(d =>
            d.Url.Contains("cart")
        );

        return CartItemName.Displayed &&
               CartItemName.Text == "Sauce Labs Backpack";
    }

    public void GoToCheckout()
    {
        wait.Until(d =>
            d.Url.Contains("cart")
        );

        CheckoutButton.Click();
    }
}