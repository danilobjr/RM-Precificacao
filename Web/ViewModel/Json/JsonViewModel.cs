using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RM.Precificacao.Web.ViewModel.Json
{
    public class JsonViewModel
    {
        public bool Sucesso { get; set; }
        public dynamic Dados { get; set; }
        public Mensagem Mensagem { get; set; }
    }

    public class Mensagem
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public Exception Excecao { get; set; }
    }
}