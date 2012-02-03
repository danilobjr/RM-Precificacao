/// <reference path="../Main/Namespace.js" />

RM.Precificacao.Elemento.PopupConsultaMapaDeOfertaDeServicos = function (idContainer, titulo, largura, altura, botoes, tabelaConsultaMaparOfertaServico) {

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
    /// <param name="tabelaConsultaMaparOfertaServico" type="TabelaConsultaMapaDeOfertaDeServicos">
    /// Tabela Consulta Mapa de Oferta de Servicos.
    /// </param>


    // Propriedades

    this._tabelaConsultaMapaDeOfertaDeServico = tabelaConsultaMaparOfertaServico;


    // Construtor da class pai

    RM.Precificacao.Componente.Dialog.call(this, idContainer, titulo, largura, altura, botoes);
};

RM.Precificacao.Elemento.PopupConsultaMapaDeOfertaDeServicos.prototype = 
    new RM.Precificacao.Componente.Dialog(); // TODO - ObjectCreate

RM.Precificacao.Elemento.PopupConsultaMapaDeOfertaDeServicos.prototype.abrir = function () {

    /// <summary>
    /// Abre a popup na tela.
    /// </summary>

    this.popup.dialog('open');
    this._tabelaConsultaMapaDeOfertaDeServico.carregarRegistros();
};

// USAGE =================================================================================//

//var popup = new RM.Precificacao.Componente.Dialog('containerTal', 'Formulário Tal', 600, 450, 
//    [
//      { text: 'OK' , click: function () { obj.salvar(); $(this).dialog('close'); } },
//      { text: 'Cancelar' , click: function () { $(this).dialog('close'); } }
//    ]);
//popup.abrir();
//popup.fechar();