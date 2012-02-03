/// <reference path="../../../Main/Namespace.js" />

RM.Precificacao.Script.ServicoIndexScript = function () {

    var that = this;
    var viewModel = new RM.Precificacao.ViewModel.ServicoIndexViewModel();


    // Métodos

    that.toggleFiltros = function (e) {
        var content = $(e.currentTarget).siblings('.content');
        content.slideToggle();
    };
};

(function ($) {

    $(function () {

        var servicoIndexScript = new RM.Precificacao.Script.ServicoIndexScript();

        // Event Bind

        $('#main > .filtros h2').click(servicoIndexScript.toggleFiltros);

    });

})(jQuery);