using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumCSharpDemo.Pages;

public class CheckoutPage
{
    private readonly IWebDriver driver;
    private readonly WebDriverWait wait;

    public CheckoutPage(IWebDriver driver)
    {
        this.driver = driver;

        wait = new WebDriverWait(
            driver,
            TimeSpan.FromSeconds(10)
        );
    }

    private IWebElement FirstName =>
        wait.Until(d =>
            d.FindElement(By.Id("first-name"))
        );

    private IWebElement LastName =>
        wait.Until(d =>
            d.FindElement(By.Id("last-name"))
        );

    private IWebElement PostalCode =>
        wait.Until(d =>
            d.FindElement(By.Id("postal-code"))
        );

    private IWebElement ContinueButton =>
        wait.Until(d =>
            d.FindElement(By.Id("continue"))
        );

    public void EnterCustomerDetails(
        string firstName,
        string lastName,
        string postalCode)
    {
        // Wait until the checkout information page has loaded.
        wait.Until(d =>
            d.Url.Contains("checkout-step-one")
        );

        FirstName.SendKeys(firstName);
        LastName.SendKeys(lastName);
        PostalCode.SendKeys(postalCode);
    }

    public void Continue()
    {
        ContinueButton.Click();
    }
}