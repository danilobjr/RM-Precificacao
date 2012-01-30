using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RM.Precificacao.Dominio.Entidades;
using RM.Precificacao.Dominio;

namespace RM.Precificacao.Dominio.Servicos
{
    public class MapaOfertaServicos
    {
        IDbContext Contexto { get; set; }


        public MapaOfertaServicos(IDbContext contexto)
        {
            this.Contexto = contexto;
        }


        public void ValidarInclusao(Servico novoServico)
        {
            throw new NotImplementedException();
        }

        public void ValidarAlteracao(Servico servicoEditado)
        {
            throw new NotImplementedException();
        }

        public void AlterarServico(Servico servicoAlterado)
        {
            ValidarAlteracao(servicoAlterado);

            var servicoOriginal = Contexto.Servicos.SingleOrDefault(s => s.Id == servicoAlterado.Id);

            servicoOriginal.Descricao = servicoAlterado.Descricao;
            servicoOriginal.Pai = servicoAlterado.Pai;
            servicoOriginal.Empresa = servicoAlterado.Empresa;
            servicoOriginal.ReferenciaServico = servicoAlterado.ReferenciaServico;
            servicoOriginal.TipoServico = servicoAlterado.TipoServico;
            servicoOriginal.Segmento = servicoAlterado.Segmento;
        }
    }
}
