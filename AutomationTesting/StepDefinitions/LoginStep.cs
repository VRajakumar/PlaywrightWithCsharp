using Microsoft.Playwright;
using TechTalk.SpecFlow;
using AutomationTesting.Pages;
using AutomationTesting.Utils;
using AutomationTesting.Hooks;
using System.Text;


namespace AutomationTesting.StepDefinitions
{
    [Binding]
    public class LoginSteps
    {
        private readonly IPage _page;
        private readonly Login _login;
         private readonly ScenarioContext _scenarioContext;
        private string _username = string.Empty;
        private string _password = string.Empty;

         public LoginSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _page = Hooks.Hooks.Page!;
            _login = new Login(_page);
        }

        [When(@"User enters username and password with valid credentials")]
        public async Task WhenUserentersvalidcredentials()
        {
           var username = Hooks.Hooks.Config?.Credentials?.Username;
           var password = Hooks.Hooks.Config?.Credentials?.Password;

           if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
           {
             throw new Exception("Username or Password is missing from config.");
           }

           await _login.EnterLoginUsername(username);
            await _login.EnterLoginPassword(password);
        }

        [When(@"User enters ""(.*)"", ""(.*)"" invalid credentials")]
        public async Task WhenUserenters(string username, string password)
        {
            _username = username;
            _password = password;


            await _login.EnterLoginUsername(_username); 
            await _login.EnterLoginPassword(_password);
        }

        [When(@"User enters username and password with invalid credentials")]
        public async Task WhenUserentersinvalidcredentials()
        {
            var username = Hooks.Hooks.Config?.Credentials?.Username;
           var password = Hooks.Hooks.Config?.Credentials?.Password;

           if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
           {
             throw new Exception("Username or Password is missing from config.");
           }

           await _login.EnterLoginUsername(username);
            await _login.EnterLoginPassword(password);
        }

        [Then(@"User click on the Login button")]
        public async Task ThenUserclickontheLoginbutton()
        {
            await _login.ClickonLoginButton();
        }

        [Then(@"User should navigate to Dashboard")]
        public async Task ThenUserShouldNavigateToDashboard()
        {
            await _login.VerifyDashboardPageIsVisible();
        }
        
        [Then(@"User should see an error message indicating invalid credentials")]
        public async Task ThenUUsershouldseeanerrormessageindicatinginvalidcredentials()
        {
            await _login.VerifyErrorMsg();
        }

    }
}
