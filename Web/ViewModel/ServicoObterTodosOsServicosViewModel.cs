using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RM.Precificacao.Dominio.Enumeradores;

namespace Web.ViewModel
{
    public class ServicoObterTodosOsServicosViewModel
    {
        public int IdServico { get; set; }
        public string DescricaoServico { get; set; }
        public string Empresa { get; set; }
        public string TipoServico { get; set; }
        public string DescricaoSegmento { get; set; }
        public string ReferenciaServico { get; set; }
    }
}