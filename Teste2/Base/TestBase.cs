using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Teste2.Base
{
    public class TestBase : IDisposable
    {
        protected IWebDriver Driver;
        protected WebDriverWait Wait;

        public TestBase()
        {
            Driver = new ChromeDriver();

            Driver.Manage().Window.Maximize();

            Driver.Manage().Timeouts().ImplicitWait =
                TimeSpan.FromSeconds(5);

            Wait = new WebDriverWait(
                Driver,
                TimeSpan.FromSeconds(15));
        }

        public void Dispose()
        {
            Driver.Quit();
            Driver.Dispose();
        }
    }
}