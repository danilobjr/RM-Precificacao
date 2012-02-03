using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RM.Precificacao.Dominio.Entidades;
using RM.Precificacao.Dominio.Enumeradores;

namespace RM.Precificacao.Web.ViewModel
{
    public class ServicoIndexViewModel
    {
        public int IdSegmento { get; set; }
        public string DescricaoServico { get; set; }
        public Empresa Empresa { get; set; }
        public TipoServico TipoServico { get; set; }

        public IList<Servico> Servicos { get; set; }
        public IList<Segmento> Segmentos { get; set; }

        public string Mensagem { get; set; }
    }
}