using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RM.Precificacao.Web.Extensions;
using RM.Precificacao.Dominio.Entidades;
using Web.ViewModel;
using RM.Precificacao.Dominio.Enumeradores;


namespace RM.Precificacao.Web.ViewModel.Utils
{
    public class Conversor
    {
        internal static Servico ParaServico(ServicoAlterarViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        internal static Servico ParaServico(ServicoIncluirViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        internal static Servico ParaServico(ServicoIndexViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        internal static IList<ServicoObterTodosOsServicosViewModel> ParaListaDeServicos(List<Servico> servicos)
        {
            var servicosViewModel = new List<ServicoObterTodosOsServicosViewModel>();

            foreach (var servico in servicos)
            {
                servicosViewModel.Add(new ServicoObterTodosOsServicosViewModel 
                { 
                    Id = servico.Id,
                    DescricaoServico = servico.Descricao,
                    DescricaoSegmento = servico.Segmento.Descricao,
                    Empresa = ((Empresa)servico.Empresa).GetStringValue(),
                    ReferenciaServico = ((ReferenciaServico)servico.ReferenciaServico).ToString(),
                    TipoServico = ((TipoServico)servico.TipoServico).GetStringValue()
                });
            }

            return servicosViewModel;
        }
    }
}