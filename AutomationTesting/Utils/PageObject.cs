using Microsoft.Playwright;

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
}
