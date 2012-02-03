using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RM.Precificacao.Dominio.Entidades
{
    public class Segmento
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public IList<Servico> Servicos { get; set; }
    }
}
