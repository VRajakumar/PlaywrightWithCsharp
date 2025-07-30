
using Microsoft.Playwright;
using TechTalk.SpecFlow;
using AutomationTesting.Utils;
using AutomationTesting.Pages;


namespace AutomationTesting.StepDefinitions
{

    [Binding]
    public class HomePageSteps
    {
       private readonly ScenarioContext _scenarioContext;
       private readonly IPage _page;
        private readonly HomePage _homePage;
       private readonly Config? _config;

        public HomePageSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _page = Hooks.Hooks.Page!;
            _homePage = new HomePage(_page);
            _config = Hooks.Hooks.Config!;
        }

        [Given(@"User is on the Pyramidcore Home Page")]
        public async Task GivenUserisonthePyramidcoreHomePage()
        {

            await _page.GotoAsync(_config!.Url!);
            await _homePage.VerifyCurrentUrl(_config.Url!);
        }
    }
}