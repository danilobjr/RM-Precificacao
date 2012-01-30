using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RM.Precificacao.Dominio;
using RM.Precificacao.Dominio.Entidades;

namespace RM.Precificacao.Infra.Repositorio
{
    public class MapaOfertaServicosRepositorio
    {
        public IDbContext Contexto { get; set; }

        public MapaOfertaServicosRepositorio(IDbContext contexto)
        {
            Contexto = contexto;
        }

        public void Inserir(Servico entidade)
        {
            throw new NotImplementedException();
        }

        public void Alterar(Servico entidade)
        {
            throw new NotImplementedException();
        }

        public List<Servico> Consultar(Servico entidade)
        {
            return Contexto.Servicos.Where(s => s.Descricao.Contains(entidade.Descricao)).ToList();
        }

        public IQueryable<Servico> Consultar(Predicate<Servico> predicado)
        {
            return null;
        }
    }
}
