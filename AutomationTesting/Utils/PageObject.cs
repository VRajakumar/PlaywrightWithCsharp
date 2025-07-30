using Microsoft.Playwright;
using NUnit.Framework;
using System.Threading.Tasks;

namespace AutomationTesting.Utils;

/*
Class acting as a wrapper for Playwright actions.
It encapsulates common actions performed on a Page object.
Each method represents a specific action such as clicking elements, waiting for elements,
verifying text, handling alerts, and interacting with elements on a web page.
*/
public class PageObject
{
    private readonly IPage _page;

    public PageObject(IPage page)
    {
        _page = page;
    }

    public async Task VerifyCurrentUrl(string expectedUrl)
    {
        await Assertions.Expect(_page).ToHaveURLAsync(expectedUrl);
    }

    public async Task EnterText(string elementLocator, string text)
    {
        await _page.Locator(elementLocator).FillAsync(text);
    }

    public async Task ClickElement(string elementLocator)
    {
        await _page.Locator(elementLocator).ClickAsync();
    }
    public async Task WaitForElementBeVisible(string elementLocator)
    {
        await _page.Locator(elementLocator).IsVisibleAsync();
    }

    public async Task ErrorMsg(string elementLocator)
    {
        var locator = _page.Locator(elementLocator);
        await Task.Delay(1000); 
        await Assertions.Expect(locator).ToHaveTextAsync("* User not found");

    }


}
