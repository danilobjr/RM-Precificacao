using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using RM.Precificacao.Dominio.Entidades;
using RM.Precificacao.Dominio.Enumeradores;

namespace RM.Precificacao.Infra
{
    public class DominioInitializer : DropCreateDatabaseIfModelChanges<RMPrecificacaoDbContext>
    {
        protected override void Seed(RMPrecificacaoDbContext context)
        {
            IList<Servico> servicos = CriarServicos();

            context.Servicos.Concat(servicos);
            //context.SaveChanges();

            IList<Segmento> segmentos = CriarSegmentos(servicos);

            context.Segmentos.Concat(segmentos);
            //context.SaveChanges();

            base.Seed(context);
        }

        private IList<Servico> CriarServicos()
        {
            var servicoPai = new Servico
            {
                Descricao = "Serviço Pai",
                Empresa = Convert.ToInt32(Empresa.RmTelecom),
                TipoServico = Convert.ToInt32(TipoServico.Engenharia),
                ReferenciaServico = Convert.ToInt32(ReferenciaServico.Acionamento),
                Pai = null
            };

            var servicos = new List<Servico>();

            for (int contador = 0; contador < 5; contador++)
            {
                var servico = new Servico
                {
                    Descricao = "Instalação TUP",
                    Empresa = Convert.ToInt32(Empresa.RmTelecom),
                    TipoServico = Convert.ToInt32(TipoServico.OeM),
                    ReferenciaServico = Convert.ToInt32(ReferenciaServico.Sector),
                    Pai = servicoPai
                };

                servicos.Add(servico);
            }

            for (int contador = 0; contador < 5; contador++)
            {
                var servico = new Servico
                {
                    Descricao = "Mudança de Endereço",
                    Empresa = Convert.ToInt32(Empresa.RmTelecom),
                    TipoServico = Convert.ToInt32(TipoServico.Engenharia),
                    ReferenciaServico = Convert.ToInt32(ReferenciaServico.HOP),
                    Pai = servicoPai
                };

                servicos.Add(servico);
            }

            for (int contador = 0; contador < 5; contador++)
            {
                var servico = new Servico
                {
                    Descricao = "Instalação de Acesso VDSL",
                    Empresa = Convert.ToInt32(Empresa.RmEnergia),
                    TipoServico = Convert.ToInt32(TipoServico.OeM),
                    ReferenciaServico = Convert.ToInt32(ReferenciaServico.Site),
                    Pai = servicoPai
                };

                servicos.Add(servico);
            }

            for (int contador = 0; contador < 5; contador++)
            {
                var servico = new Servico
                {
                    Descricao = "ALTCTEC de Acesso ADSL",
                    Empresa = Convert.ToInt32(Empresa.RmEnergia),
                    TipoServico = Convert.ToInt32(TipoServico.Engenharia),
                    ReferenciaServico = Convert.ToInt32(ReferenciaServico.PCS),
                    Pai = servicoPai
                };

                servicos.Add(servico);
            }

            return servicos;
        }

        private IList<Segmento> CriarSegmentos(IList<Servico> servicos)
        {
            var segmentos = new List<Segmento> 
            {
                new Segmento { Descricao = "VOZ", Servicos = servicos.Where(s => s.Id > 0 && s.Id <= 10).ToList() },
                new Segmento { Descricao = "ADSL", Servicos = servicos.Where(s => s.Id > 10 && s.Id <= 20).ToList() }
            };

            return segmentos;
        }
    }
}
