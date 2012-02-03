using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using RM.Precificacao.Infra;
using RM.Precificacao.Dominio.Entidades;
using RM.Precificacao.Dominio.Enumeradores;
using RM.Precificacao.Dominio;

namespace RM.Precificacao.App
{
    public class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<RMPrecificacaoDbContext>());

            PopularContexto(new RMPrecificacaoDbContext());
        }

        public static void PopularContexto(IDbContext contexto)
        {
            var segmentos = CriarSegmentos();
            var servicos = CriarServicos(segmentos);

            segmentos.ForEach(s => contexto.Segmentos.Add(s));
            contexto.SaveChanges();

            servicos.ForEach(s => contexto.Servicos.Add(s));
            contexto.SaveChanges();
        }

        public static List<Servico> CriarServicos(IList<Segmento> segmentos)
        {
            var servicos = new List<Servico>();

            var servicoPai = new Servico
            {
                Descricao = "Serviço Pai",
                Empresa = (int)Empresa.RmTelecom,
                TipoServico = (int)TipoServico.Engenharia,
                ReferenciaServico = (int)ReferenciaServico.Acionamento,
                Pai = null,
                Segmento = segmentos[0]
            };

            var servico = new Servico
            {
                Descricao = "Instalação TUP",
                Empresa = (int)Empresa.RmTelecom,
                TipoServico = (int)TipoServico.OeM,
                ReferenciaServico = (int)ReferenciaServico.Sector,
                Pai = servicoPai,
                Segmento = segmentos[0]
            };

            servicos.Add(servico);

            servico = new Servico
            {
                Descricao = "Mudança de Endereço",
                Empresa = (int)Empresa.RmTelecom,
                TipoServico = (int)TipoServico.Engenharia,
                ReferenciaServico = (int)ReferenciaServico.HOP,
                Pai = servicoPai,
                Segmento = segmentos[1]
            };

            servicos.Add(servico);

            servico = new Servico
            {
                Descricao = "Instalação de Acesso VDSL",
                Empresa = (int)Empresa.RmEnergia,
                TipoServico = (int)TipoServico.OeM,
                ReferenciaServico = (int)ReferenciaServico.Site,
                Pai = servicoPai,
                Segmento = segmentos[1]
            };

            servicos.Add(servico);

            return servicos;
        }

        public static List<Segmento> CriarSegmentos()
        {
            var segmentos = new List<Segmento>();

            segmentos.Add(new Segmento
            {
                Descricao = "VOZ",
                //Servicos = new List<Servico> { servicos.ElementAt(2) }
            });

            segmentos.Add(new Segmento
            {
                Descricao = "ADSL",
                //Servicos = servicos.Take(2).ToList()
            });

            return segmentos;
        }
    }
}
