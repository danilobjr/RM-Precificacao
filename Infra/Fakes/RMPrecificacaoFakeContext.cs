using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using RM.Precificacao.Dominio;
using RM.Precificacao.Infra.Fakes;
using RM.Precificacao.Dominio.Entidades;

namespace Infra.Fakes
{
    public class RMPrecificacaoFakeContext : IDbContext
    {
        public RMPrecificacaoFakeContext()
        {
            Servicos = new FakeDbSet<Servico>();
            Segmentos = new FakeDbSet<Segmento>();
        }

        public IDbSet<Servico> Servicos { get; set; }
        public IDbSet<Segmento> Segmentos { get; set; }

        public int SaveChanges()
        {
            return 1;
        }
    }
}
