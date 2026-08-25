using OpenQA.Selenium;

namespace SeleniumCSharpDemo.Pages;

public class CartPage
{
    private readonly IWebDriver driver;

    public CartPage(IWebDriver driver)
    {
        this.driver = driver;
    }

    private IWebElement CartItemName =>
        driver.FindElement(
            By.ClassName("inventory_item_name")
        );

    private IWebElement CheckoutButton =>
        driver.FindElement(
            By.Id("checkout")
        );

    public bool IsBackpackDisplayed()
    {
        return CartItemName.Displayed &&
               CartItemName.Text == "Sauce Labs Backpack";
    }

    public void GoToCheckout()
    {
        CheckoutButton.Click();
    }
}