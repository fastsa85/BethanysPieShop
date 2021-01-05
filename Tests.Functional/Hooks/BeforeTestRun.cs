using Microsoft.Extensions.Configuration;
using BoDi;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace FunctionalTests.Tests.Hooks
{
    [Binding]
    public static class BeforeTestRun
    {
        [BeforeTestRun(Order = 0)]
        public static void AddConfiguration(IObjectContainer container)
        {
            var configuration = new ConfigurationBuilder()
                                .AddJsonFile("appsettings.json")
                                .AddJsonFile("appsettings.development.json", optional: true)
                                .AddEnvironmentVariables()
                                .Build();

            container.RegisterTestSettings(configuration);
        }

        [BeforeTestRun(Order = 1)]
        public static void RegisterDependencies(IObjectContainer container)
        {
            container.RegisterWebDriver();
        }

        [BeforeTestRun(Order = 2)]
        public static void SetupWebDriver(IWebDriver webDriver, TestSettings testSettings)
        {
            if (testSettings.WebDriverSettings.MaximiseWindow)
                webDriver.Manage().Window.Maximize();
        }
    }
}
