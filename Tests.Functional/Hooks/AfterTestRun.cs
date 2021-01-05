using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace FunctionalTests.Tests.Hooks
{
    [Binding]
    public static class AfterTestRun
    {
        [AfterTestRun]
        public static void TearDown(IWebDriver webDriver)
        {
            webDriver?.Quit();            
        }
    }
}
