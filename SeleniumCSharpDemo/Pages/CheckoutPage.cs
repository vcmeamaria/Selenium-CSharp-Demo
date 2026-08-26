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
            TimeSpan.FromSeconds(15)
        );
    }

    private IWebElement FirstName =>
        wait.Until(d =>
        {
            var elements = d.FindElements(By.Id("first-name"));

            return elements.FirstOrDefault(
                element => element.Displayed && element.Enabled
            );
        })!;

    private IWebElement LastName =>
        wait.Until(d =>
        {
            var elements = d.FindElements(By.Id("last-name"));

            return elements.FirstOrDefault(
                element => element.Displayed && element.Enabled
            );
        })!;

    private IWebElement PostalCode =>
        wait.Until(d =>
        {
            var elements = d.FindElements(By.Id("postal-code"));

            return elements.FirstOrDefault(
                element => element.Displayed && element.Enabled
            );
        })!;

    private IWebElement ContinueButton =>
        wait.Until(d =>
        {
            var elements = d.FindElements(By.Id("continue"));

            return elements.FirstOrDefault(
                element => element.Displayed && element.Enabled
            );
        })!;

    public void EnterCustomerDetails(
        string firstName,
        string lastName,
        string postalCode)
    {
        FirstName.SendKeys(firstName);
        LastName.SendKeys(lastName);
        PostalCode.SendKeys(postalCode);
    }

    public void Continue()
    {
        ContinueButton.Click();
    }
}