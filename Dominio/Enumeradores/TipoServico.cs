using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RM.Precificacao.Dominio.Attributes;

namespace RM.Precificacao.Dominio.Enumeradores
{
    public enum TipoServico
    {
        [StringValue("Engenharia")]
        Engenharia = 1,
        [StringValue("O&M")]
        OeM = 2
    }
}
