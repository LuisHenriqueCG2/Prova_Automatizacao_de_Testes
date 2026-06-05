using OpenQA.Selenium;
namespace Teste2.Pages
{
    public class DashboardPage
    {
        private readonly IWebDriver _driver;

        public DashboardPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public bool UsuarioEstaLogado()
        {
            return _driver.Url.Contains("dashboard")
                   || !_driver.Url.Contains("login");
        }

        public string UrlAtual()
        {
            return _driver.Url;
        }
    }
}