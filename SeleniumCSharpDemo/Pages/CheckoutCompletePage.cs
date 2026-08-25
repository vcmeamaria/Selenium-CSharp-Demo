using OpenQA.Selenium;

namespace SeleniumCSharpDemo.Pages;

public class CheckoutCompletePage
{
    private readonly IWebDriver driver;

    public CheckoutCompletePage(IWebDriver driver)
    {
        this.driver = driver;
    }

    private IWebElement ConfirmationMessage =>
        driver.FindElement(
            By.ClassName("complete-header")
        );

    public bool IsOrderComplete()
    {
        return ConfirmationMessage.Displayed &&
               ConfirmationMessage.Text == "Thank you for your order!";
    }
}