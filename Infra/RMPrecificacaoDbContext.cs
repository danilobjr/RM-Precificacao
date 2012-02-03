using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using RM.Precificacao.Dominio;
using RM.Precificacao.Dominio.Entidades;
using RM.Precificacao.Infra.Mapeamentos;


namespace RM.Precificacao.Infra
{
    public class RMPrecificacaoDbContext : DbContext, IDbContext
    {
        public RMPrecificacaoDbContext()
            : base("RM_PRECIFICACAO")
        {

        }

        public IDbSet<Servico> Servicos { get; set; }
        public IDbSet<Segmento> Segmentos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ServicoConfiguration());
            modelBuilder.Configurations.Add(new SegmentoConfiguration());
        }
    }
}
