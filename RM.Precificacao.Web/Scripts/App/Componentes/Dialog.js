/// <reference path="../Main/Namespace.js" />

RM.Precificacao.Componente.Dialog = function (idContainer, titulo, largura, altura, botoes) {

    /// <summary>
    /// Renderiza uma popup na tela com o container especificado.
    /// </summary>
    /// <param name="idContainer" type="string">ID do container a ser renderizado na popup.</param>
    /// <param name="titulo" type="string">Título da popup.</param>
    /// <param name="largura" type="number">Largura da popup.</param>
    /// <param name="altura" type="number">Largura da popup.</param>
    /// <param name="botoes" type="array">
    /// Array de objetos literais com duas propriedades:
    /// &#10;- text: texto do botão;
    /// &#10;- click: função que será executada ao clicar no botão.
    /// </param>


    // Propriedades 

    var that = this;
    that.popup = null;
    var _idContainer = '#' + idContainer;


    // Construtor

    that.popup = $(_idContainer).dialog({
        title: titulo || 'Popup',
        minWidth: largura || 400,
        minHeight: altura || 300,
        buttons: botoes,
        autoOpen: false,
        resizable: false
    });
};

RM.Precificacao.Componente.Dialog.prototype = {

    constructor: RM.Precificacao.Componente.Dialog,

    abrir: function () {

        /// <summary>
        /// Abre a popup na tela.
        /// </summary>

        this.popup.dialog('open');
    },

    fechar: function () {

        /// <summary>
        /// Fecha a popup.
        /// </summary>

        this.popup.dialog('close');
    }
}

// USAGE =================================================================================//

//var popup = new RM.Precificacao.Componente.Dialog('containerTal', 'Formulário Tal', 600, 450, 
//    [
//      { text: 'OK' , click: function () { obj.salvar(); $(this).dialog('close'); } },
//      { text: 'Cancelar' , click: function () { $(this).dialog('close'); } }
//    ]);
//popup.abrir();
//popup.fechar();
