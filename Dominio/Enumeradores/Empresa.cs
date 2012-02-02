using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Attributes;

namespace RM.Precificacao.Dominio.Enumeradores
{
    public enum Empresa
    {
        [StringValue("RM Telecom")]
        RmTelecom = 1,
        [StringValue("RM Energia")]
        RmEnergia = 2
    }
}
