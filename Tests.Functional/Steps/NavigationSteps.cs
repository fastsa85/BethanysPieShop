using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

using FunctionalTests.ObjectRepository.Widgets;

namespace FunctionalTests.Tests.Steps
{
    [Binding]
    public class NavigationSteps
    {
        private readonly IWebDriver webDriver;
        private readonly TestSettings testSettings;
        private readonly NavigationBar navigationBar;

        public NavigationSteps(IWebDriver webDriver, TestSettings testSettings, NavigationBar navigationBar)
        {
            this.webDriver = webDriver;
            this.testSettings = testSettings;
            this.navigationBar = navigationBar;
        }

        [When(@"User clicks Register link on the Navigation Bar")]
        public void WhenUserClicksRegisterButtonOnTheNavigationBar()
        {
            navigationBar.RegisterLink.Click();
        }

        [Then(@"User is redirected to the Home page")]
        public void ThenUserIsRedirectedToTheHomePage()
        {
            var expectedUrl = testSettings.WebDriverSettings.PageUrl;
            var actualUrl = webDriver.Url;
            
            Assert.AreEqual(expectedUrl, actualUrl, 
                $"User was not redirected to the Home page. Actual Url: {actualUrl}");
        }
    }
}
