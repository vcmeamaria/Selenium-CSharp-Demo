using OpenQA.Selenium;

namespace SeleniumCSharpDemo.Utilities;

public static class ScreenshotHelper
{
    public static string TakeScreenshot(
        IWebDriver driver,
        string fileName)
    {
        ITakesScreenshot screenshotDriver =
            (ITakesScreenshot)driver;

        Screenshot screenshot =
            screenshotDriver.GetScreenshot();

        // Find the main project folder.
        string projectFolder = Path.GetFullPath(
            Path.Combine(
                AppContext.BaseDirectory,
                "..",
                "..",
                ".."
            )
        );

        // Create/use the Screenshots folder.
        string screenshotFolder = Path.Combine(
            projectFolder,
            "Screenshots"
        );

        Directory.CreateDirectory(screenshotFolder);

        // Split the supplied file name into name + extension.
        string baseName =
            Path.GetFileNameWithoutExtension(fileName);

        string extension =
            Path.GetExtension(fileName);

        // Automatically find the next available number.
        int screenshotNumber = 1;

        string filePath;

        do
        {
            filePath = Path.Combine(
                screenshotFolder,
                $"{baseName}_{screenshotNumber}{extension}"
            );

            screenshotNumber++;
        }
        while (File.Exists(filePath));

        screenshot.SaveAsFile(filePath);

        return filePath;
    }
}