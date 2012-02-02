using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace RM.Precificacao.Dominio.Entidades
{
    public class Servico
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public int Empresa { get; set; }
        public int ReferenciaServico { get; set; }
        public int TipoServico { get; set; }

        public virtual Servico Pai { get; set; }
        public virtual Segmento Segmento { get; set; }
        public virtual IList<Servico> Filhos { get; set; }
    }
}
