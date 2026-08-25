using OpenQA.Selenium;

namespace SeleniumCSharpDemo.Pages;

public class CheckoutOverviewPage
{
    private readonly IWebDriver driver;

    public CheckoutOverviewPage(IWebDriver driver)
    {
        this.driver = driver;
    }

    private IWebElement ProductName =>
        driver.FindElement(
            By.ClassName("inventory_item_name")
        );

    private IWebElement FinishButton =>
        driver.FindElement(
            By.Id("finish")
        );

    public bool IsBackpackDisplayed()
    {
        return ProductName.Displayed &&
               ProductName.Text == "Sauce Labs Backpack";
    }

    public void FinishOrder()
    {
        FinishButton.Click();
    }
}