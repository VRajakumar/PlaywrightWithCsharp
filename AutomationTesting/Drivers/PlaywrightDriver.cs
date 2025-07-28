using Microsoft.Playwright;
using System.Threading.Tasks;

namespace AutomationTesting.Drivers
{
    public class PlaywrightDriver
    {
        private readonly bool _isHeadless;
        private readonly string _browserType;
        private readonly Task<IBrowser> _browser;
        public IBrowser Browser => _browser.Result;

        public PlaywrightDriver(string browserType, bool isHeadless = false)
        {
            this._browserType = browserType;
            this._isHeadless = isHeadless;
            _browser = Task.Run(InitializePlaywright);
        }

        private async Task<IBrowser> InitializePlaywright()
        {
            var playwright = await Playwright.CreateAsync();
            IBrowser? taskIBrowser = null;

            switch (this._browserType)
            {
                case "chromium":
                    taskIBrowser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
                    {
                        Args = new[] { "--start-maximized" },
                        Headless = this._isHeadless
                    });
                    break;
                case "firefox":
                    taskIBrowser = await playwright.Firefox.LaunchAsync(new BrowserTypeLaunchOptions
                    {
                        Args = new[] { "--kiosk" },
                        Headless = this._isHeadless
                    });
                    break;
                case "webkit":
                    taskIBrowser = await playwright.Webkit.LaunchAsync(new BrowserTypeLaunchOptions
                    {
                        Headless = this._isHeadless
                    });
                    break;
            }
            return taskIBrowser!;
        }
    }
}
