/// <reference path="../Namespaces/Namespaces.js" />


RM.Precificacao.Servidor = function Servidor() {

    /// <summary>
    /// Faz conexão com o lado servidor.
    /// </summary>

};

RM.Precificacao.Servidor.ajax = function (options) {

    /// <summary>
    /// Faz uma requisição ajax.
    /// &#10;Exceções: TypeError.
    /// </summary>
    /// <param name="options" type="json">
    /// string url: Url no padrão ASP.NET MVC: NomeController/NomeAction.
    /// &#10;string parametros: Parâmetros a serem passados à Action.
    /// &#10;jQuery loader: Figura de carregamento.
    /// &#10;function successCallback: Função a ser executada após uma resposta de sucesso do servidor.
    /// &#10;function beforeSend: Função a ser executada antes da requisição ser iniciada.
    /// &#10;function complete: Função a ser executada após a chegada da resposta do servidor.
    /// &#10;Esta função será executada mesmo que a resposta seja um erro.
    /// </param>
    /// <returns type="void" />

    $.ajax({
        type: 'post',
        url: options.url,
        data: options.parametros,
        beforeSend: function () {
            if (options.loader) {
                $(options.loader).fadeIn();
            }

            if (options.beforeSend && typeof (options.beforeSend) === 'function') {
                options.beforeSend.call();
            }
        },
        success: function (resultado) {
            if (typeof (options.successCallback) === 'function') {
                options.successCallback(resultado, options.context);
            }
            else {
                throw new TypeError("Servidor.ajax(): O parâmetro 'successCallback' não é uma função.");
            }
        },
        error: function (erro) {
            alert(erro);
        },
        complete: function () {
            if (options.loader) {
                $(options.loader).fadeOut();
            }

            if (options.complete && typeof (options.complete) === 'function') {
                options.complete.call();
            }
        }
    });
};