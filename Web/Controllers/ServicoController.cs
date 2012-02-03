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
using Web.ViewModel;

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
            var viewModel = new ServicoIndexViewModel();

            try
            {
                viewModel.Servicos = Contexto.Servicos.ToList();
                viewModel.Segmentos = Contexto.Segmentos.ToList();
            }
            catch (Exception)
            {
                viewModel.Mensagem = "Erro de conexão com a base de dados. Operação cancelada.";
            }

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Index(ServicoIndexViewModel viewModel)
        {
            try
            {
                viewModel.Servicos = Servico.ConsultarServico(viewModel.DescricaoServico, viewModel.IdSegmento,
                                                              viewModel.Empresa, viewModel.TipoServico);

                viewModel.Segmentos = Contexto.Segmentos.ToList();
            }
            catch (Exception)
            {
                viewModel.Mensagem = "Erro de conexão com a base de dados. Operação cancelada.";
            }

            return View(viewModel);
        }

        public ActionResult Incluir()
        {
            var viewModel = new ServicoIncluirViewModel
            {
                TodosOsSegmentos = Contexto.Segmentos.ToList(),
                TodasAsReferencias = Enum.GetValues(typeof(ReferenciaServico)).Cast<ReferenciaServico>().ToList(),
                TodosOsServicosRelacionados = Contexto.Servicos.ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Incluir(ServicoIncluirViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Servico novoServico = Conversor.ParaServico(viewModel);
                    Servico.ValidarInclusao(novoServico);

                    Contexto.Servicos.Add(novoServico);
                    Contexto.SaveChanges();

                    return View();
                }
            }
            catch (RegrasDeNegocioException e)
            {
                e.CopiarPara(ModelState);
            }

            viewModel.TodosOsSegmentos = Contexto.Segmentos.ToList();
            viewModel.TodosOsServicosRelacionados = Contexto.Servicos.ToList();

            return View(viewModel);
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
        public JsonResult ConsultarServicosPopup(ServicoConsultarServicosPopupViewModel viewModel)
        {
            var consulta = Servico.ConsultarServico(viewModel.DescricaoServico, viewModel.IdSegmento,
                                                    viewModel.Empresa, viewModel.TipoServico);

            viewModel.Servicos = Conversor.ParaListaDeServicosGrid(consulta);

            return Json(new JsonViewModel
            {
                Sucesso = true,
                Dados = viewModel
            });
        }

        [HttpPost]
        public JsonResult ObterTodosOsServicos()
        {
            var servicos = Conversor.ParaListaDeServicos(Contexto.Servicos.ToList());
            
            return Json(new JsonViewModel
            {
                Sucesso = true,
                Dados = servicos
            });
        }

        [HttpPost]
        public JsonResult ObterTodosOsSegmentos()
        {
            var segmentos = Conversor.ParaListaDeSegmentos(Contexto.Segmentos.ToList());

            return Json(new JsonViewModel
            {
                Sucesso = true,
                Dados = segmentos
            });
        }
    }
}