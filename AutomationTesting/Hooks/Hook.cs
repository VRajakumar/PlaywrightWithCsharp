using Allure.Commons;
using AutomationTesting.Drivers;
using AutomationTesting.Utils;
using Microsoft.Playwright;
using Newtonsoft.Json;
using TechTalk.SpecFlow;
using System.Text;

namespace AutomationTesting.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        private static IBrowser? _browser;
        private IBrowserContext? _context;
        public static IPage? Page;
        public static Config? Config;

        [BeforeTestRun]
        public static Task BeforeAll()
        {
            string projectRoot = Path.Combine(Directory.GetCurrentDirectory(), "../../../");
            string filePath = Path.Combine(projectRoot, "config.json");
            string jsonContent = File.ReadAllText(filePath);
            Config = JsonConvert.DeserializeObject<Config>(jsonContent)!;
            _browser = new PlaywrightDriver(Config.Browser!).Browser;
            return Task.CompletedTask;
        }

        [BeforeScenario]
        public async Task BeforeScenario()
        {
            if (_browser != null)
            {
                _context = await _browser.NewContextAsync(new BrowserNewContextOptions
                {
                    ViewportSize = ViewportSize.NoViewport
                });
                Page = await _context.NewPageAsync();
            }
            else
            {
                throw new NullReferenceException("The browser is not initialized.");
            }
        }

        [AfterScenario]
        public async Task AfterScenario(ScenarioContext context)
        {
            if (context.TestError != null)
            {
                byte[] screenshot = Array.Empty<byte>();
                if (Page != null)
                {
                    screenshot = await Page.ScreenshotAsync();
                }
                AllureLifecycle.Instance.AddAttachment($"Failed Scenario: {context.ScenarioInfo.Title}",
                    "application/png", screenshot);
            }
            if (Page != null)
            {
                await Page.CloseAsync();
            }
            else
            {
                throw new NullReferenceException("The page is not initialized.");
            }

            if (_context != null)
            {
                await _context.CloseAsync();
            }
            else
            {
                throw new NullReferenceException("The context is not initialized.");
            }
        }

        [AfterTestRun]
        public static async Task AfterAll()
        {
            if (_browser != null)
            {
                await _browser.CloseAsync();
            }
            else
            {
                throw new NullReferenceException("The browser is not initialized.");
            }
        }
    }
}