using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using RM.Precificacao.Infra;
using RM.Precificacao.Dominio.Entidades;
using RM.Precificacao.Dominio.Enumeradores;

namespace RM.Precificacao.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<RMPrecificacaoDbContext>());

            var servicos = CriarServicos();
            var segmentos = CriarSegmentos(servicos);

            using (var contexto = new RMPrecificacaoDbContext())
            {
                servicos.ForEach(s => contexto.Servicos.Add(s));
                segmentos.ForEach(s => contexto.Segmentos.Add(s));
                contexto.SaveChanges();
            }

            //using (var contexto = new RMPrecificacaoDbContext())
            //{                
            //    InserirSegmentosEmServicos(contexto.Servicos, contexto.Segmentos);
            //    contexto.SaveChanges();
            //}
        }

        private static List<Servico> CriarServicos()
        {
            var servicos = new List<Servico>();

            var servicoPai = new Servico
            {
                Descricao = "Serviço Pai",
                Empresa = (int)Empresa.RmTelecom,
                TipoServico = (int)TipoServico.Engenharia,
                ReferenciaServico = (int)ReferenciaServico.Acionamento,
                Pai = null
            };

            var servico = new Servico
            {
                Descricao = "Instalação TUP",
                Empresa = (int)Empresa.RmTelecom,
                TipoServico = (int)TipoServico.OeM,
                ReferenciaServico = (int)ReferenciaServico.Sector,
                Pai = servicoPai
            };

            servicos.Add(servico);

            servico = new Servico
            {
                Descricao = "Mudança de Endereço",
                Empresa = (int)Empresa.RmTelecom,
                TipoServico = (int)TipoServico.Engenharia,
                ReferenciaServico = (int)ReferenciaServico.HOP,
                Pai = servicoPai
            };

            servicos.Add(servico);

            servico = new Servico
            {
                Descricao = "Instalação de Acesso VDSL",
                Empresa = (int)Empresa.RmEnergia,
                TipoServico = (int)TipoServico.OeM,
                ReferenciaServico = (int)ReferenciaServico.Site,
                Pai = servicoPai
            };

            servicos.Add(servico);

            return servicos;
        }

        private static List<Segmento> CriarSegmentos(IList<Servico> servicos)
        {
            var segmentos = new List<Segmento>();

            segmentos.Add(new Segmento 
            { 
                Descricao = "VOZ", 
                Servicos = new List<Servico> { servicos.ElementAt(2) }
            });

            segmentos.Add(new Segmento
            {
                Descricao = "ADSL",
                Servicos = servicos.Take(2).ToList()
            });

            return segmentos;
        }

        public static void InserirSegmentosEmServicos(IDbSet<Servico> servicos, IDbSet<Segmento> segmentos)
        {
            var listaServicos = servicos.ToList();
            var listaSegmentos = segmentos.ToList();

            listaServicos.ElementAt(0).Segmento = listaSegmentos.ElementAt(0);
            listaServicos.ElementAt(1).Segmento = listaSegmentos.ElementAt(0);
            listaServicos.ElementAt(2).Segmento = listaSegmentos.ElementAt(1);
            listaServicos.ElementAt(3).Segmento = listaSegmentos.ElementAt(1);
        }
    }
}
