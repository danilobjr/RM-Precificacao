using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using RM.Precificacao.Dominio.Entidades;

namespace RM.Precificacao.Infra.Mapeamentos
{
    class ServicoConfiguration : EntityTypeConfiguration<Servico>
    {
        public ServicoConfiguration()
        {
            ToTable("tbServico");

            HasKey(s => s.Id);

            Property(u => u.Id).HasColumnName("isnServico").IsRequired();
            Property(u => u.Descricao).HasColumnName("dscServico").HasMaxLength(100).IsRequired();
            Property(u => u.Empresa).HasColumnName("codEmpresa").IsRequired();
            Property(u => u.ReferenciaServico).HasColumnName("codReferencia").IsRequired();
            Property(u => u.TipoServico).HasColumnName("codTipoServico");

            //HasRequired<Servico>(serv => serv.Pai).WithMany(serv => serv.Pai).Map(m => m.MapKey(""));
            HasOptional<Segmento>(serv => serv.Segmento).WithMany(seg => seg.Servicos).Map(m => m.MapKey("codSegmento"));
        }
    }
}
