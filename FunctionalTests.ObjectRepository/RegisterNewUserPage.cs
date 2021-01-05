using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace FunctionalTests.ObjectRepository
{
    public class RegisterNewUserPage
    {
        public RegisterNewUserPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "UserName")]        
        public IWebElement UserNameInput;

        [FindsBy(How = How.Id, Using = "Password")]
        public IWebElement PasswordInput;

        [FindsBy(How = How.CssSelector, Using = "input.btn-primary")]
        public IWebElement RegisterButton;
    }
}
