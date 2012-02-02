using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RM.Precificacao.Infra;
using RM.Precificacao.Dominio;
using RM.Precificacao.Dominio.Entidades;
using RM.Precificacao.Dominio.Servicos;
using RM.Precificacao.Dominio.Enumeradores;
using RM.Precificacao.Dominio.Excecoes;
using RM.Precificacao.Web.Extensions;
using RM.Precificacao.Web.ViewModel;
using RM.Precificacao.Web.ViewModel.Utils;
using RM.Precificacao.Web.ViewModel.Json;

namespace RM.Precificacao.Web.Controllers
{
    public class ServicoController : Controller
    {
        #region Propriedades

        private IDbContext Contexto { get; set; }
        private MapaOfertaServicos Servico { get; set; }

        #endregion

        #region Construtores

        public ServicoController()
        {
            Contexto = new RMPrecificacaoDbContext();
            Servico = new MapaOfertaServicos(Contexto);
        }

        public ServicoController(IDbContext contexto)
        {
            Contexto = contexto;
            Servico = new MapaOfertaServicos(contexto);
        }

        #endregion

        public ActionResult Index()
        {
            var viewModel = new ServicoIndexViewModel
            {
                Servicos = Contexto.Servicos.ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Index(ServicoIndexViewModel viewModel)
        {
            // Cria uma consulta dinâmica de acordo com os filtros
            IQueryable<Servico> consulta = Contexto.Servicos.AsQueryable<Servico>();

            if (viewModel.IdSegmento > 0)
                consulta = consulta.Where(s => s.Segmento.Id == viewModel.IdSegmento);

            // Repopula o viewModel e reenvia para a View
            viewModel.Servicos = consulta.ToList();

            return View(viewModel);
        }

        public ActionResult Incluir()
        {
            var viewModel = new ServicoIncluirViewModel
            {
                TodosOsSegmentos = Contexto.Segmentos.ToList(),
                TodasAsReferencias = Enum.GetValues(typeof(ReferenciaServico)).Cast<ReferenciaServico>(),
                TodosOsServicosRelacionados = Contexto.Servicos.ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Incluir(ServicoIncluirViewModel viewModel)
        {
            try
            {
                Servico novoServico = Conversor.ParaServico(viewModel);
                Servico.ValidarInclusao(novoServico);

                Contexto.Servicos.Add(novoServico);
                Contexto.SaveChanges();

                return View();
            }
            catch (RegrasDeNegocioException e)
            {
                e.CopiarPara(ModelState);
                return View(viewModel);
            }
        }

        [HttpGet]
        public ActionResult Alterar(int? id)
        {
            if (!id.HasValue)
            {
                throw new ArgumentNullException("Parâmetro id não pode ser nulo.");
            }

            Servico servicoEmAlteracao = Contexto.Servicos.SingleOrDefault(s => s.Id == id.Value);

            var viewModel = new ServicoAlterarViewModel
            {
                Id = servicoEmAlteracao.Id,
                Descricao = servicoEmAlteracao.Descricao,
                Empresa = servicoEmAlteracao.Empresa,
                ReferenciaServico = servicoEmAlteracao.ReferenciaServico,
                TipoServico = servicoEmAlteracao.TipoServico,
                ServicoRelacionado = servicoEmAlteracao.Pai,
                Segmento = servicoEmAlteracao.Segmento,
                TodosOsSegmentos = Contexto.Segmentos.ToList(),
                TodasAsReferencias = Enum.GetValues(typeof(ReferenciaServico)).Cast<ReferenciaServico>(),
                TodosOsServicosRelacionados = Contexto.Servicos.ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Alterar(ServicoAlterarViewModel viewModel)
        {
            try
            {
                Servico servicoAlterado = Conversor.ParaServico(viewModel);

                Servico.ValidarAlteracao(servicoAlterado);
                Servico.AlterarServico(servicoAlterado);

                Contexto.SaveChanges();

                return View();
            }
            catch (RegrasDeNegocioException e)
            {
                e.CopiarPara(ModelState);
                return View(viewModel);
            }
        }

        [HttpPost]
        public JsonResult ObterTodosOsServicos()
        {
            var servicos = Contexto.Servicos.ToList();

            return Json(new JsonViewModel 
            { 
                Sucesso = true,
                Dados = servicos
            });
        }
    }
}
