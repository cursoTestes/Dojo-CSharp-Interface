using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestClass]
    public class TesteValidacoes
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;

        [TestInitialize]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost:58034";
            verificationErrors = new StringBuilder();
        }

        [TestCleanup]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [TestMethod]
        public void Retorna_Msgs_dos_campos_obrigatorios_quando_nao_informados()
        {
            Redirecionar_para_url_venda();

            Click_No_Botao_Add();

            string msgVendedor = driver.FindElement(By.Id("validacaoVendedor")).Text;
            Assert.AreEqual("O campo Id Vendedor é obrigatório.", msgVendedor);

            string msgDataVenda = driver.FindElement(By.Id("validacaoDataVenda")).Text;
            Assert.AreEqual("O campo Data Venda é obrigatório.", msgDataVenda);

            string msgValor = driver.FindElement(By.Id("validacaoValor")).Text;
            Assert.AreEqual("O campo Valor é obrigatório.", msgValor);
        }

        [TestMethod]
        public void Retorna_Msgs_do_campo_id_quando_nao_numerico()
        {
            Redirecionar_para_url_venda();


            driver.FindElement(By.Id("Vendedor")).SendKeys("teste");
            driver.FindElement(By.Id("DataVenda")).SendKeys("10/01/2011");
            driver.FindElement(By.Id("Valor")).SendKeys("10");

            Click_No_Botao_Add();

            string msgVendedor = driver.FindElement(By.Id("validacaoVendedor")).Text;
            Assert.AreEqual("O campo Id Vendedor deve ser numérico.", msgVendedor);

        }
        [TestMethod]
        public void Retorna_Msgs_do_campo_29FevNaoBissexto()
        {
            Redirecionar_para_url_venda();


            driver.FindElement(By.Id("Vendedor")).SendKeys("12");
            driver.FindElement(By.Id("DataVenda")).SendKeys("29/02/2011");
            driver.FindElement(By.Id("Valor")).SendKeys("10");

            Click_No_Botao_Add();

            string msgDataVenda = driver.FindElement(By.Id("validacaoDataVenda")).Text;
            Assert.AreEqual("Data Invalida", msgDataVenda);
        }


        [TestMethod]
        public void Retorna_para_home_quando_campos_obrigatorios_forem_informados()
        {
            Redirecionar_para_url_venda();

            driver.FindElement(By.Id("Vendedor")).SendKeys("teste");
            driver.FindElement(By.Id("DataVenda")).SendKeys("10/01/2011");
            driver.FindElement(By.Id("Valor")).SendKeys("10");

            Click_No_Botao_Add();

            Assert.AreEqual(baseURL+"/" , driver.Url);
            
        }

        private void Redirecionar_para_url_venda()
        {
            driver.Navigate().GoToUrl(baseURL + "/Venda/Add");
        }

        private void Click_No_Botao_Add()
        {            
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
            Thread.Sleep(1000);
        }

        

        
    }
}
