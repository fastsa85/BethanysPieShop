using TechTalk.SpecFlow;
using FunctionalTests.ObjectRepository;
using FunctionalTests.ObjectRepository.Widgets;


namespace FunctionalTests.Tests.Steps
{
    [Binding]
    public class UserManagementSteps
    {        
        private readonly RegisterNewUserPage registerNewUserPage;

        public UserManagementSteps(NavigationBar navigationBar, RegisterNewUserPage registerNewUserPage)
        {            
            this.registerNewUserPage = registerNewUserPage;
        }

        [When(@"User enters ""(.*)"" into User Name input on the Register New User page")]
        public void WhenUserEntersIntoUserNameInputOnRegisterNewUserPage(string username)
        {
            registerNewUserPage.UserNameInput.SendKeys(username);
        }

        [When(@"User enters ""(.*)"" into Password input on the Register New User page")]
        public void WhenUserEntersIntoPasswordInputOnRegisterNewUserPage(string password)
        {
            registerNewUserPage.PasswordInput.SendKeys(password);
        }

        [When(@"User clicks Register button on the Register New User page")]
        public void WhenUserClicksRegisterButtonOnTheRegisterNewUserPage()
        {
            registerNewUserPage.RegisterButton.Click();
        }
    }
}
