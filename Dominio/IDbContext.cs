using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using RM.Precificacao.Dominio.Entidades;

namespace RM.Precificacao.Dominio
{
    public interface IDbContext 
    {
        IDbSet<Servico> Servicos { get; set; }
        IDbSet<Segmento> Segmentos { get; set; }

        int SaveChanges();
    }
}
