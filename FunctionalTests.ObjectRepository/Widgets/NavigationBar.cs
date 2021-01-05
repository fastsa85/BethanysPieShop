using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace FunctionalTests.ObjectRepository.Widgets
{
    public class NavigationBar
    {
        public NavigationBar(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "registerLink")]
        [CacheLookup]
        public IWebElement RegisterLink;
    }
}
