using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RM.Precificacao.Dominio.Entidades;
using RM.Precificacao.Dominio.Enumeradores;
using System.ComponentModel.DataAnnotations;

namespace RM.Precificacao.Web.ViewModel
{
    public class ServicoIncluirViewModel
    {
        [Required(ErrorMessage="O código é obrigatório.")]
        public int IdServico { get; set; }

        [Required(ErrorMessage="A descrição obrigatória.")]
        public string Descricao { get; set; }
        public int Empresa { get; set; }

        [Required(ErrorMessage = "A referência é obrigatória.")]
        public int ReferenciaServico { get; set; }
        public int TipoServico { get; set; }

        public Segmento Segmento { get; set; }
        public Servico ServicoRelacionado { get; set; }

        public IList<Segmento> TodosOsSegmentos { get; set; }
        public IList<ReferenciaServico> TodasAsReferencias { get; set; }
        public IList<Servico> TodosOsServicosRelacionados { get; set; }
    }
}