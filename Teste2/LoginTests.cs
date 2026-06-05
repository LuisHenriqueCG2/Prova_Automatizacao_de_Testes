using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Teste2.Pages;
using Xunit;

namespace Teste2
{
    public class LoginTests : IDisposable
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public LoginTests()
        {
            _driver = new ChromeDriver();

            _wait = new WebDriverWait(
                _driver,
                TimeSpan.FromSeconds(20));
        }

        [Fact]
        public void DeveRealizarLoginComSucesso()
        {
            // Arrange
            var loginPage = new LoginPage(_driver);
            var dashboardPage = new DashboardPage(_driver);

            // Act
            loginPage.AcessarTela();

            loginPage.RealizarLogin(
                "luis.goncalves@insidesistemas.com.br",
                //Insira aqui sua senha
                "XXXX");

            // Assert
            _wait.Until(driver =>
                !driver.Url.Contains("login"));

            Assert.True(
                dashboardPage.UsuarioEstaLogado());
        }

        public void Dispose()
        {
            _driver.Quit();
        }
    }
}