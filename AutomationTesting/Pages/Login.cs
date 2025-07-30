
using Microsoft.Playwright;
using AutomationTesting.Utils;
using NUnit.Framework;

namespace AutomationTesting.Pages
{


    public class Login : PageObject
    {
        public Login(IPage page) : base(page)
        {
        }
        private readonly string loginUsernameInputLocator = "#pydLogin_txtUserid";
        private readonly string loginPasswordInputLocator = "#pydLogin_txtUserPwd";
        private readonly string LoginButtonLocator = "//input[@id='pydLogin_btnLogin']";
        private readonly string DashboardLocator = "//a[@id='PCIMenut0']";
        private readonly string ErrorMessageLocator = "//span[contains(text(), '* User not found')]";

        public async Task EnterLoginUsername(string text)
        {
            await EnterText(this.loginUsernameInputLocator, text);
        }

        public async Task EnterLoginPassword(string text)
        {
            await EnterText(this.loginPasswordInputLocator, text);
        }

        public async Task ClickonLoginButton()
        {
            await ClickElement(this.LoginButtonLocator);
        }

        public async Task VerifyDashboardPageIsVisible()
        {
            await WaitForElementBeVisible(DashboardLocator);
        }
        
         public async Task VerifyErrorMsg()
        {
            await ErrorMsg(ErrorMessageLocator);
        }
    }
}