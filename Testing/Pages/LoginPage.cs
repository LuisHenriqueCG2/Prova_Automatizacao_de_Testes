using OpenQA.Selenium;

namespace Testing.Base

{
    public class LoginPage
    {
        private readonly IWebDriver _driver;

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement Email =>
            _driver.FindElement(By.Id("email"));

        private IWebElement Senha =>
            _driver.FindElement(By.Id("senha"));

        private IWebElement BtnEntrar =>
            _driver.FindElement(By.Id("btnEntrar"));

        public void AcessarPagina()
        {
            _driver.Navigate().GoToUrl(
                "https://sistema.com/login");
        }

        public void PreencherEmail(string email)
        {
            Email.SendKeys(email);
        }

        public void PreencherSenha(string senha)
        {
            Senha.SendKeys(senha);
        }

        public void ClicarEntrar()
        {
            BtnEntrar.Click();
        }

        public void RealizarLogin(
            string email,
            string senha)
        {
            PreencherEmail(email);
            PreencherSenha(senha);
            ClicarEntrar();
        }
    }
}