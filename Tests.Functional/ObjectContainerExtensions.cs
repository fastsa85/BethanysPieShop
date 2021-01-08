using Microsoft.Extensions.Configuration;
using BoDi;
using OpenQA.Selenium;
using System;

namespace FunctionalTests.Tests
{
    public static class ObjectContainerExtensions
    {
        public static IObjectContainer RegisterWebDriver(this IObjectContainer container)
        {
            var webDriver = WebDriverManager.InitializeDriver();
            container.RegisterInstanceAs<IWebDriver>(webDriver);            
            return container;
        }

        public static IObjectContainer RegisterTestSettings(this IObjectContainer container, IConfigurationRoot configuration)
        {
            var testSettings = new TestSettings();
            configuration.GetSection("TestSettings").Bind(testSettings);
            container.RegisterInstanceAs(testSettings);

            if (testSettings.WebDriverSettings.PageUrl == "")
                testSettings.WebDriverSettings.PageUrl = Environment.GetEnvironmentVariable("PageUrl");

            return container;
        }
    }
}
