using OpenQA.Selenium;

namespace Teste2.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement CampoEmail =>
            _driver.FindElement(By.Name("userName"));

        private IWebElement CampoSenha =>
            _driver.FindElement(By.Name("password"));

        private IWebElement BotaoAcessar =>
            _driver.FindElement(
                By.XPath("//button[contains(text(),'Acessar')]"));

        public void AcessarTela()
        {
            _driver.Navigate()
                .GoToUrl("https://backoffice.insidesistemas.com.br/login");
        }

        public void RealizarLogin(string email, string senha)
        {
            CampoEmail.SendKeys(email);
            CampoSenha.SendKeys(senha);
            BotaoAcessar.Click();
        }
    }
}