/// <reference path="../Namespace.js" />
/// <reference path="../../Componentes/Dialog.js" />


RM.Precificacao.Script.MainScript = function () {

    var that = this;
    var viewModel = new RM.Precificacao.ViewModel.MainViewModel();
    var tabelaConsultaMapaOfertaServicos = viewModel.tabelaConsultaMapaOfertaServicos;
    var popupConsultaMapaOfertaServicos = viewModel.popupConsultaMapaOfertaServicos;


    // Métodos

    that.abrirConsultaDeServicos = function (e) {
        e.preventDefault();

        popupConsultaMapaOfertaServicos.abrir();
    };

    that.selecionarOfertaDeServico = function (e) {
        // TODO

        tabelaConsultaMapaOfertaServicos.limparTabela();
        popupConsultaMapaOfertaServicos.fechar();
    };
};

(function ($) {

    $(function () {

        var mainScript = new RM.Precificacao.Script.MainScript();

        // Event Bind

        $('.abrirConsultaDeServicos').click(mainScript.abrirConsultaDeServicos);
        $('#tabelaConsultaMapaOfertaServicos tr').live('click', mainScript.selecionarOfertaDeServico);
    });

})(jQuery);