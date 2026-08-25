# Selenium C# Demo

A Selenium WebDriver automation project built with **C#**, **NUnit**, **Visual Studio**, and **.NET**.

The project contains browser automation examples covering navigation, locators, waits, page interactions, cross-browser testing, screenshots, Page Object Model, data-driven testing, and a complete SauceDemo checkout flow.

## Technologies

* C#
* .NET
* Selenium WebDriver
* Selenium Support
* NUnit
* Google Chrome
* Microsoft Edge
* Mozilla Firefox
* Visual Studio

## How to Run

### Visual Studio

1. Open the solution in Visual Studio.
2. Go to **Test → Test Explorer**.
3. Select an individual test or test class.
4. Click **Run**.

To run all tests, use **Run All Tests** in Test Explorer.

### Command Line

From the repository root:

```bash
dotnet test SeleniumCSharpDemo/SeleniumCSharpDemo.csproj
```

This builds the project, discovers the NUnit tests, and runs the complete test suite.

> Chrome, Edge, and Firefox should be installed for the cross-browser tests.

## Tests

### Google Tests

| Test                         | Description                                                              |
| ---------------------------- | ------------------------------------------------------------------------ |
| `GoogleHomePage_IsDisplayed` | Opens Google and verifies the page title contains `Google`.              |
| `GoogleSearchTest`           | Searches Google for Selenium WebDriver C# and verifies the results page. |
| `NavigationTest`             | Tests browser navigation using GoToUrl, Back, Forward, and Refresh.      |
| `ElementActionsTest`         | Tests SendKeys, Clear, Click, Text, and GetAttribute.                    |
| `MultipleElementsTest`       | Finds multiple links on a page and loops through them.                   |
| `LoginTest`                  | Logs into SauceDemo and verifies the inventory page is displayed.        |
| `LoginWithWaitTest`          | Performs the SauceDemo login using an explicit wait.                     |

### SauceDemo Login

| Test                        | Description                                                                     |
| --------------------------- | ------------------------------------------------------------------------------- |
| `ValidUserCanLogin`         | Uses the Login Page Object and verifies a valid user reaches the Products page. |
| `InvalidLoginDisplaysError` | Verifies invalid credentials display an error message.                          |

### Data-Driven Tests

| Test                                 | Description                                      |
| ------------------------------------ | ------------------------------------------------ |
| `UserCanLogin("standard_user", ...)` | Verifies the standard SauceDemo user can log in. |
| `UserCanLogin("problem_user", ...)`  | Runs the same login test using the problem user. |

### Browser Configuration

| Test                                  | Description                                             |
| ------------------------------------- | ------------------------------------------------------- |
| `ChromeOptions_OpenSauceDemo`         | Starts Chrome using configured ChromeOptions.           |
| `GoogleHomePage_Headless_IsDisplayed` | Runs Chrome in headless mode and verifies Google loads. |

### Cross-Browser Tests

| Test                       | Description                                         |
| -------------------------- | --------------------------------------------------- |
| `SauceDemo_OpensInEdge`    | Opens and verifies SauceDemo using Microsoft Edge.  |
| `SauceDemo_OpensInFirefox` | Opens and verifies SauceDemo using Mozilla Firefox. |

### Driver Factory Tests

The same test runs with three browser values:

| Browser | Description                                                  |
| ------- | ------------------------------------------------------------ |
| Chrome  | Creates Chrome through `DriverFactory` and opens SauceDemo.  |
| Edge    | Creates Edge through `DriverFactory` and opens SauceDemo.    |
| Firefox | Creates Firefox through `DriverFactory` and opens SauceDemo. |

### Browser Interaction Tests

| Test                                            | Description                                                       |
| ----------------------------------------------- | ----------------------------------------------------------------- |
| `ProductSortDropdown_SelectPriceLowToHigh`      | Selects the SauceDemo price sorting option using `SelectElement`. |
| `RememberCheckbox_CanBeSelected`                | Checks a checkbox and verifies that it is selected.               |
| `JavaScriptAlert_CanBeAccepted`                 | Opens a JavaScript alert, reads the message, and accepts it.      |
| `IFrame_CanSwitchInAndOut`                      | Switches into an iframe and back to the main page.                |
| `MultipleWindows_CanSwitchBetweenTabs`          | Opens a new browser tab and switches between windows.             |
| `MouseActions_CanClickDoubleClickAndRightClick` | Tests click, double-click, and right-click mouse actions.         |

### Screenshots

| Test                         | Description                                                                  |
| ---------------------------- | ---------------------------------------------------------------------------- |
| `TakeScreenshot_OfSauceDemo` | Captures a screenshot of SauceDemo and saves it in the `Screenshots` folder. |

Generated screenshots are stored locally in:

```text
SeleniumCSharpDemo/Screenshots/
```

PNG screenshots are ignored by Git so generated test images are not uploaded to the repository.

### Base Test

| Test                           | Description                                                        |
| ------------------------------ | ------------------------------------------------------------------ |
| `SauceDemo_OpensUsingBaseTest` | Demonstrates inheriting browser setup and cleanup from `BaseTest`. |

### Hands-On Exercise

| Test                                       | Description                                                                                              |
| ------------------------------------------ | -------------------------------------------------------------------------------------------------------- |
| `AddProduct_ToBasket_ProductAppearsInCart` | Logs in, adds the Sauce Labs Backpack to the basket, opens the basket, and verifies the product appears. |

### Complete Checkout

| Test                                             | Description                                                                                   |
| ------------------------------------------------ | --------------------------------------------------------------------------------------------- |
| `CompleteCheckout_ValidDetails_OrderIsConfirmed` | Automates the complete SauceDemo checkout from login through to the final order confirmation. |

The complete checkout uses the Page Object Model:

```text
LoginPage
    ↓
InventoryPage
    ↓
CartPage
    ↓
CheckoutPage
    ↓
CheckoutOverviewPage
    ↓
CheckoutCompletePage
```

## Project Structure

```text
SeleniumCSharpDemo
│
├── Drivers
│   └── DriverFactory.cs
│
├── Pages
│   ├── LoginPage.cs
│   ├── InventoryPage.cs
│   ├── CartPage.cs
│   ├── CheckoutPage.cs
│   ├── CheckoutOverviewPage.cs
│   └── CheckoutCompletePage.cs
│
├── Tests
│   ├── BaseTest.cs
│   └── Selenium test classes
│
├── Utilities
│   └── ScreenshotHelper.cs
│
├── Screenshots
├── TestData
└── SeleniumCSharpDemo.csproj
```

## Test Status

**28 automated tests** covering Selenium browser automation, NUnit testing, cross-browser execution, Page Object Model, and SauceDemo end-to-end workflows.
