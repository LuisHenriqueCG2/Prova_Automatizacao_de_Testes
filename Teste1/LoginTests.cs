using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Xunit;

namespace Testing
{
    public class LoginTests : IDisposable
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public LoginTests()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();

            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        [Fact]
        public void DeveRealizarLoginComSucesso()
        {
            //Aqui faz o login no BackOffice - Aplicação interna da Inside Sistemas
            string url = "https://backoffice.insidesistemas.com.br/login";
            string email = "luis.goncalves@insidesistemas.com.br";
            //Insira aqui sua senha
            string senha = "XXXX";

            _driver.Navigate().GoToUrl(url);

            _driver.FindElement(By.Name("userName")).SendKeys(email);
            _driver.FindElement(By.Name("password")).SendKeys(senha);

            _driver.FindElement(
                By.XPath("//button[contains(text(),'Acessar')]")
            ).Click();

            _wait.Until(driver => driver.Url.Contains("/home"));

            Assert.Contains("/home", _driver.Url);

            IWebElement mensagemBoasVindas = _wait.Until(
                driver =>
                {
                    var elemento = driver.FindElement(
                        By.XPath("//*[contains(text(),'Bem vindo ao BackOffice 🔥🔥')]"));

                    return elemento.Displayed ? elemento : null;
                });

            Assert.Contains("Bem vindo ao BackOffice 🔥🔥", mensagemBoasVindas.Text);
        }

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}