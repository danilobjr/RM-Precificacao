using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RM.Precificacao.Dominio.Entidades;

namespace RM.Precificacao.Web.ViewModel
{
    public class ServicoIndexViewModel
    {
        public IList<Servico> Servicos { get; set; }
        public int IdSegmento { get; set; }

        public ServicoIndexViewModel()
        {
            Servicos = new List<Servico>();
        }
    }
}