using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace RM.Precificacao.Dominio.Entidades
{
    public class Segmento
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public virtual IList<Servico> Servicos { get; set; }
    }
}
