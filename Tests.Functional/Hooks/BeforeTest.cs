using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace FunctionalTests.Tests.Hooks
{
    [Binding]
    public class BeforeTest
    {
        private IWebDriver webDriver;
        private TestSettings testSettings;
        public BeforeTest(IWebDriver webDriver, TestSettings testSettings)
        {
            this.webDriver = webDriver;
            this.testSettings = testSettings;
        }

        [BeforeScenario]
        public void NavigateToHomePage()
        {
            webDriver.Navigate().GoToUrl(testSettings.WebDriverSettings.PageUrl);
        }
    }
}
