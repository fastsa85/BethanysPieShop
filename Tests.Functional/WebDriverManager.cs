using System.IO;
using System.Reflection;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace FunctionalTests.Tests
{
    public class WebDriverManager
    {        
        public static IWebDriver InitializeDriver()
        {
            return new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        }
    }
}
