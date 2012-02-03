/// <reference path="../Namespace.js" />
/// <reference path="../../Componentes/Dialog.js" />


RM.Precificacao.Script.MainScript = function () {

    var that = this;
    var viewModel = new RM.Precificacao.ViewModel.MainViewModel();
    var formConsultaMapaOfertaServicos = viewModel.formConsultaMapaOfertaServicos;
    var tabelaConsultaMapaOfertaServicos = viewModel.tabelaConsultaMapaOfertaServicos;
    var popupConsultaMapaOfertaServicos = viewModel.popupConsultaMapaOfertaServicos;


    // Métodos

    that.abrirConsultaDeServicos = function (e) {
        e.preventDefault();

        tabelaConsultaMapaOfertaServicos.limparTabela();
        popupConsultaMapaOfertaServicos.abrir();
    };

    that.selecionarOfertaDeServico = function (e) {
        // TODO

        popupConsultaMapaOfertaServicos.fechar();
    };

    that.filtrarDadosPopupConsultaMapaOfertaServicos = function (e) {
        e.preventDefault();

        var callback = function (resultado) {
            tabelaConsultaMapaOfertaServicos.limparTabela();
            tabelaConsultaMapaOfertaServicos.adicionarLinhas(resultado.Dados.Servicos);
        };

        formConsultaMapaOfertaServicos.filtrar(callback);
    }
};

(function ($) {

    $(function () {

        var mainScript = new RM.Precificacao.Script.MainScript();

        // Event Bind

        $('.abrirConsultaDeServicos').click(mainScript.abrirConsultaDeServicos);
        $('#tabelaConsultaMapaOfertaServicos tr').live('click', mainScript.selecionarOfertaDeServico);
        $('#consultaMapaOfertaServico form button').click(mainScript.filtrarDadosPopupConsultaMapaOfertaServicos);
    });

})(jQuery);