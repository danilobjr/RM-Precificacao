/// <reference path="../../Namespaces/Namespaces.js" />
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

RM.Precificacao.Elemento.TabelaConsultaMapaDeOfertaDeServicos.prototype = {

    constructor: RM.Precificacao.Componente.TabelaConsultaMapaDeOfertaDeServicos,

    carregarRegistros: function () {

        /// <summary>
        /// Carrega os registros da tabela via JSON.
        /// </summary>

        RM.Precificacao.Servidor.ajax({
            url: '/Servico/ObterTodosOsServicos',
            success: function (servicos) {
                if (servicos) {
                    var linhas = [];

                    $.each(servicos, function (i, servico) {
                        var _servico = $(servico);
                        linhas.push([
                            servico.Empresa,
                            servico.TipoReferencia,
                            servico.Segmento.Descricao,
                            servico.Descricao,
                            servico.ReferenciaServico
                        ]);
                    });
                }
            }
        });
    }
}

// USAGE =================================================================================//

//var tabela = new RM.Precificacao.Componente.Tabela("tabelaTal");

//tabela.adicionarLinha(['Dado da Coluna 1', 'Dado da Coluna 2', 'Dado da Coluna 3']);
//tabela.adicionarLinhas([['', ''], ['', '']]);
//tabela.limparTabela();
//tabela.obterIndiceDaLinha(linhaTal);
//tabela.obterLinhaPorIndice(0);
//tabela.obterTodasAsLinhas();