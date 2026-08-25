using OpenQA.Selenium;

namespace SeleniumCSharpDemo.Pages;

public class InventoryPage
{
    private readonly IWebDriver driver;

    public InventoryPage(IWebDriver driver)
    {
        this.driver = driver;
    }

    private IWebElement ProductsTitle =>
        driver.FindElement(By.ClassName("title"));

    private IWebElement BackpackAddToCartButton =>
        driver.FindElement(
            By.Id("add-to-cart-sauce-labs-backpack")
        );

    private IWebElement ShoppingCart =>
        driver.FindElement(
            By.ClassName("shopping_cart_link")
        );

    public bool IsProductsPageDisplayed()
    {
        return ProductsTitle.Displayed &&
               ProductsTitle.Text == "Products";
    }

    public void AddBackpackToCart()
    {
        BackpackAddToCartButton.Click();
    }

    public void OpenCart()
    {
        ShoppingCart.Click();
    }
}