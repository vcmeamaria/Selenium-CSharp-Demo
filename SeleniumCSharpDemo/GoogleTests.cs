using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumCSharpDemo;

public class GoogleTests
{
    private IWebDriver driver = null!;

    [SetUp]
    public void Setup()
    {
        ChromeOptions options = new ChromeOptions();

        driver = new ChromeDriver(options);

        driver.Manage().Window.Maximize();
    }

    [Test]
    public void GoogleHomePage_IsDisplayed()
    {
        driver.Navigate().GoToUrl("https://www.google.com");

        Assert.That(
            driver.Title,
            Does.Contain("Google"),
            "Expected Google page was not displayed."
        );
    }

    [Test]
    public void GoogleSearchTest()
    {
        driver.Navigate().GoToUrl("https://www.google.com");

        WebDriverWait wait =
            new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        // Google may display a cookie consent screen.
        var consentButtons = driver.FindElements(
            By.XPath("//button[contains(., 'Reject all') or contains(., 'Accept all')]")
        );

        foreach (IWebElement button in consentButtons)
        {
            if (button.Displayed && button.Enabled)
            {
                button.Click();
                break;
            }
        }

        IWebElement searchBox = wait.Until(d =>
        {
            foreach (IWebElement element in d.FindElements(By.Name("q")))
            {
                if (element.Displayed && element.Enabled)
                {
                    return element;
                }
            }

            return null;
        })!;

        searchBox.Click();
        searchBox.SendKeys("Selenium WebDriver C#");
        searchBox.SendKeys(Keys.Enter);

        wait.Until(d => d.Title.Contains("Selenium"));

        Assert.That(driver.Title, Does.Contain("Selenium"));
    }

    [Test]
    public void LoginTest()
    {
        driver.Navigate().GoToUrl("https://www.saucedemo.com");

        driver.FindElement(By.Id("user-name"))
            .SendKeys("standard_user");

        driver.FindElement(By.Id("password"))
            .SendKeys("secret_sauce");

        driver.FindElement(By.Id("login-button"))
            .Click();

        Assert.That(
            driver.Url,
            Does.Contain("inventory")
        );
    }

    [Test]
    public void NavigationTest()
    {
        // Go to the first website.
        driver.Navigate().GoToUrl("https://www.example.com");

        Assert.That(
            driver.Url,
            Does.Contain("example.com")
        );

        // Go to a second website.
        driver.Navigate().GoToUrl("https://www.saucedemo.com");

        Assert.That(
            driver.Url,
            Does.Contain("saucedemo.com")
        );

        // Go back to Example.
        driver.Navigate().Back();

        Assert.That(
            driver.Url,
            Does.Contain("example.com")
        );

        // Go forward to SauceDemo again.
        driver.Navigate().Forward();

        Assert.That(
            driver.Url,
            Does.Contain("saucedemo.com")
        );

        // Refresh the current page.
        driver.Navigate().Refresh();

        Assert.That(
            driver.Url,
            Does.Contain("saucedemo.com")
        );
    }

    [Test]
    public void ElementActionsTest()
    {
        driver.Navigate().GoToUrl("https://www.saucedemo.com");

        IWebElement username =
            driver.FindElement(By.Id("user-name"));

        // Type something into the username field.
        username.SendKeys("Hello");

        // Read the current value from the input.
        string firstValue =
            username.GetAttribute("value")!;

        Assert.That(
            firstValue,
            Is.EqualTo("Hello")
        );

        // Clear the field.
        username.Clear();

        // Type the real username.
        username.SendKeys("standard_user");

        // Read the updated value.
        string updatedValue =
            username.GetAttribute("value")!;

        Assert.That(
            updatedValue,
            Is.EqualTo("standard_user")
        );

        // Enter the password.
        driver.FindElement(By.Id("password"))
            .SendKeys("secret_sauce");

        // Click the login button.
        driver.FindElement(By.Id("login-button"))
            .Click();

        // Find the Products heading.
        IWebElement title =
            driver.FindElement(By.ClassName("title"));

        // Read its visible text.
        string titleText = title.Text;

        Assert.That(
            titleText,
            Is.EqualTo("Products")
        );
    }

    [Test]
    public void MultipleElementsTest()
    {
        driver.Navigate().GoToUrl("https://www.saucedemo.com");

        driver.FindElement(By.Id("user-name"))
            .SendKeys("standard_user");

        driver.FindElement(By.Id("password"))
            .SendKeys("secret_sauce");

        driver.FindElement(By.Id("login-button"))
            .Click();

        // Find all links on the Products page.
        var links = driver.FindElements(By.TagName("a"));

        // Loop through every link Selenium found.
        foreach (IWebElement link in links)
        {
            Console.WriteLine(link.Text);
        }

        // Confirm that at least one link was found.
        Assert.That(
            links.Count,
            Is.GreaterThan(0)
        );
    }

    [Test]
    public void LoginWithWaitTest()
    {
        driver.Navigate().GoToUrl("https://www.saucedemo.com");

        WebDriverWait wait =
            new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        IWebElement username =
            wait.Until(d => d.FindElement(By.Id("user-name")));

        username.SendKeys("standard_user");

        driver.FindElement(By.Id("password"))
            .SendKeys("secret_sauce");

        driver.FindElement(By.Id("login-button"))
            .Click();

        Assert.That(
            driver.Url,
            Does.Contain("inventory")
        );
    }

    [TearDown]
    public void TearDown()
    {
        driver?.Quit();
        driver?.Dispose();
    }
}