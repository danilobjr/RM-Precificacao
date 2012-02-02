using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RM.Precificacao.Dominio.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace RM.Precificacao.Infra.Mapeamentos
{
    class SegmentoConfiguration : EntityTypeConfiguration<Segmento>
    {
        public SegmentoConfiguration()
        {
            ToTable("tbSegmento");

            HasKey(s => s.Id);

            Property(s => s.Id).HasColumnName("isnSegmento").IsRequired();
            Property(s => s.Descricao).HasColumnName("dscSegmento").HasMaxLength(50).IsRequired();
        }
    }
}
