﻿/// <reference path="../../Namespaces/Namespaces.js" />
/// <reference path="../../Servidor/Servidor.js" />


RM.Precificacao.Elemento.TabelaConsultaMapaDeOfertaDeServicos = function (idTabela) {

    /// <summary>
    /// Renderiza o plugin DataTables na tabela de Consulta Mapa de Oferta de Serviços.
    /// </summary>
    /// <param name="idTabela" type="string">ID da tabela a ser renderizada.</param>


    // Propriedades 

    this.tabela = null;


    // Construtor da classe pai

    RM.Precificacao.Componente.Tabela.call(this, idTabela);
};

RM.Precificacao.Elemento.TabelaConsultaMapaDeOfertaDeServicos.prototype = 
    new RM.Precificacao.Componente.Tabela();

RM.Precificacao.Elemento.TabelaConsultaMapaDeOfertaDeServicos.prototype.carregarRegistros = function () {

    /// <summary>
    /// Carrega os registros da tabela via JSON.
    /// </summary>

    var that = this;

    RM.Precificacao.Servidor.ajax({
        url: '/Servico/ObterTodosOsServicos',
        successCallback: function (resultado, context) {
            if (resultado.Dados) {
                var linhas = [];

                $.each(resultado.Dados, function (i, servico) {
                    var _servico = $(servico);
                    linhas.push([
                        servico.Empresa,
                        servico.TipoServico,
                        servico.DescricaoSegmento,
                        servico.DescricaoServico,
                        servico.ReferenciaServico
                    ]);
                });

                context.tabela.adicionarLinhas(linhas);
            }
        },
        context: {
            tabela: that
        }
    });
};

// USAGE =================================================================================//

//var tabela = new RM.Precificacao.Componente.Tabela("tabelaTal");

//tabela.adicionarLinha(['Dado da Coluna 1', 'Dado da Coluna 2', 'Dado da Coluna 3']);
//tabela.adicionarLinhas([['', ''], ['', '']]);
//tabela.limparTabela();
//tabela.obterIndiceDaLinha(linhaTal);
//tabela.obterLinhaPorIndice(0);
//tabela.obterTodasAsLinhas();