using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Dominio.Entidades;
using IVIA.Comum.Fakes;

namespace Dominio.Tests.Fakes
{
    public class DominioContextFake : IDominioContext
    {
        public DominioContextFake()
        {
            this.Servicos = new FakeDbSet<Servico>();
            this.Segmentos = new FakeDbSet<Segmento>();
        }

        public IDbSet<Servico> Servicos { get; set; }
        public IDbSet<Segmento> Segmentos { get; set; }
        
        public int SaveChanges()
        {
            return 1;
        }
    }
}
