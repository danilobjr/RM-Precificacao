using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RM.Precificacao.Dominio.Entidades;
using RM.Precificacao.Dominio.Enumeradores;

namespace RM.Precificacao.Web.ViewModel
{
    public class ServicoAlterarViewModel
    {
        public int Id { get; set; }

        public string Descricao { get; set; }
        public int Empresa { get; set; }
        public int ReferenciaServico { get; set; }
        public int TipoServico { get; set; }

        public Segmento Segmento { get; set; }
        public Servico ServicoRelacionado { get; set; }

        public IList<Segmento> TodosOsSegmentos { get; set; }
        public IEnumerable<ReferenciaServico> TodasAsReferencias { get; set; }
        public IList<Servico> TodosOsServicosRelacionados { get; set; }
    }
}