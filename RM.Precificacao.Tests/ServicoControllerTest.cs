using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Infra.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RM.Precificacao.App;
using RM.Precificacao.Dominio;
using RM.Precificacao.Dominio.Entidades;
using RM.Precificacao.Web.Controllers;
using RM.Precificacao.Web.ViewModel;

namespace RM.Precificacao.Tests
{
    
    
    /// <summary>
    ///This is a test class for ServicoControllerTest and is intended
    ///to contain all ServicoControllerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ServicoControllerTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        private ServicoController target = null;
        private IDbContext contexto = null;

        [TestInitialize()]
        public void TestInitialize()
        {
            contexto = new RMPrecificacaoFakeContext();
            target = new ServicoController(contexto);

            Program.PopularContexto(contexto);           
        }

        [TestMethod()]
        public void AlterarTest()
        {
           
            Nullable<int> id = new Nullable<int>(); // TODO: Initialize to an appropriate value
            ActionResult expected = null; // TODO: Initialize to an appropriate value
            ActionResult actual;
            actual = target.Alterar(id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        public void IncluirTest()
        {
            ServicoController target = new ServicoController(); // TODO: Initialize to an appropriate value
            ServicoIncluirViewModel viewModel = null; // TODO: Initialize to an appropriate value
            ActionResult expected = null; // TODO: Initialize to an appropriate value
            ActionResult actual;
            actual = target.Incluir(viewModel);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        public void TestaIndexFiltroSegmento()
        {
            ServicoIndexViewModel viewModel = new ServicoIndexViewModel();
            viewModel.IdSegmento = 1;
                                  
            ActionResult actionResult = target.Index(viewModel);
            ViewResult viewResult = (ViewResult) actionResult;
            ServicoIndexViewModel viewModelAtual = (ServicoIndexViewModel) viewResult.Model;

            Assert.AreNotEqual(0, viewModelAtual.Servicos.Count, "Não retornou nenhum serviço!");
            Assert.IsFalse(viewModelAtual.Servicos.Any(s => s.Segmento.Id != 1), "Retorno com segmentos diferente de 1!");
        }
    }
}
