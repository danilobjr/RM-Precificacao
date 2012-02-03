using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RM.Precificacao.Dominio.Entidades;
using RM.Precificacao.Dominio.Enumeradores;

namespace Web.ViewModel
{
    public class ServicoConsultarServicosPopupViewModel
    {
        public int IdSegmento { get; set; }
        public string DescricaoServico { get; set; }
        public Empresa Empresa { get; set; }
        public TipoServico TipoServico { get; set; }

        public IList<ServicoGrid> Servicos { get; set; }
    }

    public class ServicoGrid
	{
        public int IdServico { get; set; }
        public string Empresa { get; set; }
        public string TipoServico { get; set; }
        public string DescricaoSegmento { get; set; }
        public string DescricaoServico { get; set; }
        public string ReferenciaServico { get; set; }
	}
}